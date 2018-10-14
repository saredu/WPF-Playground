namespace SeveralViewsGui.Common
{
    public interface IMainViewModel : IViewModel
    {
        IViewModel CurrentSubViewModel { get; set; }
    }
}
