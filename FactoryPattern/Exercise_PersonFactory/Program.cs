using System;

namespace Exercise_PersonFactory
{
 public class Person
  {
    public int Id { get; set; }
    public string Name { get; set; }

    public override string ToString() => $"Id: {Id}, Name: {Name}";
    
    private Person(int id,string name){
        this.Id = id;
        this.Name = name;
    }

    public static PersonFactory Factory => new PersonFactory();
    public class PersonFactory
    {
      private int id = 0;

      public Person CreatePerson(string name)
      {
        return new Person(id++, name);
      }
    }

  }

  

    class Program
    {
        static void Main(string[] args)
        {
          var pf = Person.Factory;

          var p1 = pf.CreatePerson("Chris");
          var p2 = pf.CreatePerson("john");
        
          Console.WriteLine(p1);
          Console.WriteLine(p2);
        }
    }
}
