using System;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using SeveralViewsGui.Common;

namespace SeveralViewsGui.SubViews.ViewModels
{
    internal class SuccessfulViewModel : IChildViewModel
    {
        private Application _application;

        public SuccessfulViewModel( Application application, IMainViewModel mainViewModel )
        {
            MainViewModel = mainViewModel;
            _application = application;
            var action = new Action( async () =>
             {
                 await Task.Run( 
                     () => { Thread.Sleep( 3000 ); } );
                 application.Shutdown();
             } );
            action.Invoke();
        }

        public IMainViewModel MainViewModel { get; private set; }

        public event PropertyChangedEventHandler PropertyChanged;

        public void GotoViewModel( IViewModel viewModel )
        {
            MainViewModel.CurrentSubViewModel = viewModel;
        }
    }
}