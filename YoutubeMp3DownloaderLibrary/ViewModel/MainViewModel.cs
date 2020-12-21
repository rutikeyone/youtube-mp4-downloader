using System;
using YoutubeMp3DownloaderLibrary.Model;
using YoutubeMp3DownloaderLibrary.Model.UI;

namespace YoutubeMp3DownloaderLibrary.ViewModel
{
    public class MainViewModel
    {
        private UIClose Close;
        private Sing Sing;
        public string SingText { get; set; }

        public MainViewModel()
        {
            Sing = new();
            Close = new();
            SingText = Sing.GetInitial();
        }



    }
}
