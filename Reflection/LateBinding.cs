using System;
using System.Reflection;

namespace Reflection
{
    class LateBindingDemo
    {
        public static void testLateBinding()
        {
            try
            {
                Assembly executingAssembly = Assembly.GetExecutingAssembly();
                Type type = executingAssembly.GetType("Reflection.Person");
                MethodInfo method = type.GetMethod("getFullName");

                string[] parameters = new string[2];
                parameters[0] = "Ashish";
                parameters[1] = "Modi";

                object instance = Activator.CreateInstance(type);
                string fullName = (string)method.Invoke(instance, parameters);
                Console.WriteLine("Full name is " + fullName);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }        
    }

    class Person
    {
        public string getFullName(string first, string last)
        {
            return first + " " + last;
        }
    }
}
