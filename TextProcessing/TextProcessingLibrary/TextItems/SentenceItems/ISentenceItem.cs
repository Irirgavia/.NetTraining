namespace TextProcessingLibrary.TextItems.SentenceItems
{
    public interface ISentenceItem
    {
        void Add(char item);

        void Remove(char item);

        string ToString();
    }
}
