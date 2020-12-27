using Microsoft.WindowsAPICodePack.Dialogs;

namespace YoutubeMp4DownloaderLibrary.Model.Dialogs
{
    //Класс, реализующий логику выбора папки
    public class Dialog
    {
        public string GetFolder()
        {
            CommonOpenFileDialog CommonDialog = new CommonOpenFileDialog();
            CommonDialog.IsFolderPicker = true;
            switch (CommonDialog.ShowDialog())
            {
                case CommonFileDialogResult.Ok:
                    return CommonDialog.FileName;
            }
            return "No selected folder";
        }
    }
    }
