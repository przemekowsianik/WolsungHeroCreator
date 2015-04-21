using System;
using System.Windows.Controls;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WolsungHeroCreator.UserControls
{
    class SkillControl : LevelControl
    {
        private string skillsFileURL = @"DataXML/SkillsStateData.xml";
        private bool isTipLoaded = false;

        private TextBox specialBox;
        public string Specialization
        {
            get
            {
                if (specialBox != null)
                    Specialization = specialBox.Text;

                return specialBox.Text;
            }
            private set
            {

            }
        }

        public SkillControl(): base()
        {
            progressBar.Foreground = System.Windows.Media.Brushes.Blue;
            progressBar.Height = 30;
            progressBar.Value = 33;

            specialBox = new TextBox();
            specialBox.Width = 230;
            specialBox.Visibility = System.Windows.Visibility.Visible;
            specialBox.Margin = new System.Windows.Thickness(20, 0, 0, 0);
            specialBox.IsEnabled = false;
            specialBox.VerticalAlignment = System.Windows.VerticalAlignment.Center;
            panelStack.Children.Add(specialBox);
        }



        protected override void plusButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            if (Level < 2 && PointsToLeveling.DecreasePointsForSkills())
            {
                progressBar.Value += 33;
                Level += 1;
            }
            else if(Level == 2 && PointsToLeveling.DecreasePointsForSpecialisations())
            {
                progressBar.Value += 33;
                Level += 1;
                progressBar.Foreground = System.Windows.Media.Brushes.BlanchedAlmond;
                specialBox.IsEnabled = true;
            }
        }

        protected override void minusButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            if (Level > 1 && Level < 3 && PointsToLeveling.IncreasePointsForSkills())
            {
                progressBar.Value -= 33;
                Level -= 1;
            }
            else if(Level == 3 && PointsToLeveling.IncreasePointsForSpecialisations())
            {
                progressBar.Value -= 33;
                Level -= 1;
                progressBar.Foreground = System.Windows.Media.Brushes.Blue;
                specialBox.IsEnabled = false;
            }
        }

        protected override void mainGrid_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {
            if (!isTipLoaded)
                mainGrid.ToolTip = XMLDataLoader.LoadStateTextData(skillsFileURL, "StateTextData", "SkillData", LevelName);

            isTipLoaded = true;
        }

    }
}
