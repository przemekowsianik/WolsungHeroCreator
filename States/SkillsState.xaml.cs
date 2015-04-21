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
    /// Interaction logic for SkillsState.xaml
    /// </summary>
    public partial class SkillsState : UserControl, IState
    {
        private string stateFileURL = @"Assets/DataXML/SkillsStateData.xml";

        private static SkillsState instance;
        public static SkillsState GetInstance
        {
            get
            {
                if (instance == null)
                    instance = new SkillsState();

                return instance;
            }
        }

        public event EventHandler<DictionaryStringSkillEventArgs> ExitState;





        private SkillsState()
        {
            InitializeComponent();

            textLabel.Content = XMLDataLoader.LoadStateTextData(stateFileURL, "StateTextData");
        }





        private Dictionary<string,HeroLayer.Skill> GetSkillsValues()
        {
            Dictionary<string, HeroLayer.Skill> skills = new Dictionary<string, HeroLayer.Skill>();

            foreach(UserControls.SkillControl skillControl in skillsListBox.Items)
            {
                skills.Add(skillControl.LevelName,new HeroLayer.Skill(skillControl.LevelName,skillControl.Level,skillControl.Specialization) );
            }

            return skills;
        }


        private void OnExitState(Dictionary<string,HeroLayer.Skill> dictr)
        {
            EventHandler<DictionaryStringSkillEventArgs> exitState = ExitState;
            if (exitState != null)
                exitState(this, new DictionaryStringSkillEventArgs(dictr));
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            OnExitState(GetSkillsValues());

            StateManager.GetInstance.ChangeState(LastState.GetInstance);
        }

    }
}
