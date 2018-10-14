using System;
using System.ComponentModel;
using System.Windows;
using SeveralViewsGui.Common;

namespace SeveralViewsGui.SubViews.ViewModels
{
    internal class ErrorOccuredViewModel : IChildViewModel
    {
        private Application _application;
        private readonly Exception _exception;

        public ErrorOccuredViewModel( Application application, IMainViewModel mainViewModel, Exception exception )
        {
            MainViewModel = mainViewModel;
            _application = application;
            _exception = exception;
        }

        public IMainViewModel MainViewModel { get; private set; }

        public string ErrorText { get { return _exception.Message.ToString(); } }

        public event PropertyChangedEventHandler PropertyChanged;

        public void GotoViewModel( IViewModel viewModel )
        {
            MainViewModel.CurrentSubViewModel = viewModel;
        }
    }
}