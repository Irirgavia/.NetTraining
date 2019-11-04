using System;
using System.Collections.Generic;
using System.Text;

namespace MediaLibrary.src.MediaItems.Interfaces
{
    public interface IMediaItem
    {
        void Open();
        void Close();
        void GetInfo();
    }
}
