using System;

namespace DesignPatterns
{        
    class Program
    {
        static void Main(string[] args)
        {
         var machine = new HotDrinkMachine();

         var drink = machine.MakeDrink(HotDrinkMachine.AvailableDrink.Tea,200);  

        var drink2 = machine.MakeDrink(HotDrinkMachine.AvailableDrink.Coffee,200);  
            
        }
    }
}
