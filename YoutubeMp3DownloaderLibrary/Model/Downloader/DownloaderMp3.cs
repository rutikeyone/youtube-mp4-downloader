using MediaToolkit;
using MediaToolkit.Model;
using System.IO;
using System.Threading.Tasks;
using System.Windows;
using VideoLibrary;
using YoutubeMp3DownloaderLibrary.Model.Downloader.PartsDownloader;

namespace YoutubeMp3DownloaderLibrary.Model.Downloader
{
    public class DownloaderMp3
    {
        private CustomEngine CustomEngine;

        public DownloaderMp3()
        {
            CustomEngine = new();
        }
        //I will make this method async
        public void SaveMP3(string saveToFolder, string videoURL)
        {
                var youtube = YouTube.Default;

                //Получаем видео
                var view = youtube.GetVideo(videoURL);
                //Комбинируем путь видео
                string videoPath = Path.Combine(saveToFolder, view.FullName);
                //Получаем байты
                File.WriteAllBytes(videoPath, view.GetBytes());

                //Получаем Mp3
                CustomEngine.GetMp3(saveToFolder, view);

                //Удаляем видео
                File.Delete(Path.Combine(saveToFolder, view.FullName));
        }
    }
}
