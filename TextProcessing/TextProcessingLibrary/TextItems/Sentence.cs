namespace TextProcessingLibrary.TextItems
{
    using System.Collections.Generic;
    using System.Text;

    public class Sentence
    {
        public Sentence()
        {
            this.Words = new List<Word>();
        }

        public Sentence(List<Word> words)
        {
            this.Words = words;
        }
        
        public List<Word> Words { get; set; }

        public SentenceType GetSentenceType()
        {
            switch (Words[Words.Count - 1].SymbolAfterWord)
            {
                case '?':
                    return SentenceType.Interrogative;

                case '!':
                    return SentenceType.Exclamatory;

                default:
                    return SentenceType.Narrative;
            }
        }

        public void AddWord(Word newWord)
        {
            this.Words.Add(newWord);
        }

        public void RemoveWord(Word removedWord)
        {
            this.Words.Remove(removedWord);
        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            foreach (var word in Words)
            {
                stringBuilder.Append(word);
            }

            return stringBuilder.ToString();
        }
    }
}
