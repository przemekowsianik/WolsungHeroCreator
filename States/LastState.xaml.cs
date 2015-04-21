using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

namespace WolsungHeroCreator.States
{
    /// <summary>
    /// Interaction logic for LastState.xaml
    /// </summary>
    public partial class LastState : UserControl, IState
    {
        private static LastState instance;
        public static LastState GetInstance
        {
            get
            {
                if (instance == null)
                    instance = new LastState();

                return instance;
            }
        }




        private LastState()
        {
            InitializeComponent();

            textLabel.Content = XMLDataLoader.LoadStateTextData(@"Assets/DataXML/LastStateData.xml", "StateTextData");
        }




        private void Button_Click(object sender, RoutedEventArgs e)
        {
            StateManager.GetInstance.ExitApplication();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            StateManager.GetInstance.ChangeState(HelloState.GetInstance);
        }
    }
}
