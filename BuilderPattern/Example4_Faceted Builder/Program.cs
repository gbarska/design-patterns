using System;

namespace DesignPatterns
{
    public class Person
    {
        //address
        public string StreetAddress, PostCode, City;

        //employment
        public string CompanyName, Position;
        public int AnnualIncome;

        public override string ToString()
        {
            return $"{nameof(StreetAddress)}: {StreetAddress}, {nameof(PostCode)}: {PostCode}, {nameof(City)}: {City}, {nameof(CompanyName)}: {CompanyName}, {nameof(Position)}: {Position}, {nameof(AnnualIncome)}: {AnnualIncome}";
        }
    }

    //this class is a facade for others builders, its responsibility is to keep the reference
    // of the original object that has been built from the begining
    // warning: it works fine with reference types but does not with value types.
    public class PersonBuilder 
    {
      protected Person person = new Person();

        //here in the facade we must expose the builders to allow the returned objects 
        //to have access to the fluent methods, since both builders below
        //inherit from this class both of them will expose the Works and the Lives fields
        public PersonJobBuilder Works => new PersonJobBuilder(person);
        public PersonAddressBuilder Lives => new PersonAddressBuilder(person);


        // we are exposing an operator to cast the personbuilder used to construct the object Person,
        //into a Person object at the end:
        public static implicit operator Person(PersonBuilder pb)
        {
            return pb.person;
        }
    } 

    public class PersonAddressBuilder : PersonBuilder
    {
        public PersonAddressBuilder(Person person)
        {
            this.person = person;
        }

        public PersonAddressBuilder StreetAddress(string street)
        {
            this.person.StreetAddress = street;
            return this;
        }
        public PersonAddressBuilder City(string city)
        {
            this.person.City = city;
            return this;
        }
        public PersonAddressBuilder PostCode(string postcode)
        {
            this.person.PostCode = postcode;
            return this;
        }
    }

    public class PersonJobBuilder : PersonBuilder
    {
        public PersonJobBuilder(Person person)
        {
            this.person = person;
        }

        public PersonJobBuilder At(string companyName)
        {
            this.person.CompanyName = companyName;
            return this;
        }
        public PersonJobBuilder ASA(string position)
        {
            this.person.Position = position;
            return this;
        }
        public PersonJobBuilder Makes(int annualIncome)
        {
            this.person.AnnualIncome = annualIncome;
            return this;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {   
            Person pb = new PersonBuilder()
                     .Works.At("Vodafone")
                        .ASA("engineer")
                            .Makes(1000000)
                            .Lives.City("cajamar")
                                .PostCode("000000-000")
                                   .StreetAddress("street ad");

            Console.WriteLine(pb);
        }
    }
}
