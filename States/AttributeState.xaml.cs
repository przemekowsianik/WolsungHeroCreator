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
    /// Interaction logic for AttributeState.xaml
    /// </summary>
    public partial class AttributeState : UserControl, IState
    {
        private string stateFileURL = @"Assets/DataXML/AttributeStateData.xml";

        private static AttributeState instance;
        public static AttributeState GetInstance
        {
            get
            {
                if (instance == null)
                    instance = new AttributeState();

                return instance;
            }
        }

        public event EventHandler<DictionaryStringIntEventArgs> ExitState;





        private AttributeState()
        {
            InitializeComponent();

            textLabel.Content = XMLDataLoader.LoadStateTextData(stateFileURL, "AttributeStateData");
        }





        private Dictionary<string,int> GetAttributesValues()
        {
            Dictionary<string, int> attributesValues = new Dictionary<string, int>
            {
                {"Strength", strenghtControl.Level},
                {"Agility", agilityControl.Level},
                {"Perception", perceptionControl.Level},
                {"Composure", composureControl.Level},
                {"Charisma", charismaControl.Level},
            };


            return attributesValues;
        }


        private void OnExitState(Dictionary<string, int> dictr)
        {
            EventHandler<DictionaryStringIntEventArgs> exitState = ExitState;
            if (exitState != null)
                exitState(this, new DictionaryStringIntEventArgs(dictr));
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            OnExitState(GetAttributesValues());
            StateManager.GetInstance.ChangeState(SkillsState.GetInstance);
        }
    }
}
