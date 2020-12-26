using VideoLibrary;

namespace YoutubeMp4DownloaderLibrary.Model.Downloader
{
    public class Youtube
    {
        public YouTubeVideo GetVideo(string url)
        {
            return YouTube.Default.GetVideo(url);
        }
    }
}
