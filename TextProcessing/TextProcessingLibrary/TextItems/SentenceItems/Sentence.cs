namespace TextProcessingLibrary.TextItems.SentenceItems
{
    using System.Collections.Generic;
    using System.Text;

    public class Sentence : ISentence
    {
        public Sentence(char separator = ' ')
        {
            this.SentenceItems = new List<ISentenceItem>();
            this.Separator = separator;
        }

        public Sentence(List<ISentenceItem> words, char separator)
        {
            this.SentenceItems = words;
            this.Separator = separator;
        }
        
        public List<ISentenceItem> SentenceItems { get; set; }

        public char Separator { get; set; }

        public SentenceType GetSentenceType()
        {
            switch (this.SentenceItems[this.SentenceItems.Count - 1].ToString())
            {
                case "?":
                    return SentenceType.Interrogative;

                case "!":
                    return SentenceType.Exclamatory;

                default:
                    return SentenceType.Narrative;
            }
        }

        public void Add(ISentenceItem sentenceItem)
        {
            this.SentenceItems.Add(sentenceItem);
        }

        public void Remove(ISentenceItem sentenceItem)
        {
            this.SentenceItems.Remove(sentenceItem);
        }

        public override string ToString()
        {
            var stringBuilder = new StringBuilder();
            foreach (var sentenceItem in this.SentenceItems)
            {
                stringBuilder.Append(sentenceItem);
                stringBuilder.Append(this.Separator);
            }

            return stringBuilder.ToString();
        }
    }
}
