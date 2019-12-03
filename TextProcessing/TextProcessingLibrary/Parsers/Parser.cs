namespace TextProcessingLibrary.Parsers
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;

    using NLog;

    using TextProcessingLibrary.TextItems;
    using TextProcessingLibrary.TextItems.SentenceItems;

    public class Parser : IDisposable
    {
        private readonly Logger logger = LogManager.GetCurrentClassLogger();

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
                            sentence.Add(new Word(lineWord.ToString().ToList(), countOfString));
                            lineWord.Clear();
                            continue;
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
                            continue;
                    }
                }
                while (isEndOfFile);
            }
            catch (IOException e)
            {
                this.logger.Error(e.Message);
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

            foreach (var currentSymbol in stringWithSentence)
            {
                switch (currentSymbol)
                {
                    case '!':
                    case '?':
                    case '.':
                        sentence.Add(new Word(lineWord.ToString().ToList(), countOfString));
                        sentence.Add(new PunctuationMark(new List<char>() { currentSymbol }));
                        lineWord.Clear();
                        continue;
                    case ' ':
                        sentence.Add(new Word(lineWord.ToString().ToList(), countOfString));
                        lineWord.Clear();
                        continue;
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
                        continue;
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
