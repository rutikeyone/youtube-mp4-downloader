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
using YoutubeExplode;

namespace YoutubeMp4DownloaderLibrary.ViewModel
{
    //Данный класс определяет view model для главного окна
    public partial class MainViewModel : BaseViewModel
    {
        //Список объектов используемых в MainViewMode
        #region Objects

        private UIClose Close { get; set; } //Объект для закрытия окна
        private UIText Sing { get; set; } //Объект для установки значения текстового UI (текстовый бокс под ссылкой на видео)
        private Data Data { get; set; } //Объект являющийся клиентом для паттерна стратегия
        private Dialog Dialog { get; set; } //Объект для выбора папки
        private UIText State { get; set; } //Объект для установки значения текстового UI (текстовый бокс под путем на папку)
        private DownloaderMp4 Downloader { get; set; } //Основной объект-загрузчик видео
        
        //Данные свойства необходимы для обработки загрузки видео
        private Youtube Youtube { get; set; } //Объект необходим для получения валидного id видео
        private YoutubeClient Client { get; set; } //Объект необходим для загрузки видео
        private string[] FileLines { get; set; } //Массив необходим для работы загрузчика видео
        private YoutubeExplode.Videos.Video Video { get; set; } //Переменная для хранения видео

        #endregion

        //Поля и свойства необходимые для установки значения в текстовых Ui в MainWindow
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

        #region UI Duraction

        private string durationVideo = null;
        public string DurationVideo
        {
            get => durationVideo;
            set => SetProperty(ref durationVideo, value);
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

        #region UI Author

        private string authorVideo = null;
        public string AuthorVideo
        {
            get => authorVideo;
            set => SetProperty(ref authorVideo, value);
        }

        #endregion


        #endregion

        //Комманды взаимодействия Ui с кодом
        #region Commands

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

        //Если путь до папки установлен и ссылка на видео есть, кнопку загрузки можно нажать
        public bool CanDownloadExecute(object sender) => !string.IsNullOrWhiteSpace(Url) && Path != "No selected folder" && !string.IsNullOrWhiteSpace(Path);

        //Данный метод описывает логику загрузки видео
        public async void DownloadExecute(object sender)
        {
            await Task.Run(() =>
            {
                try
                {
                    FileLines = Youtube.GetLine(Url); //Получаем id видео
                    Downloader.SaveMP4(FileLines, Path); //Загружаем видео
                    
                    //Получаем информация о видео
                    Video = Client.Videos.GetAsync(Url).Result;
                    NameFile = Data.GetData(new DataName(), Video).Result;
                    DurationVideo = Data.GetData(new DataDuration(), Video).Result;
                    AuthorVideo = Data.GetData(new DataAuthor(), Video).Result;
                }

                //Если есть исключение, то выводим информацию о том что ссылка некорректна 
                catch
                {
                    SingText = Sing.SetData("Enter the correct link address");
                }
            });
        }

        #endregion

        #endregion

        //Обычный конструктор без параметров
        #region Constructor
        public MainViewModel()
        {
            //Инициализируем объекты
            Sing = new Sing();
            Close = new();
            Data = new();
            Dialog = new();
            State = new StateFolder();
            Downloader = new();
            Youtube = new();
            Client = new();

            //Задаем базовое значение текстовых Ui 
            SingText = Sing.SetData("Paste the link and click on the button to start downloading the video");
            NameFile = Data.SetInitial(new DataName());
            DurationVideo = Data.SetInitial(new DataDuration());
            AuthorVideo = Data.SetInitial(new DataAuthor());
            StateFolder = State.SetData("To start downloading the video, select the download folder");

            //Инициализируем команды
            CloseMainWindow = new RelayCommand<Window>(this.CloseWindow);
            Download = new ActionCommand(DownloadExecute, CanDownloadExecute);
            Select = new ActionCommand(SelectExecute, CanSelectExecute);

            //Добавляем подписчика для события
            Downloader.Notifier += SetValueSingText;
        }

        #endregion
        
        /*Данный метод устанавливает значение для текстового Ui, я не могу его вынести из MainViewModel 
         * поскольку мне нужно работать с Ui*/
        public void SetValueSingText(string message)
        {
            SingText = message;
        }
    }
}
