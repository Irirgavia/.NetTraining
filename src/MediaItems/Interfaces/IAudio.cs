using System;
using System.Collections.Generic;
using System.Text;

namespace MediaLibrary.src.MediaItems.Interfaces
{
    public interface IAudio: IMediaItem
    {
        void Pause();
        void Speed();
        void SpeedChange();
    }
}
