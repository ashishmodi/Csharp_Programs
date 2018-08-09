using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Collection
{
    class Country
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public string Capital { get; set; }
    }
    
    class ListVsDictionary
    {        
        public static void testListPerformance()
        {
            Country c1 = new Country() { Code = "IND", Name = "INDIA", Capital = "DELHI" };
            Country c2 = new Country() { Code = "UK", Name = "UNITED KINGDOM", Capital = "LONDON" };
            Country c3 = new Country() { Code = "US", Name = "UNITED STATES", Capital = "WASHINGTON" };

            List<Country> listCountries = new List<Country>();
            listCountries.Add(c1);
            listCountries.Add(c2);
            listCountries.Add(c3);

            string sChoice = "";
            do
            {
                Console.WriteLine("Please enter country code");
                string sCountryCode = Console.ReadLine().ToUpper();
                Country c = listCountries.Find(country => country.Code == sCountryCode);

                if (c == null)
                    Console.WriteLine("Invalid country code entered");
                else
                    Console.WriteLine("Name = {0}, Capital = {1}", c.Name, c.Capital);

                Console.WriteLine("Do you wish to continue? YES or NO?");
                sChoice = Console.ReadLine().ToUpper();
            } while (sChoice == "YES");
        }

        public static void testDictionaryPerformance()
        {
            Country c1 = new Country() { Code = "IND", Name = "INDIA", Capital = "DELHI" };
            Country c2 = new Country() { Code = "UK", Name = "UNITED KINGDOM", Capital = "LONDON" };
            Country c3 = new Country() { Code = "US", Name = "UNITED STATES", Capital = "WASHINGTON" };

            Dictionary<string, Country> dictCountries = new Dictionary<string, Country>();
            dictCountries.Add(c1.Code, c1);
            dictCountries.Add(c2.Code, c2);
            dictCountries.Add(c3.Code, c3);

            string sChoice = "";
            do
            {
                Console.WriteLine("Please enter country code");
                string sCountryCode = Console.ReadLine().ToUpper();
                Country c;
                
                if (!dictCountries.ContainsKey(sCountryCode))
                    Console.WriteLine("Invalid country code entered");
                else
                {
                    dictCountries.TryGetValue(sCountryCode, out c);
                    Console.WriteLine("Name = {0}, Capital = {1}", c.Name, c.Capital);
                }                    

                Console.WriteLine("Do you wish to continue? YES or NO?");
                sChoice = Console.ReadLine().ToUpper();
            } while (sChoice == "YES");

        }
    }
}
