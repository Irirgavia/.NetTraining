using System;
using System.Collections.Generic;
using System.Text;

namespace MediaLibrary.src.MediaItems.Interfaces
{
    public interface IPhoto: IMediaItem
    {
        void Zoom();
        void Rotate();

    }
}
