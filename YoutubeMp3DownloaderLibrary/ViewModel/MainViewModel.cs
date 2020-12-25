using GalaSoft.MvvmLight.Command;
using System.Windows;
using System.Windows.Input;
using YoutubeMp3DownloaderLibrary.Model;
using YoutubeMp3DownloaderLibrary.Model.Commands;
using YoutubeMp3DownloaderLibrary.Model.Dialogs;
using YoutubeMp3DownloaderLibrary.Model.Downloader;
using YoutubeMp3DownloaderLibrary.Model.UI;
using YoutubeMp3DownloaderLibrary.Model.UI.Text;
using YoutubeMp3DownloaderLibrary.Model.UI.Text.DataFile;
using YoutubeMp3DownloaderLibrary.Model.UI.Text.Abstract;
using YoutubeMp3DownloaderLibrary.ViewModel.Base;

namespace YoutubeMp3DownloaderLibrary.ViewModel
{
    public class MainViewModel : BaseViewModel
    {
        #region UI objects

        private UIClose Close;
        private UIText Sing;
        private Data Data;
        private Dialog Dialog;
        private UIText State;
        private DownloaderMp3 Downloader;

        #endregion

        #region UI text

        #region UI Sing text
        private string singText = null;
        public string SingText
        {
            get => singText;
            set => SetProperty(ref singText, value);
        }
        #endregion

        #region UI Name file
        private string nameFile = null;
        public string NameFile
        {
            get => nameFile;
            set => SetProperty(ref nameFile, value);
        }

        #endregion

        #region UI Speed

        private string speedInternet = null;
        public string SpeedInternet
        {
            get => speedInternet;
            set => SetProperty(ref speedInternet, value);
        }

        #endregion

        #region UI Size

        private string sizeFile = null;
        public string SizeFile
        {
            get => sizeFile;
            set => SetProperty(ref sizeFile, value);
        }

        #endregion

        #region UI Url

        private string url = null;
        public string Url
        {
            get => url;
            set => SetProperty(ref url, value);
        }

        #endregion

        #region UI Folder

        private string stateFolder = null;
        public string StateFolder
        {
            get => stateFolder;
            set => SetProperty(ref stateFolder, value);
        }

        #endregion

        #region UI path

        private string path = null;
        public string Path
        {
            get => path;
            set => SetProperty(ref path, value);
        }

        #endregion


        #endregion

        #region Close command
        public RelayCommand<Window> CloseMainWindow { get; private set; }

        public void CloseWindow(Window window)
        {
            if (window != null)
            {
                window.Close();
            }
        }

        #endregion

        #region Select command

        public ICommand Select { get; set; }

        public bool CanSelectExecute(object sender) => true;

        public void SelectExecute(object sender)
        {
            Path = Dialog.GetFolder();
        }

        #endregion

        #region Download command

        public ICommand Download { get; set; }

        public bool CanDownloadExecute(object sender) => !string.IsNullOrWhiteSpace(Url) && Path != "Вы не выбрали папку" && !string.IsNullOrWhiteSpace(Path);
        /*
         Если мы во время загрузки мы получим исключение то значит ссылка на видео некорректна 
         уведомим об этом загружающего

         */
        public void DownloadExecute(object sender)
        {
            try
            {
                Downloader.SaveMP3(Path, Url);
            }

            catch
            {
                SingText = Sing.GetError("Введите корректный адрес ссылки"); 
            }
        }

        #endregion

        #region Constructor
        public MainViewModel()
        {
            //Initial UI objects
            Sing = new Sing();
            Close = new();
            Data = new();
            Dialog = new();
            State = new StateFolder();
            Downloader = new();

            //Initial UI text
            SingText = Sing.GetInitial("Вставьте ссылку и нажмите на кнопку для начала загрузки видео");
            NameFile = Data.GetInitial(new DataName());
            SpeedInternet = Data.GetInitial(new DataSpeed());
            SizeFile = Data.GetInitial(new DataSize());
            StateFolder = State.GetInitial("Для начала загрузки видео выберите папку загрузки");

            //Initial Command
            CloseMainWindow = new RelayCommand<Window>(this.CloseWindow);
            Download = new ActionCommand(DownloadExecute, CanDownloadExecute);
            Select = new ActionCommand(SelectExecute, CanSelectExecute);
        }

        #endregion

    }
}
