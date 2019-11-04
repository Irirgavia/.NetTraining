using MediaLibrary.src.MediaItems.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MediaLibrary.MediaItems
{
    public class Photo : MediaItem, IPhoto
    {
        public Photo(
            int id,
            string name,
            double size,
            string type) : base(id, name, size, type) 
        { }
        public override void Open() { }
        public override void Close() { }
        public void Zoom() { }
        public void Rotate() { }
    }
}
