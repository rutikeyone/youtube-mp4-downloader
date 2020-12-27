using YoutubeMp4DownloaderLibrary.Model.UI.Text.Interfaces;

namespace YoutubeMp4DownloaderLibrary.Model.UI.Text.DataFile
{
    //Класс отвечающий за данные о авторе
    public class DataAuthor : IData
    {
        public string SetInitialData()
        {
            return "No data";
        }

        public string GetData(YoutubeExplode.Videos.Video video)
        {
            return video.Author;
        }
    }
}
