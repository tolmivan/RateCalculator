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

            System.Console.WriteLine("Please enter entry date/time e.g. 03/02/2017 23:00:00, press Enter to accept default");
            string entry = System.Console.ReadLine();

            System.Console.WriteLine("Please enter exit date/time e.g. 04/02/2017 5:00:00, press Enter to accept default");
            string exit = System.Console.ReadLine(); 

            if(entry == "" || exit == "")
            {
                entryTime = Convert.ToDateTime("03/02/2017 23:00:00");
                exitTime = Convert.ToDateTime("04/02/2017 5:00:00");
            }
            else
            {
                entryTime = Convert.ToDateTime(entry);
                exitTime = Convert.ToDateTime(exit);

            }

            System.Console.WriteLine("Entry Time:{0}", entryTime);
            System.Console.WriteLine("Exit Time:{0}", exitTime);


            ClientOne client1 = new ClientOne();

            System.Console.WriteLine(client1.Calculate(entryTime, exitTime));


            ClientTwo client2 = new ClientTwo();

            System.Console.WriteLine(client2.Calculate(entryTime, exitTime));


            System.Console.ReadLine();
        }
    }
}
