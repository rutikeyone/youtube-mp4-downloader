using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YoutubeMp3DownloaderLibrary.Model.UI.Text.Abstract
{
    public abstract class UIText
    {
        public string GetInitial(string message)
        {
            return message;
        }
        public string GetError(string error)
        {
            return error;
        }
    }
}
