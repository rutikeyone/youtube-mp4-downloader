using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace YoutubeMp4DownloaderLibrary.Model.UI.Text.Abstract
{
    //Абстрактный класс для Ui отвечающих за уведомление пользователя
    public abstract class UIText
    {
        public string SetData(string message)
        {
            return message;
        }
    }
}
