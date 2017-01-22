using System;
using System.Reflection;

namespace Reflection
{
    class ReflectionMain
    {
        static void Main(string[] args)
        {
            //3 ways to get the type
            //1. Type t = Type.GetType("Reflection.Customer");
            //2. If you have object than 
            //Customer c = new Customer();
            //Type t = c.GetType();
            //3. Using typeof
            Type t = typeof(Customer);
            
            Console.WriteLine("Properties in {0} are :", t.Name);
            PropertyInfo[] properties = t.GetProperties();
            foreach (PropertyInfo property in properties)
            {
                Console.WriteLine(property.PropertyType.Name + " " + property.Name);
            }

            Console.WriteLine("Constructors in {0} are :", t.Name);
            ConstructorInfo[] constructors = t.GetConstructors();
            foreach (ConstructorInfo constructor in constructors)
            {
                Console.WriteLine(constructor.ToString());
            }

            Console.WriteLine("Methods in {0} are :", t.Name);
            MethodInfo[] methods = t.GetMethods();
            foreach (MethodInfo method in methods)
            {
                Console.Write(method.ReturnType.Name + " " + method.Name + " ");
                ParameterInfo[] parameters = method.GetParameters();
                foreach (ParameterInfo parameter in parameters)
                {
                    Console.Write(parameter.ParameterType.Name + " " + parameter.Position + " ");
                }
                Console.WriteLine();
            }

            //Late binding testing
            Console.WriteLine();
            Console.WriteLine("**********************");
            LateBindingDemo.testLateBinding();
        }
    }
}
