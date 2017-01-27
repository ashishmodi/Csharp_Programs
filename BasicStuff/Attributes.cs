using System;
using System.Collections.Generic;

namespace BasicStuff
{
    class AttributesDemo
    {
        public static void testAttributes()
        {
            Calculator.add(10, 20); //Obsolete warning

            /*List<int> numbers = new List<int>();
            numbers.Add(10);
            numbers.Add(20);
            int sum = Calculator.add(numbers);*/

            //another way of calling add
            int sum = Calculator.add(new List<int>() { 10, 20 });
            Console.WriteLine("Sum = {0}", sum);
        }
    }

    class Calculator
    {
        //Obsolete or use ObsoleteAttribute
        [Obsolete("Use add(List<int> numbers)")] //If we pass true than there will be error not warning
        public static int add(int a, int b)
        {
            return a + b;
        }
        
        //If we want to add 20 no's than?
        public static int add(List<int> numbers)
        {
            int sum = 0;
            foreach(int no in numbers)
            {
                sum = sum + no;
            }
            return sum;
        }
    }
}
