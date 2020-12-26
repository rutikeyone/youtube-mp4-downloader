using GalaSoft.MvvmLight.Command;
using System.Windows;
using System.Windows.Input;
using YoutubeMp4DownloaderLibrary.Model;
using YoutubeMp4DownloaderLibrary.Model.Commands;
using YoutubeMp4DownloaderLibrary.Model.Dialogs;
using YoutubeMp4DownloaderLibrary.Model.Downloader;
using YoutubeMp4DownloaderLibrary.Model.UI;
using YoutubeMp4DownloaderLibrary.Model.UI.Text;
using YoutubeMp4DownloaderLibrary.Model.UI.Text.DataFile;
using YoutubeMp4DownloaderLibrary.Model.UI.Text.Abstract;
using YoutubeMp4DownloaderLibrary.ViewModel.Base;
using System.Threading.Tasks;
using VideoLibrary;

namespace YoutubeMp4DownloaderLibrary.ViewModel
{
    public partial class MainViewModel : BaseViewModel
    {
        private Youtube Youtube;
        private YouTubeVideo View;

        #region UI objects

        private UIClose Close;
        private UIText Sing;
        private Data Data;
        private Dialog Dialog;
        private UIText State;
        private DownloaderMp4 Downloader;

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

        public bool CanDownloadExecute(object sender) => !string.IsNullOrWhiteSpace(Url) && Path != "No selected folder" && !string.IsNullOrWhiteSpace(Path);
        /*
         Если мы во время загрузки мы получим исключение то значит ссылка на видео некорректна 
         уведомим об этом загружающего

         */
        public async void DownloadExecute(object sender)
        {
            await Task.Run(() =>
            {
                try
                {
                    View = Youtube.GetVideo(Url);
                    NameFile = Data.GetData(new DataName(), View);
                    SizeFile = Data.GetData(new DataSize(), View);
                    Downloader.SaveMP3(Path, View);
                }

                catch
                {
                    SingText = Sing.SetData("Enter the correct link address");
                }
            });
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
            Youtube = new();

            //Initial UI text
            SingText = Sing.SetData("Paste the link and click on the button to start downloading the video");
            NameFile = Data.SetInitial(new DataName());
            SizeFile = Data.SetInitial(new DataSize());
            StateFolder = State.SetData("To start downloading the video, select the download folder");

            //Initial Command
            CloseMainWindow = new RelayCommand<Window>(this.CloseWindow);
            Download = new ActionCommand(DownloadExecute, CanDownloadExecute);
            Select = new ActionCommand(SelectExecute, CanSelectExecute);

            Downloader.Notifier += SetValueSingText;
        }

        #endregion

    }
}
