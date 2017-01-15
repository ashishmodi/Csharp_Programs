using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicStuff
{
    public enum eGender 
    {
        Unknown,
        Male,
        Female
    }

    class Emp
    {
        public string Name { get; set; }
        public eGender Gender { get; set; }
    }

    public class TestEnum
    {
        #region methods
        public static void testEnum()
        {
            Emp[] e = new Emp[3];
            e[0] = new Emp { Name = "ABC", Gender = eGender.Male };
            e[1] = new Emp { Name = "DEF", Gender = eGender.Female };
            e[2] = new Emp { Name = "GHI", Gender = eGender.Unknown };

            foreach(Emp employee in e)
            {
                Console.WriteLine("Name = " + employee.Name + " Gender = " + getGender(employee.Gender));
            }

            //GetNames() and GetValues() eg
            int[] values = (int[])Enum.GetValues(typeof(eGender));
            foreach (int value in values)
            {
                Console.WriteLine(value);
            }

            string[] names = Enum.GetNames(typeof(eGender));
            foreach (string name in names)
            {
                Console.WriteLine(name);
            }
        }

        public static string getGender(eGender gender)
        {
            switch (gender)
            {
                case eGender.Unknown:
                    return "Unknown";
                case eGender.Male:
                    return "Male";
                case eGender.Female:
                    return "Female";
                default:
                    return "Invalid input";
            }
        }
        #endregion
    }
}
