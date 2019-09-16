using System;

namespace DesignPatterns
{        
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Point.Factory.NewCartesianPoint(1,3));
            Console.WriteLine(Point.Factory.NewPolarPoint(1,3));

            
        }
    }
}
