using System;
using System.IO;
using System.Threading.Tasks;
using System.Windows;
using YoutubeExplode;
using YoutubeExplode.Videos.Streams;

namespace YoutubeMp4DownloaderLibrary.Model.Downloader
{
    public class DownloaderMp4
    {
        public event Action<string> Notifier;
        public async Task SaveMP4(string[] fileLines, string pathToSaveVideos)
        {
                Notifier?.Invoke("The download has started");
                var Client = new YoutubeClient();
                var StreamInfoSet = await Client.Videos.Streams.GetManifestAsync(fileLines[1]);
                var StreamInfo = StreamInfoSet.GetMuxed().WithHighestVideoQuality();
                await Client.Videos.Streams.DownloadAsync(StreamInfo, pathToSaveVideos + "\\" + fileLines[1] + ".mp4");
                Notifier?.Invoke("Download completed");
        

        }
    }
}
