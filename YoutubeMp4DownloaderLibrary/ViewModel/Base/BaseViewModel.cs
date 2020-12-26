using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace YoutubeMp4DownloaderLibrary.ViewModel.Base
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        protected bool SetProperty<T>(ref T field, T value, string property = null)
        {
            if (EqualityComparer<T>.Default.Equals(field, value))
                return false;
            field = value;
            OnPropertyChanged(property);
            return true;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string property = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }
    }
}
