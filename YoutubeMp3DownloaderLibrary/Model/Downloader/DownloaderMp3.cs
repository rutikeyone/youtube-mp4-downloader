using MediaToolkit;
using MediaToolkit.Model;
using System.IO;
using VideoLibrary;

namespace YoutubeMp3DownloaderLibrary.Model.Downloader
{
    public class DownloaderMp3
    {
        public void SaveMP3(string SaveToFolder, string VideoURL)
        {
            var source = @SaveToFolder;
            var youtube = YouTube.Default;
            var vid = youtube.GetVideo(VideoURL);
            File.WriteAllBytes(source + vid.FullName, vid.GetBytes());

            var inputFile = new MediaFile { Filename = source + vid.FullName };
            var outputFile = new MediaFile { Filename = $"{vid.FullName}.mp3" };

            using (var engine = new Engine())
            {
                engine.GetMetadata(inputFile);

                engine.Convert(inputFile, outputFile);
            }
        }
    }
}
