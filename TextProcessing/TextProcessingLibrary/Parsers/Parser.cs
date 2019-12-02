namespace TextProcessingLibrary.Parsers
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;

    using TextProcessingLibrary.TextItems;
    using TextProcessingLibrary.TextItems.SentenceItems;

    public class Parser : IDisposable
    {
        private TextReader TextReader { get; set; }

        public IText CreateText(TextReader textReader, string textTitle)
        {
            this.TextReader = textReader;
            var text = new Text(textTitle);
            try
            {
                var lineWord = new StringBuilder();
                var countOfString = 1;

                var paragraph = new Paragraph();
                var sentence = new Sentence();

                var isEndOfFile = true;

                do
                {
                    var symbol = this.TextReader.Read();
                    if (symbol == -1)
                    {
                        isEndOfFile = false;
                    }

                    var currentSymbol = (char)symbol;

                    switch (currentSymbol)
                    {
                        case '\r':
                            continue;
                        case '\n':
                        case '\t':
                            countOfString++;
                            text.Add(paragraph);
                            paragraph = new Paragraph();
                            sentence = new Sentence();
                            continue;
                        case '!':
                        case '?':
                        case '.':
                            sentence.Add(new Word(lineWord.ToString().ToList(), countOfString));
                            sentence.Add(new PunctuationMark(new List<char>() { currentSymbol }));
                            paragraph.Add(sentence);
                            lineWord.Clear();
                            sentence = new Sentence();
                            continue;
                        case ' ':
                        case '"':
                        case '`':
                        case ';':
                        case ':':
                        case '-':
                        case '~':
                        case '/':
                        case ',':
                            sentence.Add(new Word(lineWord.ToString().ToList(), countOfString));
                            sentence.Add(new PunctuationMark(new List<char>() { currentSymbol }));
                            lineWord.Clear();
                            continue;
                        default:
                            lineWord.Append(currentSymbol);
                            break;
                    }
                }
                while (isEndOfFile);
            }
            catch (IOException e)
            {
                // TODO: exception handling
            }
            finally
            {
                this.TextReader.Dispose();
            }

            return text;
        }

        public ISentence CreateSentence(string stringWithSentence, int countOfString)
        {
            var lineWord = new StringBuilder();
            var sentence = new Sentence();

            for (int i = 0; i < stringWithSentence.Length; i++)
            {
                var currentSymbol = (char)stringWithSentence[i];

                switch (currentSymbol)
                {
                    case '!':
                    case '?':
                    case '.':
                        sentence.Add(new Word(lineWord.ToString().ToList(), countOfString));
                        sentence.Add(new PunctuationMark(new List<char>() { currentSymbol }));
                        lineWord.Clear();
                        return sentence;
                    case ' ':
                    case '"':
                    case '`':
                    case ';':
                    case ':':
                    case '-':
                    case '~':
                    case '/':
                    case ',':
                        sentence.Add(new Word(lineWord.ToString().ToList(), countOfString));
                        sentence.Add(new PunctuationMark(new List<char>() { currentSymbol }));
                        lineWord.Clear();
                        continue;
                    default:
                        lineWord.Append(currentSymbol);
                        break;
                }
            }

            return sentence;
        }

        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                this.TextReader?.Dispose();
            }
        }
    }
}
