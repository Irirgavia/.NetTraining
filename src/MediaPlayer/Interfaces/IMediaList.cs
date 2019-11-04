using MediaLibrary.MediaItems;

namespace MediaLibrary.src.MediaPlayer.Interfaces
{
    public interface IMediaList
    {
        void Count();
        void Next();
        void Previus();
        void Pause();
        void Stop();
        void GetAllItems();
        void AddItem(MediaItem mediaItem);
        void RemoveItem(MediaItem mediaItem);
        void Find(MediaItem mediaItem);
        void Sort();
    }
}
