using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace YoutubeMp4DownloaderLibrary.ViewModel.Base
{
    //Базовая ViewModel которая определяет метод, необходимый для обновления полей и свойст, работающих с текстовыми Ui
    public class BaseViewModel : INotifyPropertyChanged
    {
        //Метод для проверки и установки значений 
        protected bool SetProperty<T>(ref T field, T value, string property = null)
        {
            if (EqualityComparer<T>.Default.Equals(field, value))
                return false;
            field = value;
            OnPropertyChanged(property);
            return true;
        }

        //Реализуем INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string property = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }
    }
}
