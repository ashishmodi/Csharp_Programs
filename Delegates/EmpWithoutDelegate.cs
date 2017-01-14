using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WithoutUsingDelegates
{
    class Employee
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int Salary { get; set; }
        public int Experince { get; set; }

        public static void promoteEmpl(List<Employee> empList)
        {
            foreach(Employee emp in empList)
            {
                if (emp.Experince >= 5)
                    Console.WriteLine(emp.Name + " is promoted");
            }
        }
    }

    class TestEmpWithoutDelegate
    {
        public static void testEmpWithoutDelegate()
        {
            List<Employee> empList = new List<Employee>();
            empList.Add(new Employee { ID = 1, Name = "Abc", Experince = 3, Salary = 70000 });
            empList.Add(new Employee { ID = 2, Name = "Def", Experince = 4, Salary = 80000 });
            empList.Add(new Employee { ID = 3, Name = "Ghi", Experince = 5, Salary = 90000 });
            empList.Add(new Employee { ID = 4, Name = "Jkl", Experince = 6, Salary = 100000 });

            Employee.promoteEmpl(empList);
        }
    }
}
