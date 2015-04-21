using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WolsungHeroCreator.States
{
    public class DictionaryStringSkillEventArgs : EventArgs
    {
        public Dictionary<String, HeroLayer.Skill> args { get; private set; }


        public DictionaryStringSkillEventArgs(Dictionary<String, HeroLayer.Skill> dictionary)
        {
            args = dictionary;
        }
    }
}
