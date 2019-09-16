using System;
using System.Collections.Generic;

namespace Example2_Monostate
{

  public class ChiefExecutiveOfficer
  {

      //static fields ensure that everyone will be accessing the same value on memory
      //even though another instance would be created, this is the monostate pattern
    private static string name;
    private static int age;

    public string Name
    {
      get => name;
      set => name = value;
    }

    public int Age
    {
      get => age;
      set => age = value;
    }

    public override string ToString()
    {
      return $"{nameof(Name)}: {Name}, {nameof(Age)}: {Age}";
    }
  }
    class Program
    {
        static void Main(string[] args)
        {
           var ceo = new ChiefExecutiveOfficer();
            ceo.Name = "Adam Smith";
            ceo.Age = 55;
              Console.WriteLine(ceo);
            var ceo2 = new ChiefExecutiveOfficer();
            ceo2.Age = 13;
            ceo2.Name ="bla";
            Console.WriteLine(ceo2);
             Console.WriteLine(ceo);
        }
    }
}
