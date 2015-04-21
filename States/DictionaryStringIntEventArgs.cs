using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WolsungHeroCreator.States
{
    public class DictionaryStringIntEventArgs : EventArgs
    {
        public Dictionary<String, int> args { get; private set; }


        public DictionaryStringIntEventArgs(Dictionary<String, int> dictionary)
        {
            args = dictionary;
        }
    }
}
