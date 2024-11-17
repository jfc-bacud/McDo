using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace ConsoleApp2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CPU_Table Table = new CPU_Table();
            Table.Generate();
            int dinerTurn = 0;

            Console.WriteLine("============ DINER'S ALGORITHM ============ ");

            while (true)
            {
                dinerTurn = Table.DinerTurn(dinerTurn);
                Thread.Sleep(1000);
                
                if (dinerTurn == 5)
                {
                    dinerTurn = Table.CycleEnd(dinerTurn);
                }
            }
        }
    }
}
