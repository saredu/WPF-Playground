using System.ComponentModel;
using System.Windows;
using SeveralViewsGui.Common;
using SeveralViewsGui.SubViews.ViewModels;

namespace SeveralViewsGui
{
    // todo: create a base view model
    internal class MainViewModel : IMainViewModel
    {
        private IViewModel _currentViewModel;

        public event PropertyChangedEventHandler PropertyChanged = (s, e) => { };

        public MainViewModel(Application app)
        {
            GotoViewModel( new InstallationPromptViewModel( app, this ) );
        }
     
        public IViewModel CurrentSubViewModel
        {
            get
            {
                return _currentViewModel;
            }
            set
            {
                if ( _currentViewModel == value )
                {
                    return;
                }
                _currentViewModel = value;
                PropertyChanged( this, new PropertyChangedEventArgs( nameof( CurrentSubViewModel ) ) );
            }
        }

        public void GotoViewModel( IViewModel viewModel )
        {
            CurrentSubViewModel = viewModel;
        }
    }
}
