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
        public int status = -1;
        public int countdown;
        public int cooldown;

        public void ToAct(int diner)
        {
            status = 1;
            cooldown = 0;
            countdown = Static.rnd.Next(1, 6);
            Console.WriteLine($"\nDiner {diner + 1} has started eating! ({countdown} cycles left)");    
        }

        public void ToRest(Resources_Forks[] Forks, int diner)
        {
            if (diner == 0)
            {
                Forks[diner].status = Forks[4].status = false;
            }
            else
            {
                Forks[diner].status = Forks[diner - 1].status = false;
            }

            status = 0;
            countdown = 0;
            cooldown = Static.rnd.Next(1, 6);
        }

        public void ResetDiner()
        {
            status = -1;
            countdown = 0;
            cooldown = 0;
        }
    }
}
