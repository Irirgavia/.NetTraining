namespace TextProcessingLibrary.TextItems
{
    using System.Collections.Generic;

    using TextProcessingLibrary.TextItems.SentenceItems;

    public interface IParagraph
    {
        List<ISentence> Sentences { get; set; }

        string RedLine { get; set; }

        void Add(ISentence newSentence);

        void Remove(ISentence removedSentence);

        string ToString();
    }
}
