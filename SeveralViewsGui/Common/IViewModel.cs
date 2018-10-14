using System.ComponentModel;

namespace SeveralViewsGui.Common
{
    public interface IViewModel : INotifyPropertyChanged
    {
        void GotoViewModel( IViewModel viewModel );
    }
}
