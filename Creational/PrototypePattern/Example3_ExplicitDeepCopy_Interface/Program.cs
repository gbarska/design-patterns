using System;

namespace DesignPatterns {
    public class Person : IPrototype<Person>  {
        public string[] Names;
        public Address Address;

        public Person (string[] names, Address address) {
            this.Names = names;
            this.Address = address;
        }
        //one possible workaround would be using a copy constructor
        //providing a constructor that receives the pre-built object
        //and fullfill the new object
        public Person(Person other)
        {
            Names = new string[] {other.Names[0], other.Names[1]};
            Address = new Address(other.Address);
        }

        public override string ToString () => $" Names: {string.Join(" ",Names)}, Address: {Address} ";

      public Person DeepCopy()
         {
            return new Person(Names,Address.DeepCopy());
         }
    }

    public class Address   {
        public string StreetName;
        public int HouseNumber;

        public Address (string streetName, int houseNumber) {
            this.StreetName = streetName;
            this.HouseNumber = houseNumber;
        }

        public Address(Address other)
        {
            this.StreetName = other.StreetName;
            this.HouseNumber = other.HouseNumber;
        }

        public override string ToString () => $" StreetName: {StreetName}, HouseNumber: {HouseNumber} ";

            // a custom interface would be another approach but all these apporaches
            //takes too much time if the nested structure of objects were too big
            //it would take a huge effort
         public Address DeepCopy()
         {
            return new Address(StreetName,HouseNumber);
         }
    }
    class Program {
        static void Main (string[] args) {
            var john = new Person(new []{"John", "Smith"},new Address("London",30));
            Console.WriteLine (john);
            var lisa = new Person(john);
            lisa.Names[0] ="Lisa";
              Console.WriteLine (john);
            Console.WriteLine (lisa);
        }
    }
}