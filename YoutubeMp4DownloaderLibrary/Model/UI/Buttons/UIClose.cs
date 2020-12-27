using System;
using System.Windows;

namespace YoutubeMp4DownloaderLibrary.Model.UI
{
    //Класс реализующий логику закрытия окна
    public class UIClose
    {
        public void Close()
        {
            Application.Current.Shutdown();
        }
    }
}
