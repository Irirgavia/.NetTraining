namespace TextProcessingLibrary.TextItems.SentenceItems
{
    using System.Collections.Generic;

    public interface ISentence
    {
        List<ISentenceItem> SentenceItems { get; set; }

        char Separator { get; set; }

        SentenceType GetSentenceType();

        void Add(ISentenceItem sentenceItem);

        void Remove(ISentenceItem sentenceItem);

        string ToString();
    }
}
