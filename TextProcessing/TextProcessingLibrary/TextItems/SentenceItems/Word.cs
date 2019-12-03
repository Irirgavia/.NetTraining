namespace TextProcessingLibrary.TextItems.SentenceItems
{
    using System.Collections.Generic;
    using System.Runtime.Serialization;

    [DataContract]
    public class Word : SentenceItem
    {
        public Word(List<char> symbols, int locationLine = 1)
            : base(symbols)
        {
            this.Symbols = symbols;
            this.LocationLine = locationLine;
        }

        [DataMember]
        public int LocationLine { get; set; }
    }
}
