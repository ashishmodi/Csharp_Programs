using System;

namespace BasicStuff
{
    class WhileDoWhileDemo
    {
        /*Input : Enter your target --> 10
        Output : 0 2 4 6 8 10 
        Do you still want to continue Yes or No */
        public void processDoWhile()
        {
            string sChoice = "";
            do
            {
                Console.WriteLine("Enter your target");
                int iTarget = int.Parse(Console.ReadLine());

                int iStart = 0;
                while (iStart <= iTarget)
                {
                    Console.WriteLine(iStart + " ");
                    iStart = iStart + 2;
                }

                do
                {
                    Console.WriteLine("\nDo you still want to continue - Yes or No ");
                    sChoice = Console.ReadLine();
                } while (sChoice != "Yes" && sChoice != "No");

            } while (sChoice != "No");
        }
    }
}
