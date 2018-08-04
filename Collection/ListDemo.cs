using System;
using System.Collections.Generic;
using System.Linq;
using Collection.nsList;
using System.Collections.ObjectModel;

namespace Collection
{
    namespace nsList
    {
        class Customer : IComparable<Customer>
        {
            public int ID { get; set; }
            public string Name { get; set; }
            public int Salary { get; set; }

            public int CompareTo(Customer other)
            {
                /*if (this.Salary > other.Salary)
                    return 1;
                else if (this.Salary < other.Salary)
                    return -1;
                else
                    return 0;*/

                // since Salary is int and int has already provided implementation for IComparable,
                // we can achieve same functionality as below
                return this.Salary.CompareTo(other.Salary);
            }
        }

        class SavingsCustomer : Customer
        {

        }
    }

    class ListDemo
    {
        public static void testList()
        {
            Customer c1 = new Customer() { ID = 1, Name = "Ashish", Salary = 500000 };
            Customer c2 = new Customer() { ID = 2, Name = "Mukesh", Salary = 600000 };
            Customer c3 = new Customer() { ID = 3, Name = "Bhavana", Salary = 700000 };

            List<Customer> listCustomers = new List<Customer>(3);
            listCustomers.Add(c1);
            listCustomers.Add(c2);
            listCustomers.Add(c3);

            Customer c = listCustomers[2]; //3rd element from list

            Console.WriteLine("All elements in the list:");
            foreach (Customer cust in listCustomers)
            {
                Console.WriteLine("Value : ID = {0}, Name = {1}, Salary = {2}", cust.ID, cust.Name, cust.Salary);
            }
            //You can also use for loop
            /*for (int i = 0; i < listCustomers.Count; i++)
            {
                Customer cust = listCustomers[i];
                Console.WriteLine("Value : ID = {0}, Name = {1}, Salary = {2}", cust.ID, cust.Name, cust.Salary);
            }*/

            SavingsCustomer sc = new SavingsCustomer() { ID = 10, Name = "SC", Salary = 1000000 };
            //We can add sc to our listCustomers since it is inheriting from Customer
            listCustomers.Add(sc);

            Customer c4 = new Customer() { ID = 4, Name = "Modi", Salary = 800000 };
            //To insert at particular position
            listCustomers.Insert(0, c4);

            //IndexOf returns index of first matched object. Returns -1 if not found
            Console.WriteLine("Index of c2 = {0}", listCustomers.IndexOf(c2));

            if (listCustomers.Contains(c4))
                Console.WriteLine("Customer 4 exists in list");

            if (listCustomers.Exists(cust => cust.Name.StartsWith("B")))
                Console.WriteLine("Name starting with B exists");

            Customer cust1 = listCustomers.Find(cust => cust.Salary > 580000); //Returns 1st matching item
            if(cust1 != null)
                Console.WriteLine("Value : ID = {0}, Name = {1}, Salary = {2}", cust1.ID, cust1.Name, cust1.Salary);
            //FindLast() : Retuns last matching item from list
            List<Customer> listCust = listCustomers.FindAll(cust => cust.Salary > 580000); //Returns List

            //FindIndex() and FindLastIndex()
            int index = listCustomers.FindIndex(1, 2, cust => cust.Salary > 500001);
            Console.WriteLine("Index = " + index);

            //Converting Array to List
            Customer[] arrayCustomer = new Customer[3];
            arrayCustomer[0] = c1;
            arrayCustomer[1] = c2;
            arrayCustomer[2] = c3;
            List<Customer> listFromArray = arrayCustomer.ToList();

            //Converting List to Array
            Customer[] arrayFromList = listFromArray.ToArray();

            //Converting List to Dictionary
            Dictionary<int, Customer> dictFromList = listCustomers.ToDictionary(cust => cust.ID);

            List<Customer> corporateCustomers = new List<Customer>();
            Customer c5 = new Customer { ID = 5, Name = "Chirag", Salary = 600000 };
            Customer c6 = new Customer { ID = 6, Name = "Vihan" , Salary = 100000 };
            Customer c7 = new Customer { ID = 7, Name = "Karan" , Salary = 500000 };
            Customer c8 = new Customer { ID = 8, Name = "Gaurav", Salary = 300000 };
            Customer c9 = new Customer { ID = 9, Name = "Hemant", Salary = 800000 };
            corporateCustomers.Add(c5);
            corporateCustomers.Add(c6);
            corporateCustomers.Add(c7);
            corporateCustomers.Add(c8);
            corporateCustomers.Add(c9);

            // AddRange method adds another list to the current list
            listCustomers.AddRange(corporateCustomers);
            // GetRange method returns multiple Customers based on given index and count
            List<Customer> onlyCorporate = listCustomers.GetRange(2, 2);

            // Various Remove methods
            listCustomers.Remove(c4);
            listCustomers.RemoveAt(2);
            listCustomers.RemoveAll(cust => cust.Name == "Chirag");
            listCustomers.RemoveRange(0, 2);

            // sorting works for simple types like int, string, decimal, char bcoz they have implemented IComparable interface
            List<int> intList = new List<int>() { 1, 3, 5, 7, 2, 4, 6, 8 };
            intList.Sort();     // sorts in ascending order
            intList.Reverse();  // reverses the order of List elements

            // sorting a Complex type. Implement IComparable interface
            listCustomers.Sort();
            listCustomers.Reverse();

            // If you prefer not to use the sort functionality provided by class, than implement your own using IComparer interface
            // For e.g. to sort by Name instead of Salary
            SortByName nameSort = new SortByName();
            listCustomers.Sort(nameSort);

            // Another way to Sort is using Comparision delegate. 3 steps for this
            // 1. Create a method that matches the syntax for delegate
            // 2. Create object of Comparision delegate
            // 3. Pass delegate to the sort method

            Comparison<Customer> comparer = new Comparison<Customer>(ComparisionID);
            listCustomers.Sort(comparer);

            // above 3 steps can be simplified as below 2 approach
            listCustomers.Sort(delegate (Customer x, Customer y) { return x.ID.CompareTo(y.ID); });
            listCustomers.Sort((x, y) => x.ID.CompareTo(y.ID));

            Console.WriteLine("All elements in the list after sorting");
            foreach (Customer cust in listCustomers)
            {
                Console.WriteLine("Value : ID = {0}, Name = {1}, Salary = {2}", cust.ID, cust.Name, cust.Salary);
            }

            // TrueForAll returns true if condition is true for all list elements
            Console.WriteLine("Are all salaries more than 50000 = " + listCustomers.TrueForAll(cust => cust.Salary > 50000));

            // No Add or Remove method available for readonly collections
            ReadOnlyCollection<Customer> readOnly = listCustomers.AsReadOnly();

            // If capacity is 90% full, than TrimExcess will do nothing
            Console.WriteLine("Capacity before trimming = " + listCustomers.Capacity);
            listCustomers.TrimExcess();
            Console.WriteLine("Capacity after trimming = " + listCustomers.Capacity);
        }

        private static int ComparisionID(Customer x, Customer y)
        {
            return x.ID.CompareTo(y.ID);
        }
    }

    class SortByName : IComparer<Customer>
    {
        public int Compare(Customer x, Customer y)
        {
            return x.Name.CompareTo(y.Name);
        }
    }
}
    

