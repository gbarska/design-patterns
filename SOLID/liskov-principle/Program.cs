using System;

namespace liskov_principle
{
    public class Rectangle
    {
        // public int Width { get; set; }
        // public int Height { get; set; }

         //liskov we should make virtual me elements that need to be replaced in the child classes 
        public virtual int Height { get; set; }
        public virtual int Width { get; set; }

        public Rectangle()
        {
            
        }
        public Rectangle(int width, int height)
        {
            Width = width;
            Height = height;
        }

        public override string ToString(){
            return $"{nameof(Width)}: {Width}, {nameof(Height)}: {Height}";
        }
    }

    public class Square: Rectangle
    {
        public override int Width
        {
            set {
                base.Width = base.Height = value ; 
            }
        }

        public override int Height
        {
            set {
                base.Height = base.Height = value ; 
            }
        }

    }
    class Program
    {
        public static int Area(Rectangle r) => r.Width * r.Height;
        static void Main(string[] args)
        { 

            Rectangle rc = new Rectangle(2,3);

            Console.WriteLine($"{rc} has area {Area(rc)}");


            //liskov principle an inherited object should keep its properties and functionality 
            //when replaced by the BASECLASS TYPE
    
            // Square sq = new Square();
            Rectangle sq = new Square();
            sq.Width = 4;
            //broke the code square is a rectangle but don't 
             Console.WriteLine($"{sq} has area {Area(sq)}");

        }
    }
}
