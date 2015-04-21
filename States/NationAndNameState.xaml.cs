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
    /// Interaction logic for NationAndNameState.xaml
    /// It's Singleton.
    /// </summary>
    public partial class NationAndNameState : UserControl, IState
    {
        private string stateFileURL = @"Assets/DataXML/NationAndNameStateData.xml";

        private static NationAndNameState instance;
        public static NationAndNameState GetInstance
        {
            get
            {
                if (instance == null)
                    instance = new NationAndNameState();

                return instance;
            }
        }

        public event EventHandler ExitState;




        private NationAndNameState()
        {
            InitializeComponent();
            textLabel.Content = XMLDataLoader.LoadStateTextData(stateFileURL, "NationAndNameStateData");
        }




        public void OnExitState(StringEventArgs e)
        {
            EventHandler exitState = ExitState;

            if (exitState != null)
                exitState(this, e);
        }


        private void nationListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ListBoxItem item = (ListBoxItem)nationListBox.SelectedItem;

            describeTextBox.Text = XMLDataLoader.LoadStateTextData(stateFileURL, "NationAndNameStateData", "NationData", item.Content.ToString());
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (nameBox.Text == string.Empty || nationListBox.SelectedItem == null)
            {
                Console.WriteLine("Musisz wypełnić cały formularz");
            }
            else
            {
                MessageBoxResult result = System.Windows.MessageBoxResult.No;
                result = MessageBox.Show("Czy na pewno twoje imię to "+nameBox.Text+" ?", "Nie słyszałem o kimś takim...", System.Windows.MessageBoxButton.YesNo);

                if(result == System.Windows.MessageBoxResult.Yes)
                {
                    ListBoxItem item = (ListBoxItem)nationListBox.SelectedItem;

                    StringEventArgs eventArgs = new StringEventArgs(item.Content.ToString(), nameBox.Text);
                    OnExitState(eventArgs);

                    StateManager.GetInstance.ChangeState(ArchetypeState.GetInstance);
                }
            }
                
        }
    }
}
