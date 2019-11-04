using MediaLibrary.MediaItems;
using MediaLibrary.src.MediaItems.Interfaces;
using System.Collections.Generic;

namespace MediaLibrary.src.MediaPlayer
{
    public class MediaPlayer : IMediaItem, IMediaPlayer
    {
        public List<Album> Albums { get; set; }
        public MediaPlayer(List<Album> albums){ }
        public MediaPlayer(){ }
        public void Open() { }
        public void Close() { }
        public void GetInfo() { }
        public void Play(MediaItem mediaItem) { }
        public void Play(Album album) { }
        public void AddMediaItem(MediaItem mediaItem, int idAlbum = 0) { }
        public void RemoveMediaItem(MediaItem mediaItem, int idAlbum = 0) { }
        public void AddAlbum(MediaItem mediaItem) { }
        public void RemoveAlbum(MediaItem mediaItem) { }

    }
}
