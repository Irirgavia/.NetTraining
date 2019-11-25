namespace TextProcessingLibrary
{
    using System;
    using System.IO;
    using System.Text;

    using TextProcessingLibrary.TextItems;

    public static class Parser
    {
        public static Text MadeText(TextReader textReader, string textTitle)
        {
            Text text = new Text(textTitle);
            try
            {
                StringBuilder lineWord = new StringBuilder();
                int countOfString = 1;

                Paragraph paragraph = new Paragraph();
                Sentence sentence = new Sentence();

                bool isEndOfFile = true;

                do
                {
                    int symb = textReader.Read();
                    if (symb == -1)
                    {
                        isEndOfFile = false;
                    }

                    char currentSymbol = (char)symb;

                    switch (currentSymbol)
                    {
                        case '\r':
                            continue;
                        case '\n':
                        case '\t':
                            countOfString++;
                            text.AddParagraph(paragraph);
                            paragraph = new Paragraph();
                            sentence = new Sentence();
                            continue;
                        case '!':
                        case '?':
                        case '.':
                            sentence.AddWord(new Word(lineWord.ToString(), currentSymbol, countOfString));
                            paragraph.AddSentence(sentence);
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
                            sentence.AddWord(new Word(lineWord.ToString(), currentSymbol, countOfString));
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
            }

            return text;
        }
    }
}
