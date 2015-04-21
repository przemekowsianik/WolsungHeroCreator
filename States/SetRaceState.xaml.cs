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
using System.Text.RegularExpressions;

namespace WolsungHeroCreator.States
{
    /// <summary>
    /// Interaction logic for SetRaceState.xaml
    /// It's Singleton.
    /// </summary>
    public partial class SetRaceState : UserControl, IState
    {
        private static SetRaceState instance;
        public static SetRaceState GetInstance
        {
            get
            {
                if (instance == null)
                    instance = new SetRaceState();

                return instance;
            }
        }

        public event EventHandler ExitState;




        private SetRaceState()
        {
            InitializeComponent();
            textLabel.Content = XMLDataLoader.LoadStateTextData(@"Assets/DataXML/SetRaceStateData.xml", "StateTextData");
        }




        public void OnExitState(StringEventArgs e)
        {
            EventHandler exitState = ExitState;
            if (exitState != null)
                exitState(this, e);
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ListBoxItem item = (ListBoxItem)raceListBox.SelectedItem;
            try
            {
                OnExitState(new StringEventArgs(item.Content.ToString()));

                StateManager.GetInstance.ChangeState(NationAndNameState.GetInstance);
            }
            catch(NullReferenceException)
            {
                Console.WriteLine("Musisz zaznaczyć pozycję z listy.");
            }
            
        }

        private void raceListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ListBoxItem item = (ListBoxItem)raceListBox.SelectedItem;

            describeTextBox.Text = XMLDataLoader.LoadStateTextData(@"DataXML/SetRaceStateData.xml","StateTextData","RaceData",item.Content.ToString());
        }
    }
}
