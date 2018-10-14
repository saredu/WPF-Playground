using System;
using System.Windows.Input;

namespace SeveralViewsGui.Common
{
    public class ActionCommand : ICommand
    {
        private readonly Action<object> _executeAction;
        private readonly Predicate<object> _canExecuteAction;

        public event EventHandler CanExecuteChanged;

        public ActionCommand(Action<object> executeAction ) : this(executeAction, o => { return true; } )
        {
        }

        public ActionCommand(Action<object> executeAction, Predicate<object> canExecuteAction )
        {
            _executeAction = executeAction;
            _canExecuteAction = canExecuteAction;
        }

        public bool CanExecute( object parameter )
        {
            return _canExecuteAction( parameter );
        }

        public void Execute( object parameter )
        {
            _executeAction( parameter );
        }
    }
}
