using System;

namespace DesignPatterns {
    public class Person : ICloneable {
        public string[] Names;
        public Address Address;

        public Person (string[] names, Address address) {
            this.Names = names;
            this.Address = address;
        }

        public override string ToString () => $" Names: {string.Join(" ",Names)}, Address: {Address} ";

        public object Clone()
        {
            return new Person(Names,(Address)Address.Clone());
        }
    }

    public class Address : ICloneable  {
        public string StreetName;
        public int HouseNumber;

        public Address (string streetName, int houseNumber) {
            this.StreetName = streetName;
            this.HouseNumber = houseNumber;
        }

        public override string ToString () => $" StreetName: {StreetName}, HouseNumber: {HouseNumber} ";


 public object Clone()
        {
            return new Address(StreetName,HouseNumber);
        }

    }
    class Program {
        static void Main (string[] args) {
            var john = new Person(new []{"John", "Smith"},new Address("London",30));
            Console.WriteLine (john);

            //supposely we want to copy john and replace the name to create Lisa object:
            // var lisa = john;
            // lisa.Names[0] = "lisa";

            // //we got a bug as we've copied the reference, in the moment we changed the value to lisa
            // // both objects were replaced, so that's not the way to go...
            // Console.WriteLine (john);
            // Console.WriteLine (lisa);


            //with Icloneable
            var lisa = (Person)john.Clone();
            //we fixed the problem for address using an deep copying implementation but as
            //icloneable uses shalow copying in the string[] we still have problems with the names
            lisa.Address.HouseNumber = 0;
            lisa.Names[0] = "lisa";

             Console.WriteLine (john);
             Console.WriteLine (lisa);
        }
    }
}