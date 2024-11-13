using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    internal class CPU_Table
    {
        Process_Diners[] Diners = new Process_Diners[5];
        Resources_Forks[] Forks = new Resources_Forks[5];

        public void Generate()
        {
            for (int i = 0; i < 5; i++)
            {
                Diners[i] = new Process_Diners();
                Diners[i].name += i.ToString();
                Console.WriteLine($"{Diners[i].name}");
                Forks[i] = new Resources_Forks();
            }
        }

        public void EndCycleCheck()
        {
            for (int i = 0; i < 5; i++)
            {
                if (Diners[i].status)
                {
                    if (Diners[i].countdown > 0)
                    {
                        Diners[i].cooldown--;
                    }
                }
                else
                {
                    if (Diners[i].cooldown > 0)
                    {
                        Diners[i].cooldown--;
                    }
                }
            }
        }

        private bool CheckForks(int diner)
        {
            switch(diner)
            {
                case 0:
                    if ((Forks[0].status && Forks[1].status == true) 
                        || (Forks[0].status && Forks[4].status == true))
                        return true;
                    return false;             
                case 1:
                    if ((Forks[1].status && Forks[2].status == true) 
                        || (Forks[1].status && Forks[0].status == true))
                        return true;
                    return false;
                case 2:
                    if ((Forks[2].status && Forks[1].status == true) 
                        || (Forks[2].status && Forks[3].status == true))
                        return true;
                    return false;
                case 3:
                    if ((Forks[3].status && Forks[2].status == true) 
                        || (Forks[3].status && Forks[4].status == true))
                        return true;
                    return false;
                case 4:
                    if ((Forks[4].status && Forks[3].status == true) 
                        || (Forks[4].status && Forks[0].status == true))
                        return true;
                    return false;

                default: return false;
            }
        }

        public void AttemptToActivate()
        {
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine($"{Diners[i]} is trying to activate!");
                if (CheckForks(i))
                {
                    Diners[i].ToAct();
                }
            }
        }


    }
}
