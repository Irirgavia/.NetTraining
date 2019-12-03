namespace TextProcessing
{
    using System;
    using System.IO;
    using System.Windows.Forms;

    using NLog;

    using TextProcessingLibrary;
    using TextProcessingLibrary.Concordance;
    using TextProcessingLibrary.Parsers;
    using TextProcessingLibrary.TextItems;

    public partial class StartWindow : Form
    {
        private readonly Logger logger = LogManager.GetCurrentClassLogger();

        private IText text;

        public StartWindow()
        {
            this.InitializeComponent();
            this.labelErrorChooseFile.Visible = false;
            this.buttonSaveText.Enabled = false;
            this.buttonConcordance.Enabled = false;
            this.buttonSortSentences.Enabled = false;
        }

        private void buttonChooseFileTxt_Click(object sender, EventArgs e)
        {
            try
            {
                this.openFileDialog.ShowDialog();

                var fileName = this.openFileDialog.FileName;
                var parser = new Parser();
                this.text = parser.CreateText(new StreamReader(fileName), fileName);

                this.textBox.Text = this.text.ToString();
                this.labelErrorChooseFile.Visible = false;
                this.buttonSaveText.Enabled = true;
                this.buttonConcordance.Enabled = true;
                this.buttonSortSentences.Enabled = true;
            }
            catch (Exception ex)
            {
                this.logger.Error(ex.Message);
                this.labelErrorChooseFile.Visible = true;

                this.buttonSaveText.Enabled = false;
                this.buttonConcordance.Enabled = false;
                this.buttonSortSentences.Enabled = false;
            }
        }

        private void buttonSaveText_Click(object sender, EventArgs e)
        {
            var path = $"{Environment.CurrentDirectory}\\savedText.json";

            JsonHelper.Serialize(this.text, path, typeof(Text));
        }

        private void buttonConcordance_Click(object sender, EventArgs e)
        {
            this.textBox.Text = string.Empty;
            var concordance = new ConcordanceManipulator();
            foreach (var word in concordance.GetDictionary(this.text).SortConcordanceWords().ToString().Split('\n'))
            {
                this.textBox.AppendText($"{word}\n");
            }
        }

        private void buttonSortSentences_Click(object sender, EventArgs e)
        {
            foreach (var sentence in TextManipulator.GetSortedSentencesByWordsCount(this.text))
            {
                this.textBox.AppendText(sentence.ToString());
            }
        }
    }
}
