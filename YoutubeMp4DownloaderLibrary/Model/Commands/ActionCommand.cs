using System;
using YoutubeMp4DownloaderLibrary.Model.Commands.Base;

namespace YoutubeMp4DownloaderLibrary.Model.Commands
{
    //Класс, реализующий абстрактный класс команды
    public class ActionCommand : Command
    {
        private readonly Action<object> _Execute;
        private readonly Func<object, bool> _CanExecute;

        public override bool CanExecute(object parameter) => _CanExecute?.Invoke(parameter) ?? true;

        public override void Execute(object parameter) => _Execute?.Invoke(parameter);

        public ActionCommand(Action<object> execute, Func<object, bool> canExecute)
        {
            _Execute = execute ?? throw new ArgumentNullException(nameof(execute));
            _CanExecute = canExecute;
        }
    }
}
