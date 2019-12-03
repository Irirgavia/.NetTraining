namespace TextProcessingLibrary.TextItems
{
    using System.Collections.Generic;
    using System.Runtime.Serialization;
    using System.Text;

    [DataContract]
    [KnownTypeAttribute(typeof(Paragraph))]
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

        [DataMember]
        public string Title { get; set; }
        [DataMember]
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
