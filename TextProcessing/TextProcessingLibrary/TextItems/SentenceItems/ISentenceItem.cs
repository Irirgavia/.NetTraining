namespace TextProcessingLibrary.TextItems.SentenceItems
{
    using System.Collections.Generic;

    public interface ISentenceItem
    {
        List<char> Symbols { get; set; }

        void Add(char item);

        void Remove(char item);

        string ToString();
    }
}
