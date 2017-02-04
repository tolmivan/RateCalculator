using RateCalculator.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RateCalculator.UI.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            DateTime entryTime;
            DateTime exitTime;

            System.Console.WriteLine("Please enter entry time:");
            string entry = System.Console.ReadLine();

            System.Console.WriteLine("Please enter exit time:");
            string exit = System.Console.ReadLine();

            if(entry == "" || exit == "")
            {
                entryTime = DateTime.Now;
                exitTime = DateTime.Now.AddDays(1);
            }
            else
            {
                entryTime = Convert.ToDateTime(entry);
                exitTime = Convert.ToDateTime(exit);

            }


            ClientOne client1 = new ClientOne();

            System.Console.WriteLine(client1.Calculate(entryTime, exitTime));


            ClientTwo client2 = new ClientTwo();

            System.Console.WriteLine(client2.Calculate(entryTime, exitTime));


            System.Console.ReadLine();
        }
    }
}
