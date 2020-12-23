using Microsoft.WindowsAPICodePack.Dialogs;

namespace YoutubeMp3DownloaderLibrary.Model.Dialogs
{
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
            return "No folder selected";
        }
    }
    }
