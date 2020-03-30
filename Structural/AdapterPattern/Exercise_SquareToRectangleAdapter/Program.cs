using System;

namespace DesignPatterns
{
 public class Square
    {
      public int Side;
    }

    public interface IRectangle
    {
      int Width { get; }
      int Height { get; }
    }
    
    public static class ExtensionMethods
    {
      public static int Area(this IRectangle rc)
      {
        return rc.Width * rc.Height;
      }
    }
   public class SquareToRectangleAdapter : IRectangle
    {
      public int Width { get; }
      public int Height { get; }
      public SquareToRectangleAdapter(Square square)
      {
       this.Height = square.Side;
       this.Width =square.Side;
      }
 
    }


    class Program
    {
        static void Main(string[] args)
        {
            var sq = new Square {Side= 4};
            var rc = new SquareToRectangleAdapter(sq);

            Console.WriteLine(ExtensionMethods.Area(rc));
        }
    }
}
