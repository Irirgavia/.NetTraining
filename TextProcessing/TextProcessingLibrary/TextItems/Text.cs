namespace TextProcessingLibrary.TextItems
{
    using System.Collections.Generic;
    using System.Text;

    public class Text
    {
        public Text(string title = "")
        {
            this.Title = title;
            this.Paragraphs = new List<Paragraph>();
        }

        public Text(List<Paragraph> paragraphs, string title = "")
        {
            this.Title = title;
            this.Paragraphs = paragraphs;
        }

        public string Title { get; set; }

        public List<Paragraph> Paragraphs { get; set; }

        public void Add(Paragraph newParagraph)
        {
            this.Paragraphs.Add(newParagraph);
        }

        public void Remove(Paragraph removedParagraph)
        {
            this.Paragraphs.Remove(removedParagraph);
        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            foreach (var paragraph in this.Paragraphs)
            {
                stringBuilder.Append($"{paragraph}\n");
            }

            return stringBuilder.ToString();
        }
    }
}
