namespace TextProcessingLibrary.TextItems
{
    using System.Collections.Generic;

    public interface IText
    {
        string Title { get; set; }

        List<IParagraph> Paragraphs { get; set; }

        void Add(IParagraph newParagraph);

        void Remove(IParagraph removedParagraph);

        string ToString();
    }
}
