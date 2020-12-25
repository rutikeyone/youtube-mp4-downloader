using System;
using System.IO;
using MediaToolkit;
using MediaToolkit.Model;
using VideoLibrary;

namespace YoutubeMp3DownloaderLibrary.Model.Downloader.PartsDownloader
{
    public class CustomEngine
    {
        public void GetMp3(string saveToFolder, YouTubeVideo view)
        {
            var inputFile = new MediaFile { Filename = Path.Combine(saveToFolder, view.FullName) };
            var outputFile = new MediaFile { Filename = Path.Combine(saveToFolder, $"{view.FullName}.mp3") };

            using (var engine = new Engine())
            {
                engine.GetMetadata(inputFile);


                engine.Convert(inputFile, outputFile);
            }

        }
    }
}
