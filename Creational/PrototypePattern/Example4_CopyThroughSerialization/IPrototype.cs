namespace DesignPatterns 
{
    public interface IPrototype<T>
    {
         T DeepCopy();
    }
}