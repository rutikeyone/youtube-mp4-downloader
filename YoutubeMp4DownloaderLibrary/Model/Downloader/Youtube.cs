using System;
using YoutubeExplode;

namespace YoutubeMp4DownloaderLibrary.Model.Downloader
{
    public class Youtube
    {
        const string YoutubeTagSignature = "?v=";
        public string[] GetLine(string url)
        {
            YoutubeClient Client = new YoutubeClient();
            string[] FileLines = url.Split(new string[] { YoutubeTagSignature }, StringSplitOptions.None);
            return FileLines;
        }
    }
}
