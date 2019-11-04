using MediaLibrary.src.MediaItems.Interfaces;

namespace MediaLibrary.MediaItems
{
    public abstract class MediaItem : IMediaItem
    {
        public int Id { get; private set; }
        public string Name { get; set; }
        public double Size { get; private set; }
        public string Type { get; private set; }

        public MediaItem(
            int id,
            string name,
            double size,
            string type)
        { }

        public virtual void Open() { }
        public virtual void Close() { }
        public void GetInfo() {}
    }
}
