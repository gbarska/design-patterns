using System.Linq;
using System.Collections.Generic;
using System;
namespace DesignPatterns
{ 
    public class HotDrinkMachine
    {
        private List<Tuple<string,IHotDrinkFactory>> factories = 
        new List<Tuple<string, IHotDrinkFactory>>();

      public HotDrinkMachine()
      {
          foreach (var t in typeof(HotDrinkMachine).Assembly.GetTypes())
          {
              if(typeof(IHotDrinkFactory).IsAssignableFrom(t) &&
              !t.IsInterface)
              {
                factories.Add(Tuple.Create(
                    t.Name.Replace("Factory", string.Empty),
                    (IHotDrinkFactory)Activator.CreateInstance(t)
                    )    
                );

              }
          }
      }

      public IHotDrink MakeDrink()
      {
        Console.WriteLine("Available drinks: ");
        
        for (int i = 0; i < factories.Count; i++)
        {
            var tuple = factories[i];
            Console.WriteLine($"{i}: {tuple.Item1}");
        }
        
        while(true)
        {
            string s;
            s = Console.ReadLine();
            if ( s != null
            && int.TryParse(s, out int i) 
            && i >= 0
            && i< factories.Count)
            {
                Console.WriteLine("Specify amount: ");
                s = Console.ReadLine();
                    if (s != null 
                        && int.TryParse(s, out int amount) 
                        && amount > 0)
                        {
                            return factories[i].Item2.Prepare(amount);
                        }
            }
          Console.WriteLine("Incorrect input, try again!");
        }
      }
    }
}