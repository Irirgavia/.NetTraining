namespace TextProcessingLibrary.TextItems.SentenceItems
{
    using System.Collections.Generic;
    using System.Runtime.Serialization;
    using System.Text;

    [DataContract]
    [KnownTypeAttribute(typeof(Word))]
    [KnownTypeAttribute(typeof(PunctuationMark))]
    public class SentenceItem : ISentenceItem
    {
        public SentenceItem(List<char> symbols)
        {
            this.Symbols = symbols;
        }

        [DataMember]
        public List<char> Symbols { get; set; }

        public void Add(char symbol)
        {
            this.Symbols.Add(symbol);
        }

        public void Remove(char symbol)
        {
            this.Symbols.Remove(symbol);
        }

        public override string ToString()
        {
            var stringBuilder = new StringBuilder();
            foreach (var symbol in this.Symbols)
            {
                stringBuilder.Append(symbol);
            }

            return stringBuilder.ToString();
        }
    }
}
