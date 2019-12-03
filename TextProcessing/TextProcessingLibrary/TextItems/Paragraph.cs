namespace TextProcessingLibrary.TextItems
{
    using System.Collections.Generic;
    using System.Runtime.Serialization;
    using System.Text;

    using TextProcessingLibrary.TextItems.SentenceItems;

    [DataContract]
    [KnownTypeAttribute(typeof(Sentence))]
    public class Paragraph : IParagraph
    {
        public Paragraph(string redLine = "\n")
        {
            this.Sentences = new List<ISentence>();
            this.RedLine = redLine;
        }

        public Paragraph(List<ISentence> sentences, string redLine = "\n")
        {
            this.Sentences = sentences;
            this.RedLine = redLine;
        }

        [DataMember]
        public List<ISentence> Sentences { get; set; }

        [DataMember]
        public string RedLine { get; set; }

        public void Add(ISentence newSentence)
        {
            this.Sentences.Add(newSentence);
        }

        public void Remove(ISentence removedSentence)
        {
            this.Sentences.Remove(removedSentence);
        }

        public override string ToString()
        {
            var stringBuilder = new StringBuilder();
            stringBuilder.Append(this.RedLine);
            foreach (var sentence in this.Sentences)
            {
                stringBuilder.Append($"{sentence} ");
            }

            return stringBuilder.ToString();
        }
    }
}
