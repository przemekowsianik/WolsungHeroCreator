using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WolsungHeroCreator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INavigator
    {
        private StateManager stateManager;
        private HeroLayer.Hero hero = new HeroLayer.Hero();


        public MainWindow()
        {
            InitializeComponent();

            stateManager = StateManager.GetInstance;
            stateManager.Navigator = this;

            stateManager.ChangeState(WolsungHeroCreator.States.HelloState.GetInstance);
        }




        public void Navigate(IState state)
        {   
            if(state is UserControl)
            {
                this.Content = state as UserControl;
            }
        }

        public void ExitApp()
        {
            this.Close();
        }

    }
}
