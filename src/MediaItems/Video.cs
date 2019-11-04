using MediaLibrary.src.MediaItems.Interfaces;

namespace MediaLibrary.MediaItems
{
    public class Video : MediaItem, IVideo
    {
        public Video(
            int id,
            string name,
            double size,
            string type) : base(id, name, size, type)
        { }

        public override void Open() { }
        public override void Close() { }
        public void Zoom() { }
        public void Rotate() { }
        public void Pause() { }
        public void Speed() { }
        public void SpeedChange() { }
        public void AddSub() { }
        public void RemoveSub() { }
    }
}