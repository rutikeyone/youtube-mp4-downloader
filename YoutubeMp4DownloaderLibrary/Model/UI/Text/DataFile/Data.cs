using System;
using VideoLibrary;
using YoutubeMp4DownloaderLibrary.Model.UI.Text.Interfaces;

namespace YoutubeMp4DownloaderLibrary.Model.UI.Text.DataFile
{
    public class Data
    {
        public string SetInitial(IData data)
        {
            return data.SetInitialData();
        }

        public string GetData(IData data, YouTubeVideo view)
        {
            return data.GetData(view);
        }
    }
}
