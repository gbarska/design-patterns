using System;


namespace DesignPatterns
{

    public class Point
    {
        private double x,y;
        private Point(double a,double b)
        {
            this.x = a;
            this.y = b;
        }

        public override string ToString()
        {
            return $"{nameof(x)}: {x}, {nameof(y)}: {y}";
        }

        //this way the Origin will be instantiated every time we call it
        public static Point Origin => new Point(0,0);// property

        //with this approach singleton it will be instantiated once
        public static Point Origin2 = new Point(0,0);//singleton :  better

    //this property exposes our factory if we can't use a static factory for some reason
    // public PointFactory Factory => new PointFactory();

    //as we don't want to make the constructor public the factory class should be an inner class of Point
    //this way the factory has all access
    
    //non static approach    
    //public class PointFactory
     

     //the best approach a static factory 
    public static class Factory
    {
        //non static approach    
        //public Point NewCartesianPoint(double x, double y)
        public static Point NewCartesianPoint(double x, double y) => new Point(x,y); 
      
         //factory method2
        public static Point NewPolarPoint(double rho, double theta) => new Point(rho * Math.Cos(theta), rho * Math.Sin(theta));
     }


    }


    
}