using System;
using System.Collections.Generic;
using System.Linq;
using Collection.nsList;

namespace Collection
{
    namespace nsList
    {
        class Customer
        {
            public int ID { get; set; }
            public string Name { get; set; }
            public int Salary { get; set; }
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

            SavingsCustomer sc = new SavingsCustomer();
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
                Console.WriteLine("Name starting with P exists");

            Customer cust1 = listCustomers.Find(cust => cust.Salary > 580000); //Returns 1st matching item
            if(cust1 != null)
                Console.WriteLine("Value : ID = {0}, Name = {1}, Salary = {2}", cust1.ID, cust1.Name, cust1.Salary);
            //FindLast() : Retuns last matching item from list
            List<Customer> listCust = listCustomers.FindAll(cust => cust.Salary > 580000); //Returns List
            //FindIndex() and FindLastIndex()

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
        }
    }
}
    

