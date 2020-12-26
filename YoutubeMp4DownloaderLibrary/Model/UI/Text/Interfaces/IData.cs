using System;
using VideoLibrary;

namespace YoutubeMp4DownloaderLibrary.Model.UI.Text.Interfaces
{
    public interface IData
    {
        string SetInitialData();
        string GetData(YouTubeVideo view);
    }
}
