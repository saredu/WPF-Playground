using System;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using SeveralViewsGui.Common;

namespace SeveralViewsGui.SubViews.ViewModels
{
    public class ProgressViewModel : IChildViewModel, IExecutable
    {
        private readonly Application _application;

        public event PropertyChangedEventHandler PropertyChanged;
        
        public ProgressViewModel( Application application, IMainViewModel mainViewModel )
        {
            MainViewModel = mainViewModel;
            _application = application;
        }

        public IMainViewModel MainViewModel { get; private set; }

        public async void Execute()
        {
            try
            {
                await Task.WhenAll( JustYouWaitMrHiggins(), JustYouWaitMrHigginsJustALitteBitLonger() );
                GotoViewModel( new SuccessfulViewModel( _application, MainViewModel ) );
            }
            catch (Exception exception)
            {
                GotoViewModel( new ErrorOccuredViewModel( _application, MainViewModel, exception ) );
            }
        }

        private static async Task JustYouWaitMrHiggins()
        {
            await Task.Run( () =>
            {
                Thread.Sleep( 1500 );
            } );
        }

        private static async Task JustYouWaitMrHigginsJustALitteBitLonger()
        {
            await Task.Run( () =>
            {
                Thread.Sleep( 3700 );
                var random = new Random();
                if ( random.Next() % 2 == 0 )
                {
                    throw new ArgumentException( "Oh no!" );
                }
            } );
        }

        public void GotoViewModel( IViewModel viewModel )
        {
            MainViewModel.CurrentSubViewModel = viewModel;
        }
    }
}
