using System;
using System.Collections.Generic;
using System.Text;

namespace MediaLibrary.src.MediaItems.Interfaces
{
    public interface IVideo : IAudio, IPhoto
    {
        void AddSub();
        void RemoveSub();
    }
}
