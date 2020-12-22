using System;
using YoutubeMp3DownloaderLibrary.Model.UI.Text.Interfaces;

namespace YoutubeMp3DownloaderLibrary.Model.UI.Text.DataFile
{
    public class Data
    {
        public string GetInitial(IData data)
        {
            return data.GetInitialData();
        }
    }
}
