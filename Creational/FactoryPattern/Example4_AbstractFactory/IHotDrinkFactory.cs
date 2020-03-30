namespace DesignPatterns
{
    public interface IHotDrink
    {
        void Consume();
    }
    public interface IHotDrinkFactory
    {
       IHotDrink Prepare(int amount);  
    }
}