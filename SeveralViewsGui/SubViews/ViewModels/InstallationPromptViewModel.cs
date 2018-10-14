using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;
using SeveralViewsGui.Common;

namespace SeveralViewsGui.SubViews.ViewModels
{
    internal class InstallationPromptViewModel : IChildViewModel
    {
        private readonly Application _application;

        // not in use atm
        public event PropertyChangedEventHandler PropertyChanged = (s, e) => { };

        public InstallationPromptViewModel( Application app, IMainViewModel mainViewModel )
        {
            _application = app;
            MainViewModel = mainViewModel;

            ExitCommand = new ActionCommand( o => { app.Shutdown(); } );
            ContinueCommand = new ActionCommand( o => 
            {
                var progressViewModel = new ProgressViewModel( app, mainViewModel );
                GotoViewModel( progressViewModel );
                ( (IExecutable)progressViewModel ).Execute();
            } );
        }

        public IMainViewModel MainViewModel { get; private set; }

        public ICommand ExitCommand { get; private set; }

        public ICommand ContinueCommand { get; private set; }

        public void GotoViewModel( IViewModel viewModel )
        {
            MainViewModel.CurrentSubViewModel = viewModel;
        }
    }
}
