using System;

namespace BasicStuff
{
    public class Employee
    {
        public string m_sFirstName = "Ashish";
        public string m_sLastName = "Modi";

        public virtual void printEmployee()
        {
            Console.WriteLine(m_sFirstName + " " + m_sLastName);
        }
    }

    class PartTimeEmployee : Employee
    {
        public override void printEmployee()
        {
            Console.WriteLine(m_sFirstName + " " + m_sLastName + " Parttime Emp ");
        }
    }

    class FullTimeEmployee : Employee
    {
        public override void printEmployee()
        {
            Console.WriteLine(m_sFirstName + " " + m_sLastName + " Fulltime Emp ");
        }
    }

    class TemporaryEmployee : Employee
    {
        public override void printEmployee()
        {
            Console.WriteLine(m_sFirstName + " " + m_sLastName + " Temporary Emp ");
        }
        //If we comment above implementation, than base class method will be called
        //Also if we write new in place of override, than also base class method will be called
    }

    class PolymorphismDemo
    {
        public void testPolymorphism()
        {
            Employee[] emp = new Employee[4];
            
            emp[0] = new Employee();
            emp[1] = new PartTimeEmployee();
            emp[2] = new FullTimeEmployee();
            emp[3] = new TemporaryEmployee();

            foreach (Employee e in emp)
            {
                e.printEmployee();
            }
        }
    }
}
