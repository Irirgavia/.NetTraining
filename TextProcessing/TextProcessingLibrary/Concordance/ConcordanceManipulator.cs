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

        public ConcordanceManipulator GetDictionary(IText text)
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
                            this.ConcordanceWords[wordIndex].LocationLines.Add(word.LocationLine);
                            this.ConcordanceWords[wordIndex].EntriesCounts++;
                        }
                        else
                        {
                            this.ConcordanceWords.Add(concordanceWord);
                            this.ConcordanceWords[this.ConcordanceWords.Count - 1].EntriesCounts++;
                            usedWords.Add(concordanceWord.Word);
                        }
                    }
                }
            }

            return this;
        }

        public ConcordanceManipulator SortConcordanceWords()
        {
            this.ConcordanceWords = (from concordanceWord in this.ConcordanceWords
                                    orderby concordanceWord.Word
                                    select concordanceWord).ToList();
            return this;
        }

        public override string ToString()
        {
            IEnumerable<char> alphabetLetters = new List<char>() { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z' };

            var stringBuilder = new StringBuilder("count: page(string)\n");

            foreach (var letter in alphabetLetters)
            {
                stringBuilder.Append($"{letter}\n");
                var words = from word in this.ConcordanceWords 
                            where word.Word.Length > 0 && word.Word.ToUpper()[0] == letter
                            select word;


                foreach (var word in words)
                {
                    stringBuilder.Append($"{word} \n");
                }
            }

            return stringBuilder.ToString();
        }
    }
}
