using System;
using YoutubeMp3DownloaderLibrary.Model;

namespace YoutubeMp3DownloaderLibrary.ViewModel
{
    public class MainViewModel
    {
        private Sing Sing;
        public string SingText { get; set; }

        public MainViewModel()
        {
            Sing = new();
            SingText = Sing.GetInitial();
        }
    }
}
