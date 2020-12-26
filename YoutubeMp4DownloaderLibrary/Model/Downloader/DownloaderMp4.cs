using System;
using System.IO;
using VideoLibrary;
using YoutubeMp4DownloaderLibrary.Model.Downloader.PartsDownloader;

namespace YoutubeMp4DownloaderLibrary.Model.Downloader
{
    public class DownloaderMp4
    {
        public event Action<string> Notifier;
        private CustomEngine CustomEngine;

        public DownloaderMp4()
        {
            CustomEngine = new();
        }
        //I will make this method async
        public void SaveMP3(string saveToFolder, YouTubeVideo view)
        {
                Notifier?.Invoke("The download has started");
                //Комбинируем путь видео
                string videoPath = Path.Combine(saveToFolder, view.FullName);
                //Получаем байты
                File.WriteAllBytes(videoPath, view.GetBytes());

                Notifier?.Invoke("Download completed");
        

        }
    }
}
