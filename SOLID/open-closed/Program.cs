using System.Runtime.CompilerServices;
using System.Collections.Generic;
using System;

namespace DesignPatterns
{
    class Program
    {
        public enum Color{
            Red, Green, Blue
        }

        public enum Size{
            Small, Medium, Large, Yuge
        }
       
        public class Product{   
    
        public string Name;
        public Color Color;
        public Size Size;

        public Product(string name, Color color, Size size)
        {
            if(name == null){
                throw new ArgumentNullException(paramName: nameof(name));
            }    

            Name = name;
            Color = color;
            Size = size; 
        }
      }

        public class ProductFilter
{
    public IEnumerable<Product> FilterBySize(IEnumerable<Product> products, Size size){
        foreach(var p in products){
            if (p.Size == size)
                yield return p;
        }
    }

     public IEnumerable<Product> FilterByColor(IEnumerable<Product> products, Color color){
        foreach(var p in products){
            if (p.Color == color)
                yield return p;
        }
    }

       public IEnumerable<Product> FilterByColorAndSize(IEnumerable<Product> products, Color color, Size size){
        foreach(var p in products){
            if (p.Color == color)
                if(p.Size == size)
                yield return p;
        }
    }
}
        public interface ISpecification<T>{
            bool IsSatisfied(T t);
        }
        public interface IFilter<T>{
   IEnumerable<T> Filter(IEnumerable<T> items, ISpecification<T> spec);
} 
        public class ColorSpecification : ISpecification<Product>{
         private Color color;
         public ColorSpecification(Color color){
             this.color = color;
         }  
         public bool IsSatisfied(Product t){
             return t.Color == color;
         }
        }
        public class SizeSpecification : ISpecification<Product>{
         private Size size;
         public SizeSpecification(Size size){
             this.size = size;
         }  
         public bool IsSatisfied(Product t){
             return t.Size == size;
         }
        }
        public class BetterFilter : IFilter<Product>
        {
            public IEnumerable<Product> Filter(IEnumerable<Product> items, ISpecification<Product> spec)
            {
                foreach (var item in items)
                {
                    if(spec.IsSatisfied(item))
                        yield return item;
                }   
            }

        }

            public class AndSpecification<T>: ISpecification<T>
            {
            private ISpecification<T> first, second;

            public AndSpecification(ISpecification<T> first, ISpecification<T> second)
            {
                this.first = first ?? throw new ArgumentNullException(paramName: nameof(first)); 
                this.second = second ?? throw new ArgumentNullException(paramName: nameof(first)); 
            }
            public bool IsSatisfied(T t){
                return first.IsSatisfied(t) && second.IsSatisfied(t);
            }

            }

        static void Main(string[] args)
        {
            // Console.WriteLine("Hello World!");
           
            var apple = new Product("apple", Color.Green, Size.Small);
            var tree = new Product("tree", Color.Green, Size.Large);
            var house = new Product("house", Color.Blue, Size.Large);

            Product[] products = {apple, tree, house}; 

            var pf = new ProductFilter();

            Console.WriteLine("Green products (old): ");

            foreach (var item in pf.FilterByColor(products, Color.Green))
            {
                Console.WriteLine($" - {item.Name} is green");
            }

            var bf = new BetterFilter();

            Console.WriteLine("Green products (new): ");
            foreach (var item in bf.Filter(products, new ColorSpecification(Color.Green)))
            {
                 Console.WriteLine($" - {item.Name} is green");
            }

            Console.WriteLine("Large blue products (new): ");


            foreach (var item in bf.Filter(products, new AndSpecification<Product>(
                new ColorSpecification(Color.Blue),
                new SizeSpecification(Size.Large)
            )))
            {
                 Console.WriteLine($" - {item.Name} is blue and large");
            }
        }
    }
}
