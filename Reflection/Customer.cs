using System;

namespace Reflection
{
    class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public Customer()
        {
            this.Id = -1;
            this.Name = string.Empty;
        }

        public Customer(int id, string name)
        {
            this.Id = id;
            this.Name = name;
        }

        public void printId()
        {
            Console.WriteLine("Id = {0}", Id);
        }

        public void printName()
        {
            Console.WriteLine("Name = {0}", Name);
        }

        public void set(int id, string name)
        {
            this.Id = id;
            this.Name = name;
        }
    }
}
