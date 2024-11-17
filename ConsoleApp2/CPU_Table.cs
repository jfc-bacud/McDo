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
                Forks[i] = new Resources_Forks();
            }
        }
        public int DinerTurn(int dinerTurn)
        {
            AttemptToActivate(dinerTurn);
            dinerTurn++;

            return dinerTurn;
        }

        public int CycleEnd (int dinerTurn)
        {
            dinerTurn = 0;
            CheckDinerState();
            Console.Clear();
            Console.WriteLine("============ DINER'S ALGORITHM ============ ");

            return dinerTurn;
        }

        private void CheckDinerState()
        {
            for (int i = 0; i < 5; i++) 
            {
                if (Diners[i].status == 1) 
                {
                    if (Diners[i].countdown > 0)
                    {
                        Diners[i].countdown--;

                        if (Diners[i].countdown == 0)
                        {
                            Diners[i].ToRest(Forks, i);
                        }
                    }
                } 
                else if (Diners[i].status == 0) 
                {
                    if (Diners[i].cooldown > 0)
                    {
                        Diners[i].cooldown--;

                        if (Diners[i].cooldown == 0)
                        {
                            Diners[i].ResetDiner();
                        }
                    }
                }
            }
        }

        private void DinerChecker(int diner)
        {
            if (Diners[diner].status == 0)
            {
                Console.WriteLine($"\nDiner {diner + 1} is resting! ({Diners[diner].cooldown} cycles left)");
            }
            else if (Diners[diner].status == 1)
            {
                Console.WriteLine($"\nDiner {diner + 1} is still eating! ({Diners[diner].countdown} cycles left)");
            }
        }

        private void AttemptToActivate(int dinerTurn)
        {
            if (Diners[dinerTurn].status == -1)
            {
                if (Forks[dinerTurn].CheckForks(Forks, dinerTurn))
                {
                    Diners[dinerTurn].ToAct(dinerTurn);
                }
                else
                {
                    Console.WriteLine($"\nDiner {dinerTurn + 1} is ready but failed to activate!");
                }
            }
            else if (Diners[dinerTurn].status == 0 || Diners[dinerTurn].status == 1)
            {
                DinerChecker(dinerTurn);
            }
        }
    }
}
