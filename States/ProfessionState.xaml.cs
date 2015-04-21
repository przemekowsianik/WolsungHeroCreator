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
    /// Interaction logic for ProfessionState.xaml
    /// </summary>
    public partial class ProfessionState : UserControl, IState
    {
        private string stateFileURL = @"Assets/DataXML/ProfessionStateData.xml";

        private static ProfessionState instance;
        public static ProfessionState GetInstance
        {
            get
            {
                if (instance == null)
                    instance = new ProfessionState();

                return instance;
            }
        }

        public event EventHandler<StringEventArgs> ExitState;




        private ProfessionState()
        {
            InitializeComponent();

            textLabel.Content = XMLDataLoader.LoadStateTextData(stateFileURL, "StateTextData");
        }



        
        private void OnExitState(StringEventArgs eventArg)
        {
            EventHandler<StringEventArgs> exitState = ExitState;

            if (exitState != null)
                exitState(this, eventArg);
        }


        private void professionListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ListBoxItem item = (ListBoxItem)professionListBox.SelectedItem;

            describeTextBox.Text = XMLDataLoader.LoadStateTextData(stateFileURL, "StateTextData", "ProfessionData", item.Content.ToString());
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ListBoxItem item = (ListBoxItem)professionListBox.SelectedItem;
            describeTextBox.Text = XMLDataLoader.LoadStateTextData(stateFileURL, "StateTextData", "ProfessionData", item.Content.ToString());


            OnExitState(new StringEventArgs(item.Content.ToString()));

            StateManager.GetInstance.ChangeState(AttributeState.GetInstance);
        }  
    }
}
