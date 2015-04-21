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
    /// Interaction logic for ArchetypeState.xaml
    /// It's singleton.
    /// </summary>
    public partial class ArchetypeState : UserControl, IState
    {
        private string stateFileURL = @"Assets/DataXML/ArchetypeStateData.xml";

        private static ArchetypeState instance;
        public static ArchetypeState GetInstance
        {
            get
            {
                if (instance == null)
                    instance = new ArchetypeState();

                return instance;
            }
        }

        private string archetype;

        public event EventHandler<StringEventArgs> ExitState;




        private ArchetypeState()
        {
            InitializeComponent();

            textLabel.Content = XMLDataLoader.LoadStateTextData(stateFileURL, "ArchetypeStateData");
        }




        public void OnExitState(StringEventArgs e)
        {
            EventHandler<StringEventArgs> exitState = ExitState;
            if (exitState != null)
                exitState(this, e);
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if((bool)explorerRadio.IsChecked || (bool)riskyRadio.IsChecked || (bool)saloonRadio.IsChecked || (bool)detectiveRadio.IsChecked)
            {
                OnExitState(new StringEventArgs(archetype));
                StateManager.GetInstance.ChangeState(ProfessionState.GetInstance);
            }
 
        }


        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            RadioButton radioB = sender as RadioButton;
            archetype = radioB.Content as String;
        }

        private void RadioButton_Checked_1(object sender, RoutedEventArgs e)
        {
            RadioButton radioB = sender as RadioButton;
            archetype = radioB.Content as String;
        }

        private void RadioButton_Checked_2(object sender, RoutedEventArgs e)
        {
            RadioButton radioB = sender as RadioButton;
            archetype = radioB.Content as String;
        }

        private void RadioButton_Checked_3(object sender, RoutedEventArgs e)
        {
            RadioButton radioB = sender as RadioButton;
            archetype = radioB.Content as String;
        }
    }
}
