using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WolsungHeroCreator.States
{
    public class StringEventArgs : EventArgs
    {
        public string StringArg { get; private set; }
        public string StringArg1 { get; private set; }


        //constructors:
        public StringEventArgs(string strArg)
        {
            this.StringArg = strArg;
        }

        public StringEventArgs(string strArg, string strArg1)
        {
            this.StringArg = strArg;
            this.StringArg1 = strArg1;
        }
    }
}
