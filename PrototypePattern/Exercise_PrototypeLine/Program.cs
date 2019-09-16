using System;

namespace DesignPatterns
{
     public class Point
    {
      public int X, Y;
      public Point(int x, int y)
      {
          this.X = x;
          this.Y = y;
      }
       public override string ToString() => $"X: {X}, Y: {Y}";
    }

    public class Line
    {
      public Point Start, End;
    
     public Line(Point start, Point end)
      {
          this.Start = start;
          this.End = end;
      }
      public Line DeepCopy()
      {
        return new Line (new Point(Start.X,Start.Y), new Point(End.X,End.Y ));
   
      }
      public override string ToString() => $"Start: {Start}, End: {End}";
    }
    class Program
    {
        
        static void Main(string[] args)
        {
            var line = new Line(new Point(0,2),new Point(3,1));
            Console.WriteLine(line);
            var line2 = line.DeepCopy();
            line2.Start = new Point(3,3);
            Console.WriteLine(line2);
            Console.WriteLine(line);
        }
    }
}
