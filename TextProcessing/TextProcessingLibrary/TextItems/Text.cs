namespace TextProcessingLibrary.TextItems
{
    using System.Collections.Generic;
    using System.Text;

    public class Text : IText
    {
        public Text(string title = "")
        {
            this.Title = title;
            this.Paragraphs = new List<IParagraph>();
        }

        public Text(List<IParagraph> paragraphs, string title = "")
        {
            this.Title = title;
            this.Paragraphs = paragraphs;
        }

        public string Title { get; set; }

        public List<IParagraph> Paragraphs { get; set; }

        public void Add(IParagraph newParagraph)
        {
            this.Paragraphs.Add(newParagraph);
        }

        public void Remove(IParagraph removedParagraph)
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
