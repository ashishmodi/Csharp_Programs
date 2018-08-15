using System;

namespace ConsoleDemos
{
    sealed class Singleton
    {
        private static int counter = 0;
        private static Singleton instance = null;
        private static readonly Object obj = new Object();

        public static Singleton GetInstance
        {
            get
            {
                // double checking lock
                if (instance == null)
                {
                    lock (obj)
                    {
                        if (instance == null)   // Lazy initialization
                            instance = new Singleton();
                    }
                }   
                return instance;
            }
        }

        // For a non-lazy or eager loading, do the following:
        // 1. Initialize instance as below instead of null: private static readonly Singleton instance = new Singleton()
        // 2. Change GetInstance to return just instance
        // 3. CLR takes care of variable initialization and thread safety. So we don't need to do anything in this case.

        // Another way to create a Lazy instance
        // 1. Lazy<Singleton> lazyInstance = new Lazy<Singleton>(() => new Singleton());
        // 2. Change GetInstance to return just lazyInstance.Value

        private Singleton()
        {
            ++counter;
            Console.WriteLine("No of instances = " + counter);
        }

        public void PrintDetails(string sMessage) { Console.WriteLine(sMessage); }
        
        // public class Derived : BasicSingleton { }
    }
}
