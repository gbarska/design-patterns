using System.Linq;
using System.Collections.Generic;
using System;

namespace dependency_inversion
{
    public enum Relationship
    {
        Parent,
        Child,
        Sibling
    }

    public class Person
    {
        public string Name;
        //public DateTime DateOfBirth;

    }

public interface IRelatioshipBrowser
{
    IEnumerable<Person> FindAllChildrenOf(string name);
}

//low-level 
    public class Relationships : IRelatioshipBrowser
    {
        //because we have provided a public getter and other classes migth have been using this getter
        //we can't change the way we store data here from List to dictionary for example...
        private List<(Person, Relationship, Person)> relations = new List<(Person, Relationship, Person)>();

        public void AddParentAndChild(Person parent, Person child)
        {
            relations.Add((parent,Relationship.Parent,child));
            relations.Add((child,Relationship.Child,parent));
        }
        
        //bad way of exposing data by making a public getter of a low level class
        // public List<(Person, Relationship, Person)> Relations => relations;

        public IEnumerable<Person> FindAllChildrenOf(string name)
        {
            return relations.Where
            (
                x => x.Item1.Name == "john" &&
                x.Item2 == Relationship.Parent
            ).Select(r => r.Item3);
        }
    }

    class Program
    {
        // public Program(Relationships relationships)
        
        
        //now my class dependson the interface extracted 
        public Program(IRelatioshipBrowser browser)
        {
            // foreach (var item in relationships.Relations.Where
            // (
            //     x => x.Item1.Name == "john" &&
            //     x.Item2 == Relationship.Parent
            // ))
            // {
            //     Console.WriteLine($"John has a child called {item.Item3.Name}");
            // }

            foreach (var item in browser.FindAllChildrenOf("john"))
            {
                Console.WriteLine($"John has a child called {item.Name}");
            }
        }
        static void Main(string[] args)
        {
            var parent = new Person{ Name = "john"};
            var child = new Person{ Name = "chris"};
            var child2 = new Person{ Name = "daniel"};

            var relationships = new Relationships();

            relationships.AddParentAndChild(parent,child);
            relationships.AddParentAndChild(parent,child2);
            

           new Program(relationships);

            Console.WriteLine("Hello World!");
        }
    }
}
