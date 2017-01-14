using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WithUsingDelegates
{
    public delegate bool IsPromotableDelegate(Employee emp);

    public class Employee
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int Salary { get; set; }
        public int Experince { get; set; }

        public static void promoteEmpl(List<Employee> empList, IsPromotableDelegate delIsPromotable)
        {
            foreach (Employee emp in empList)
            {
                if (delIsPromotable(emp))
                    Console.WriteLine(emp.Name + " is promoted - using delegates");
            }
        }
    }

    class TestEmpWithDelegate
    {
        public static void testEmpWithDelegate()
        {
            List<Employee> empList = new List<Employee>();
            empList.Add(new Employee { ID = 1, Name = "Abc", Experince = 3, Salary = 70000 });
            empList.Add(new Employee { ID = 2, Name = "Def", Experince = 4, Salary = 80000 });
            empList.Add(new Employee { ID = 3, Name = "Ghi", Experince = 5, Salary = 90000 });
            empList.Add(new Employee { ID = 4, Name = "Jkl", Experince = 6, Salary = 100000 });

            //IsPromotableDelegate isPromotableDelObj = new IsPromotableDelegate(isPromotable);

            //Employee.promoteEmpl(empList, isPromotableDelObj);

            //Lambda expressions are based on delegates
            Employee.promoteEmpl(empList, emp => emp.Experince >= 5); //emp will work on Employee object. You can name anything
        }

        public static bool isPromotable(Employee emp)
        {
            if (emp.Experince >= 5)
                return true;
            else
                return false;
        }
    }
}
