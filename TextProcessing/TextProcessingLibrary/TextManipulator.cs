namespace TextProcessingLibrary
{
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Net.Sockets;
    using System.Text;

    using TextProcessingLibrary.Parsers;
    using TextProcessingLibrary.TextItems;
    using TextProcessingLibrary.TextItems.SentenceItems;

    public static class TextManipulator
    {
        public static IEnumerable<ISentence> GetSortedSentencesByWordsCount(IText text)
        {
            return from paragraph in text.Paragraphs
                   from sentence in paragraph.Sentences
                   orderby sentence.SentenceItems.Count
                   select sentence;
        }

        public static IEnumerable<ISentenceItem> GetWordsFromInterrogativeSentences(IText text, int wordLength)
        {
            var result = from paragraph in text.Paragraphs
                         from sentence in paragraph.Sentences
                         where sentence.GetSentenceType() == SentenceType.Interrogative
                         from word in sentence.SentenceItems
                         where word.Symbols.Count == wordLength
                         select word;

            return result.Distinct();
        }

        public static IEnumerable<IParagraph> GetParagraphsWithoutWordsWithSymbolOnIndex(IText text, int wordLength, int index, char symbol)
        {
            return from paragraph in text.Paragraphs
                   from sentence in paragraph.Sentences
                   from word in sentence.SentenceItems 
                   where word.Symbols.Count == wordLength && word.Symbols[index] != symbol
                   select paragraph;
        }

        public static ISentence ReplaceWordsWithSubstring(ISentence sentence, int wordLength, string substring)
        {
            var stringBuilder = new StringBuilder();
            foreach (var sentenceItem in sentence.SentenceItems)
            {
                if (sentenceItem.Symbols.Count != wordLength)
                {
                    stringBuilder.Append(sentenceItem);
                    continue;
                }

                stringBuilder.Append($"{substring} ");
            }

            var parser = new Parser();
            return parser.CreateSentence(stringBuilder.ToString(), 1);
        }
    }
}
