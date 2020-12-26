using System;
using VideoLibrary;
using YoutubeMp4DownloaderLibrary.Model.UI.Text.Interfaces;

namespace YoutubeMp4DownloaderLibrary.Model.UI.Text.DataFile
{
    public class DataName : IData
    {
        public string SetInitialData()
        {
            return "No data";
        }
        
        public string GetData(YouTubeVideo view)
        {
            return view.FullName.Replace(".mp4", "");
        }
    }
}
