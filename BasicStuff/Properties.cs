using System;

namespace BasicStuff
{
    class Customer
    {
        public int Id { get; set; } //compiler internally creates memory for storage
        public string Name { get; set; }
        public void printCustomer()
        {
            Console.WriteLine("Name = {0}, Id = {1}", Name, Id);
        }
    }

    class PropertiesDemo
    {
        public void testProperties()
        {
            Customer c1 = new Customer
            {
                Id = 10,
                Name = "Ashish"
            };
            c1.printCustomer();
        }
    }
}
