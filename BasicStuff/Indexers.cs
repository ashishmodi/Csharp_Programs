using System;
using System.Collections.Generic;
using System.Linq;
using Indexers; //my namespace


namespace BasicStuff
{
    class IndexersDemo
    {
        public static void testIndexers()
        {
            Company c = new Company();
            Console.WriteLine("Getting employees using indexers");
            Console.WriteLine(c[1] + " " + c[2] + " " + c[3]);
            //Console.WriteLine(c[4]); NullReference Exception

            Console.WriteLine("Setting employee names using indexers");
            c[1] = "Ashish Modi";
            Console.WriteLine(c[1]);
        }
    }
}

namespace Indexers
{
    class Employee
    {
        public int EmployeeId { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
    }

    class Company
    {
        private List<Employee> listEmployees;
        public Company()
        {
            listEmployees = new List<Employee>();
            listEmployees.Add(new Employee() { EmployeeId = 1, Name = "Ashish", Gender = "Male" });
            listEmployees.Add(new Employee() { EmployeeId = 2, Name = "Mukesh", Gender = "Male" });
            listEmployees.Add(new Employee() { EmployeeId = 3, Name = "Bhavana", Gender = "Female" });
        }

        public string this[int empId]
        {
            get
            {
                //using System.Linq needed for FirsrOrDefault
                return listEmployees.FirstOrDefault(emp => emp.EmployeeId == empId).Name;
            }
            set
            {
                listEmployees.FirstOrDefault(emp => emp.EmployeeId == empId).Name = value;
            }
        }
    }
}

