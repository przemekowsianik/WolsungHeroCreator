using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace WolsungHeroCreator
{
    /// <summary>
    /// StateManager is responsible for managing user's controls.
    /// Desing pattern: Singleton
    /// </summary>
    class StateManager
    {
        //Fields:
        private bool isSetSwichable = false;

        private static StateManager instance;
        public static StateManager GetInstance
        {
            get
            {
                if (instance == null)
                {
                    instance = new StateManager();
                }

                return instance;
            }
        }

        private INavigator navigator;
        /// <summary>
        /// It's property which set owner of Content property.
        /// </summary>
        public INavigator Navigator
        {
            set
            {
                if(!isSetSwichable)
                {
                    navigator = value;
                    isSetSwichable = true;
                }
            }
        }



        //Constructor:
        private StateManager()
        {
        }




        //Methods:
        public void ChangeState(IState state)
        {
            if(isSetSwichable)
               navigator.Navigate(state);
        }


        public void ExitApplication()
        {
            navigator.ExitApp();
        }
    }
}
