using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Globals
{
    public static class DiceManager
    {
        public static GameObject CurrentSelectedDice;
        private static int lastValueRolled;

        public static int LastValueRolled
        {
            get
            {
                return lastValueRolled;
            }
            set
            {
                lastValueRolled = value;

            }
        }      
    }
}
