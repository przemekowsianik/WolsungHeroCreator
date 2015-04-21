using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace WolsungHeroCreator.UserControls
{
    class AttributeControl : LevelControl
    {
        public AttributeControl(): base()
        {

            progressBar.Foreground = Brushes.Crimson;
        }
    }
}
