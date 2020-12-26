using System;
using System.IO;
using VideoLibrary;
using YoutubeMp4DownloaderLibrary.Model.UI.Text.Interfaces;

namespace YoutubeMp4DownloaderLibrary.Model.UI.Text.DataFile
{
    public class DataSize : IData
    {
        public string SetInitialData()
        {
            return "No data";
        }

        //Получаем размер в килобайтах
        public string GetData(YouTubeVideo view)
        {
            return (view.ContentLength / 1024).ToString() + " Kb";
        }


    }
}
