namespace TextProcessingLibrary.TextItems
{
    using System.Collections.Generic;
    using System.Text;

    public class Paragraph
    {
        public Paragraph(string redLine = "\n")
        {
            this.Sentences = new List<Sentence>();
            this.RedLine = redLine;
        }

        public Paragraph(List<Sentence> sentences, string redLine = "\n")
        {
            this.Sentences = sentences;
            this.RedLine = redLine;
        }

        public List<Sentence> Sentences { get; set; }

        public string RedLine { get; set; }

        public void Add(Sentence newSentence)
        {
            this.Sentences.Add(newSentence);
        }

        public void Remove(Sentence removedSentence)
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
