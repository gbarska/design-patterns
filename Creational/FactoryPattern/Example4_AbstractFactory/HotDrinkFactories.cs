using System;

namespace DesignPatterns
{
    internal class Tea: IHotDrink
    {
        public void Consume()
        {
            Console.WriteLine("This tea is nice.");
        }
    }
    internal class Coffee: IHotDrink
    {
        public void Consume()
        {
            Console.WriteLine("This coffee is sensational.");
        }
    }
    public class TeaFactory : IHotDrinkFactory 
    {
        public IHotDrink Prepare(int amount)
        {
            //this factory creates and prepares the object tea and then returns it 
          Console.WriteLine($"Put in a tea bag, boil water, pour {amount} ml, add lemon, enjoy!");
          return new Tea();
        }
    }
    public class CoffeeFactory : IHotDrinkFactory 
    {
        public IHotDrink Prepare(int amount)
        {
         Console.WriteLine($"Grind some beans, boil water, pour {amount} ml, add cream and sugar, enjoy!");
           return new Coffee();
        }
    }
}