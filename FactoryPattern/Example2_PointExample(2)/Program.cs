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
        //factory method
        //here the constructor is private and the factory will be responsable for exposing the right implementation
        public static Point NewCartesianPoint(double x, double y)
        {
            return new Point(x,y);
        }
         //factory method2
        public static Point NewPolarPoint(double rho, double theta)
        {
            return new Point(rho * Math.Cos(theta), rho * Math.Sin(theta));
        }
        private Point(double a,double b)
        {
            this.x = a;
            this.y = b;
        }

        public override string ToString()
        {
            return $"{nameof(x)}: {x}, {nameof(y)}: {y}";
        }

    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Point.NewCartesianPoint(1,3));
            Console.WriteLine(Point.NewPolarPoint(1,3));
        }
    }
}
