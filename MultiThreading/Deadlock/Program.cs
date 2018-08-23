using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DeadlockDemos
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Main started");

            Account a = new Account(101, 10000);
            Account b = new Account(102, 15000);

            AccountManager amA = new AccountManager(a, b, 2500);
            // Thread t1 = new Thread(amA.Transfer_with_Deadlock);
            Thread t1 = new Thread(amA.Transfer_without_Deadlock);
            t1.Name = "T1";

            AccountManager amB = new AccountManager(b, a, 500);
            // Thread t2 = new Thread(amB.Transfer_with_Deadlock);
            Thread t2 = new Thread(amB.Transfer_without_Deadlock);
            t2.Name = "T2";

            t1.Start();
            t2.Start();
            t1.Join();
            t2.Join();
                        
            Console.WriteLine("Main completed");
            Console.Read();
        }
    }
}
