using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeveralViewsGui.Common
{
    public interface IChildViewModel : IViewModel
    {
        IMainViewModel MainViewModel { get; }
    }
}
