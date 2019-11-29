namespace TextProcessingLibrary.Concordance
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using TextProcessingLibrary.TextItems;
    using TextProcessingLibrary.TextItems.SentenceItems;

    public class ConcordanceManipulator
    {
        private List<ConcordanceWord> ConcordanceWords { get; set; }

        public List<ConcordanceWord> CreateDictionary(Text text)
        {
            this.ConcordanceWords = new List<ConcordanceWord>();
            var usedWords = new List<string>();

            foreach (var paragraph in text.Paragraphs)
            {
                foreach (var sentence in paragraph.Sentences)
                {
                    foreach (var sentenceItem in sentence.SentenceItems)
                    {
                        if (sentenceItem.GetType() != typeof(Word))
                        {
                            continue;
                        }

                        var word = (Word)sentenceItem;
                        var concordanceWord = new ConcordanceWord(word.ToString(), new List<int>() { word.LocationLine });

                        var wordIndex = usedWords.IndexOf(concordanceWord.Word);

                        if (wordIndex != -1)
                        {
                            if (this.ConcordanceWords[wordIndex].LocationLines.Exists(x => x > 1))
                            {
                                this.ConcordanceWords[wordIndex].EntriesCounts++;
                                continue;
                            }

                            this.ConcordanceWords[wordIndex].LocationLines.Add(word.LocationLine);
                        }
                        else
                        {
                            this.ConcordanceWords.Add(concordanceWord);
                            usedWords.Add(concordanceWord.Word);
                        }
                    }
                }
            }

            return this.ConcordanceWords;
        }

        public List<ConcordanceWord> SortConcordanceWords()
        {
            return (from concordanceWord in this.ConcordanceWords
                   orderby concordanceWord.Word
                   select concordanceWord).ToList();
        }

        public override string ToString()
        {
            IEnumerable<char> alphabetLetters = new List<char>() { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z' };

            // TODO: division into groups
            var stringBuilder = new StringBuilder();

            foreach (var word in this.ConcordanceWords)
            {
                stringBuilder.Append($"{word}\n");
            }
            return base.ToString();
        }
    }
}
