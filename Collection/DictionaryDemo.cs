using System;
using System.Collections.Generic;
using System.Linq;
using Collection.nsDictionary;

namespace Collection
{
    namespace nsDictionary
    {
        class Customer
        {
            public int ID { get; set; }
            public string Name { get; set; }
            public int Salary { get; set; }
        } 
    }

    class DictionaryDemo
    {
        public static void testDictionary()
        {
            Customer c1 = new Customer() { ID = 1, Name = "Ashish", Salary = 500000 };
            Customer c2 = new Customer() { ID = 2, Name = "Mukesh", Salary = 600000 };
            Customer c3 = new Customer() { ID = 3, Name = "Bhavana", Salary = 700000 };

            Dictionary<int, Customer> dictionaryCustomer = new Dictionary<int, Customer>();
            dictionaryCustomer.Add(c1.ID, c1);
            dictionaryCustomer.Add(c2.ID, c2);
            dictionaryCustomer.Add(c3.ID, c3);
            //Below line build successful. Runtime exception - Keys in dictionary must be unique
            //dictionaryCustomer.Add(c1.ID, c1);
            if (!dictionaryCustomer.ContainsKey(c1.ID))
            {
                dictionaryCustomer.Add(c1.ID, c1);
            }

            //searches the customer with Id 2. Crashes at run time if doesn't find it. Use Try/Catch
            Customer cust2 = dictionaryCustomer[2];
            //Better approach is to use TryGetValue() or ContainsKey(). Exception free.

            Customer c;
            int key = 2;
            if (dictionaryCustomer.TryGetValue(key, out c))
            {
                Console.WriteLine("TryGetValue : ID = {0}, Name = {1}, Salary = {2}", c.ID, c.Name, c.Salary);
            }
            else
                Console.WriteLine("Key {0} doesn't exists", key);

            Console.WriteLine("All key values in dictionary:");
            //foreach (var keyValuePair in dictionaryCustomer) //ok to use var
            foreach (KeyValuePair<int, Customer> keyValuePair in dictionaryCustomer)
            {
                Console.WriteLine("Key = {0}", keyValuePair.Key);
                Customer cust = keyValuePair.Value;
                Console.WriteLine("Value : ID = {0}, Name = {1}, Salary = {2}", cust.ID, cust.Name, cust.Salary);
                Console.WriteLine("*******");
            }

            Console.WriteLine("All keys in dictionary:");
            foreach (int Key in dictionaryCustomer.Keys)
            {
                Console.WriteLine(Key);
            }
            Console.WriteLine("*******");

            Console.WriteLine("All values in dictionary:");
            foreach (Customer cust in dictionaryCustomer.Values)
            {
                Console.WriteLine("Value : ID = {0}, Name = {1}, Salary = {2}", cust.ID, cust.Name, cust.Salary);
            }
            Console.WriteLine("*******");

            Console.WriteLine("Total no of items in dictionary = {0}", dictionaryCustomer.Count);
            //Below will also work. Use of extension method.
            Console.WriteLine("Total no of items in dictionary = {0}", dictionaryCustomer.Count());
            Console.Write("count of Employees whose Salary > 510000 = ");
            Console.Write(dictionaryCustomer.Count(kvp => kvp.Value.Salary > 510000));  //LINQ

            //dictionaryCustomer.Remove(999);   //If key doesn't exists than no exception will come
            //dictionaryCustomer.Clear();       //Removes all items from dictionary

            //Converting Array to Dictionary
            Customer[] arrayCustomer = new Customer[3];
            arrayCustomer[0] = c1;
            arrayCustomer[1] = c2;
            arrayCustomer[2] = c3;
            Dictionary<int, Customer> dictFromArray = arrayCustomer.ToDictionary(cust => cust.ID, cust => cust);

            //Converting List to Dictionary
            List<Customer> listCustomers = new List<Customer>();
            listCustomers.Add(c1);
            listCustomers.Add(c2);
            listCustomers.Add(c3);            
            Dictionary<int, Customer> dictFromList = listCustomers.ToDictionary(cust => cust.ID, cust => cust);
        }
    }    
}
