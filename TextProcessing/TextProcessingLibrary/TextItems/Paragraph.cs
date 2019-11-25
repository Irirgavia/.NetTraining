namespace TextProcessingLibrary.TextItems
{
    using System.Collections.Generic;
    using System.Text;

    public class Paragraph
    {
        public Paragraph(string redLine = "\t")
        {
            this.Sentences = new List<Sentence>();
            this.RedLine = redLine;
        }

        public Paragraph(List<Sentence> sentences, string redLine = "\t")
        {
            this.Sentences = sentences;
            this.RedLine = redLine;
        }

        public List<Sentence> Sentences { get; set; }

        public string RedLine { get; set; }

        public void AddSentence(Sentence newSentence)
        {
            Sentences.Add(newSentence);
        }

        public void RemoveSentence(Sentence removedSentence)
        {
            Sentences.Remove(removedSentence);
        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append(RedLine);
            foreach (var sentence in Sentences)
            {
                stringBuilder.Append($"{sentence} ");
            }

            return stringBuilder.ToString();
        }
    }
}
