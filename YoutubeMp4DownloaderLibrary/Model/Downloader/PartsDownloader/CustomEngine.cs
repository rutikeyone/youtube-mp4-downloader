using System.IO;
using MediaToolkit;
using MediaToolkit.Model;
using VideoLibrary;

namespace YoutubeMp4DownloaderLibrary.Model.Downloader.PartsDownloader
{
    public class CustomEngine
    {
        public void GetMp4(string saveToFolder, YouTubeVideo view)
        {
            var inputFile = new MediaFile { Filename = Path.Combine(saveToFolder, view.FullName) };

            using (var engine = new Engine())
            {
                engine.GetMetadata(inputFile);
            }

        }
    }
}
