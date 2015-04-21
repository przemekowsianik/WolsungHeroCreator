using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
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

namespace WolsungHeroCreator.UserControls
{
    public partial class LevelControl : UserControl
    {
        public int Level { get; protected set; }

        private string levelName;
        public string LevelName
        {
            get
            {
                return levelName;
            }
            set
            {
                levelName = value;
                levelLabel.Content = levelName;
            }
        }




        public LevelControl()
        {
            InitializeComponent();

            Level = 1;
            LevelName = "AttributeName";
        }




        protected virtual void plusButton_Click(object sender, RoutedEventArgs e)
        {
            if (Level < 3 &&  PointsToLeveling.DecreasePointsForAttributes())
            {
                progressBar.Value += 33;
                Level += 1;
            }
        }

        protected virtual void minusButton_Click(object sender, RoutedEventArgs e)
        {
            if (Level > 1 && PointsToLeveling.IncreasePointsForAttributes())
            {
                progressBar.Value -= 33;
                Level -= 1;
            }
        }



        protected  virtual void mainGrid_MouseEnter(object sender, MouseEventArgs e)
        {
            //Without implementation in base class.
        }


    }
}