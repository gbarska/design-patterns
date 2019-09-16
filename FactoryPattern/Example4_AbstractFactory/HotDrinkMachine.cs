using System.Collections.Generic;
using System;
namespace DesignPatterns
{ 
    public class HotDrinkMachine
    {
        public enum AvailableDrink
        {
            Coffee,
            Tea
        }

     private Dictionary<AvailableDrink,IHotDrinkFactory> factories =
        new Dictionary<AvailableDrink,IHotDrinkFactory>();   

        public HotDrinkMachine()
        {   
            //imagine if we have to create a list of factories available for our machine
            //factories.Add(AvailableDrink.Tea,new TeaFactory());
            //if the available drinks are received in an external API we could manage to
            //create the factories instances dynamically because we use interfaces

            foreach (AvailableDrink drink in Enum.GetValues(typeof(AvailableDrink)))
            {
                var name = Enum.GetName(typeof(AvailableDrink),drink);

                var tipo = Type.GetType(
                        "DesignPatterns." +  name + "Factory" 
                                );

                Console.WriteLine($"name: {name}, type: {tipo}");

                var factory = (IHotDrinkFactory)Activator.CreateInstance(
                    tipo
                );

                factories.Add(drink,factory);
            }
           
        }

        public IHotDrink MakeDrink(AvailableDrink drink, int amount)
        {
            return factories[drink].Prepare(amount);
        }
    }
}