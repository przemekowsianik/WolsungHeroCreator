using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WolsungHeroCreator
{
    /// <summary>
    /// This is for control which is main control in program (ex. MainWindow).
    /// </summary>
    interface INavigator
    {
        void Navigate(IState state);
        void ExitApp();
    }
}
