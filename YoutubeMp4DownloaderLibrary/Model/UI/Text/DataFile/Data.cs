using System.Threading.Tasks;
using YoutubeMp4DownloaderLibrary.Model.UI.Text.Interfaces;

namespace YoutubeMp4DownloaderLibrary.Model.UI.Text.DataFile
{
    //Класс, хранящий в себе надстройку над стратегией
    public class Data
    {
        //Инициализируем начальное значение
        public string SetInitial(IData data)
        {
            return data.SetInitialData();
        }

        //Получаем данные о видео
        public async Task<string> GetData(IData data, YoutubeExplode.Videos.Video video)
        {
            return data.GetData(video);
        }
    }
}
