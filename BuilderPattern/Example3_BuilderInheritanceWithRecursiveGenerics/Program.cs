using System;

namespace DotNetDesignPatternDemos.Creational
{
 
  public class Person
  {
    public string Name;
    public string Position;

    public class Builder : PersonJobBuilder<Builder>
    {

    }

    public static Builder New => new Builder();

    public override string ToString()
    {
      return $"{nameof(Name)}: {Name}, {nameof(Position)}: {Position}";
    }
  }

public abstract class PersonBuilder
{
  protected Person person = new Person();

  public Person Build()
  {
    return person;
  }

}
  // self should be a class that inherits from a class 'x'
  // where this 'x' class has the following signature: PersonInfoBuilder<self>
  //by the way that is the class the same class as above: class PersonInfoBuilder<self>
 public class PersonInfoBuilder<SELF>
  : PersonBuilder where SELF : PersonInfoBuilder<SELF>
  {
    // protected Person person = new Person();

    //this builder implementation works fine unless we inherit from this class
    // public PersonInfoBuilder Called(string name)
    // {
    //   person.Name = name;
    //   return this;
    // }
  // public PersonInfoBuilder Called(string name)
  //    {
  //      person.Name = name;
  //      return this;
  //    }
    public SELF Called(string name)
     {
       person.Name = name;
       return (SELF)this;
     }
  }  

  // we are doing it again, personjobbuilder inheriths from PersonInfoBuilder<SELF>
  //but we must replace the generic self with a class that satisfies the condition 
  // and that is the class above: <PersonJobBuilder<SELF>>
  public class PersonJobBuilder<SELF> : PersonInfoBuilder<PersonJobBuilder<SELF>> where SELF : PersonJobBuilder<SELF>
  {

    //this builder implementation works fine unless we inherit from this class
    // public PersonJobBuilder WorksAs(string Position)
    // {
    //  person.Position = Position;
    //  return this; 
    // }

public SELF WorksAs(string Position)
    {
     person.Position = Position;
     return (SELF) this; 
    }

  }
 
  public class BuilderInheritanceDemo
  {
    static void Main(string[] args)
    {
      // var builder = new PersonJobBuilder();
      
      //we broke the code as in the moment we call the first builder method we are casting the object
      //to base type infobuilder that has noacces to WorksAs builder method
      // builder.Called("john").WorksAs("position");

     var me = Person.New
        .Called("john")
        .WorksAs("driver")
        .Build();

      Console.WriteLine(me);
    }
  }
}