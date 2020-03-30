using System;

namespace DesignPatterns
{
    public enum CoordinateSystem
    {
        Cartesian,
        Polar
    }
    public class Point
    {
        private double x,y;

        //one of main concerns regarding constructors is that it cannot be overloaded
        //for example its not possible to have two constructors with the same number of arguments and types
        //one workaround would be add a third parameter to switch on and change the way of initializing fields
        //but its not so good, it increases complexity and  you would have to put some comments and so on..
        public Point(double a,double b, CoordinateSystem system = CoordinateSystem.Cartesian)
        {
            switch(system)
            {
                case CoordinateSystem.Cartesian:
                    x = a;
                    y = b;
                break;

                case CoordinateSystem.Polar:
                    x = a * Math.Cos(b);
                    y = a * Math.Sin(b);
                break;
            }
            this.x = x;
            this.y = y;
        }

    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}
