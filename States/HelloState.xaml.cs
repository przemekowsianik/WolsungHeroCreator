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
    /// Interaction logic for HelloState.xaml
    /// </summary>
    public partial class HelloState : UserControl, IState
    {
        private static HelloState instance;
        public static HelloState GetInstance
        {
            get
            {
                if (instance == null)
                    instance = new HelloState();

                return instance;
            }
        }



        private HelloState()
        {
            InitializeComponent();
            textLabel.Content = XMLDataLoader.LoadStateTextData(@"Assets/DataXML/HelloStateData.xml", "StateTextData");
        }




        private void Button_Click(object sender, RoutedEventArgs e)
        {
            StateManager.GetInstance.ChangeState(SetRaceState.GetInstance);
        }
    }
}
