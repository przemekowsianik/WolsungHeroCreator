using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WolsungHeroCreator.HeroLayer
{
    public class Skill
    {
        private int level;
        private string name;
        private string specialisation;



        public Skill(string name, int level, string special = "")
        {
            this.level = level;
            this.name = name;

            if (level > 2)
                specialisation = special;
            else
                specialisation = string.Empty;
        }




        public int GetLevel()
        {
            return level;
        }

        public string GetSpecialisation()
        {
            if (specialisation == string.Empty)
                return ".......................................";

            return specialisation;
        }

        public override string ToString()
        {
            if(specialisation != string.Empty)
                return name + ":\t" + level + "\t- \t" + specialisation;
            else
                return name + ":\t" + level + "\t- \t............................";
        }
    }
}
