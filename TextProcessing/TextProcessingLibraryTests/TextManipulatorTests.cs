using Microsoft.VisualStudio.TestTools.UnitTesting;
using TextProcessingLibrary;

namespace TextProcessingLibrary.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using TextProcessingLibrary;
    using TextProcessingLibrary.TextItems;
    using TextProcessingLibrary.TextItems.SentenceItems;

    [TestClass]
    public class TextManipulatorTests
    {
        private IText text;

        private IParagraph paragraph1;

        private IParagraph paragraph2;

        private ISentence sentence1;

        private ISentence sentence2;

        private ISentence sentence3;

        private Word wordIs;

        private Word wordIt;

        private Word wordThe;

        private Word wordSentence;

        [TestInitialize]
        public void Initialize()
        {
            this.wordIs = new Word(new List<char>() { 'i', 's' });
            this.wordIt = new Word(new List<char>() { 'I', 't' });
            this.wordThe = new Word(new List<char>() { 't', 'h', 'e' });
            this.wordSentence = new Word(new List<char>() { 's', 'e', 'n', 't', 'e', 'n', 'c', 'e' });

            this.sentence1 = new Sentence(
                new List<ISentenceItem>()
                    {
                        this.wordIt,
                        this.wordIs,
                        this.wordThe,
                        new Word(new List<char>() { 'f', 'i', 'r', 's', 't' }),
                        this.wordSentence,
                        new PunctuationMark(new List<char>() { '.' })
                    },
                ' ');

            this.sentence2 = new Sentence(
                new List<ISentenceItem>()
                    {
                        this.wordIt,
                        this.wordIs,
                        new Word(new List<char>() { 'a', 'l', 's', 'o' }),
                        this.wordSentence,
                        new PunctuationMark(new List<char>() { '.' })
                    },
                ' ');

            this.sentence3 = new Sentence(
                new List<ISentenceItem>()
                    {
                        this.wordIs,
                        this.wordIt,
                        this.wordSentence,
                        new PunctuationMark(new List<char>() { '?' })
                    },
                ' ');

            this.paragraph1 = new Paragraph(new List<ISentence>() { this.sentence1, this.sentence2 });
            this.paragraph2 = new Paragraph(new List<ISentence>() { this.sentence3 });

            this.text = new Text(new List<IParagraph>() { this.paragraph1, this.paragraph2 });
        }

        [TestMethod]
        public void GetSortedSentencesByWordsCountTest()
        {
            var expectedSentences = new List<ISentence>() { this.sentence3, this.sentence2, this.sentence1 };
            Assert.AreEqual(
                expectedSentences.ToString(),
                TextProcessingLibrary.TextManipulator.GetSortedSentencesByWordsCount(this.text).ToList().ToString());
        }

        [TestMethod]
        public void GetWordsFromInterrogativeSentencesTest()
        {
            var expectedSentenceItems = new List<ISentenceItem>() { this.sentence3.SentenceItems[0], this.sentence3.SentenceItems[1] };
            Assert.AreEqual(
                expectedSentenceItems.ToString(),
                TextProcessingLibrary.TextManipulator.GetWordsFromInterrogativeSentences(this.text, 2).ToList().ToString());
        }

        [TestMethod]
        public void GetParagraphsWithoutWordsWithSymbolOnIndexTest()
        {
            var word1 = new Word(new List<char>() { 'I', 't' });
            var word2 = new Word(new List<char>() { 'i', 's' });

            this.paragraph1.Sentences[0].Remove(word1);
            this.paragraph1.Sentences[0].Remove(word2);
            this.paragraph1.Sentences[1].Remove(word1);
            this.paragraph1.Sentences[1].Remove(word2);

            this.paragraph2.Sentences[0].Remove(word1);
            this.paragraph2.Sentences[0].Remove(word2);

            var expectedParagraphs = new List<IParagraph>() { this.paragraph1, this.paragraph2 };
            Assert.AreEqual(
                expectedParagraphs.ToString(),
                TextProcessingLibrary.TextManipulator.GetParagraphsWithoutWordsWithSymbolOnIndex(this.text, 2, 0, 'i').ToList().ToString());
        }

        [TestMethod]
        public void ReplaceWordsWithSubstringTest()
        {
            var expectedSentence = new Sentence(
                new List<ISentenceItem>()
                    {
                        new Word(new List<char>() { 'x', 'x', 'x' }),
                        new Word(new List<char>() { 'x', 'x', 'x' }),
                        new Word(new List<char>() { 'y', 'y' }),
                        new PunctuationMark(new List<char>() { '.' })
                    },
                ' ');

            var sentence = new Sentence(
                new List<ISentenceItem>()
                    {
                        new Word(new List<char>() { 'a', 'a', 'a' }),
                        new Word(new List<char>() { 'y', 'y' }),
                        new PunctuationMark(new List<char>() { '.' })
                    },
                ' ');

            Assert.AreEqual(
                expectedSentence.ToString(),
                TextProcessingLibrary.TextManipulator.ReplaceWordsWithSubstring(sentence, 3, "xxx xxx").ToString());
        }
    }
}