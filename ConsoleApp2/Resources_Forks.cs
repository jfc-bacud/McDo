using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    internal class Resources_Forks
    {
        public bool status = false;

        public bool CheckForks(Resources_Forks[] Forks, int diner)
        {
            switch (diner)
            {
                case 0:
                    if (!Forks[diner].status && !Forks[4].status)
                    {
                        Forks[diner].status = Forks[4].status = true;
                        return true;
                    }
                    break;
                case 1:
                case 2:
                case 3:
                case 4:
                    if (!Forks[diner].status && !Forks[diner - 1].status)
                    {
                        Forks[diner].status = Forks[diner - 1].status = true;
                        return true;
                    }
                    break;
            }
            return false;
        }

    }
}
