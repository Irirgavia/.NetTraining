using MediaLibrary.MediaItems;

namespace MediaLibrary.src.MediaPlayer
{
    interface IMediaPlayer
    {
        void Play(MediaItem mediaItem);
        void Play(Album album);
        void AddMediaItem(MediaItem mediaItem, int idAlbum = 0);
        void RemoveMediaItem(MediaItem mediaItem, int idAlbum = 0);
        void AddAlbum(MediaItem mediaItem);
        void RemoveAlbum(MediaItem mediaItem);
    }
}
