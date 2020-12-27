using System;
using System.Threading.Tasks;
using YoutubeExplode;
using YoutubeMp4DownloaderLibrary.Model.UI.Text.Interfaces;

namespace YoutubeMp4DownloaderLibrary.Model.UI.Text.DataFile
{
    public class Data
    {
        public string SetInitial(IData data)
        {
            return data.SetInitialData();
        }

        public async Task<string> GetData(IData data, YoutubeExplode.Videos.Video video)
        {
            return data.GetData(video);
        }
    }
}
