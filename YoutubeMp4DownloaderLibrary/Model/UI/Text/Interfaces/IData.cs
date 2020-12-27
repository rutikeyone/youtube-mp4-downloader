namespace YoutubeMp4DownloaderLibrary.Model.UI.Text.Interfaces
{
    //Интерфейс для классов реализующих паттерн стратегия и содержищих в себе логику вывода данных о видео
    public interface IData
    {
        string SetInitialData();
        string GetData(YoutubeExplode.Videos.Video video);
    }
}
