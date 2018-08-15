using System;
using System.Threading.Tasks;

namespace ConsoleDemos
{
    class Program
    {
        static void method1() { Singleton m1 = Singleton.GetInstance; m1.PrintDetails("M1"); }
        static void method2() { Singleton m2 = Singleton.GetInstance; m2.PrintDetails("M2"); }

        static void Main(string[] args)
        {
            // BasicSingleton instance = BasicSingleton.GetInstance;
            // instance.PrintDetails("Hello Ashish");

            // Seal Singleton class to avoid creation of objects with nested classes
            /* BasicSingleton.Derived derived = new BasicSingleton.Derived();
            derived.PrintDetails("From derived"); */

            // BasicSingleton code without lock is not thread safe. If we run below code 2 instances are still created in absence of lock
            Parallel.Invoke(
                    () => Program.method1(),
                    () => Program.method2()
                    );            

            Console.Read();
        }        
    }
}
