using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    internal class Process_Diners
    {
        public string name = "Diner";
        public bool status = false;
        public int countdown;
        public int cooldown;

        public void ToAct()
        {
            countdown = Static.rnd.Next(1, 6);

        }

        public void ToRest()
        {
            cooldown = Static.rnd.Next(1, 6);
        }

        // Status of Diners
        // Turns
        // Cooldown Timer

    }
}
