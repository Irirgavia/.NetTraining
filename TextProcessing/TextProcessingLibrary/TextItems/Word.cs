namespace TextProcessingLibrary.TextItems
{
    public class Word
    {
        public Word(string letters = "", char symbolAfterWord = ' ', int locationLine = 1)
        {
            this.Letters = letters;
            this.SymbolAfterWord = symbolAfterWord;
            this.LocationLine = locationLine;
        }

        public string Letters { get; set; }

        public char SymbolAfterWord { get; set; }

        public int LocationLine { get; set; }

        public override string ToString()
        {
            return $"{Letters}{SymbolAfterWord}";
        }
    }
}
