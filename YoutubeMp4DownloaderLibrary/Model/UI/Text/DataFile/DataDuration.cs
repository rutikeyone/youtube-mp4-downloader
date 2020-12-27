using YoutubeMp4DownloaderLibrary.Model.UI.Text.Interfaces;

namespace YoutubeMp4DownloaderLibrary.Model.UI.Text.DataFile
{
    public class DataDuration : IData
    {
        public string SetInitialData()
        {
            return "No data";
        }

        public string GetData(YoutubeExplode.Videos.Video video)
        {
            return video.Duration.ToString();
        }


    }
}
