using System;

namespace DesignPatterns
{
  public interface IRenderer
  {
    string WhatToRenderAs {get;}     
  }
    public abstract class Shape 
    {
      public IRenderer renderer;

    // a bridge between the shape that's being drawn an
    // the component which actually draws it
    public Shape(IRenderer renderer)
    {
      this.renderer = renderer;
    }
      public string Name { get; set; }

      
    public override string ToString() => $"Drawing {Name} as {renderer.WhatToRenderAs}";
    }

    public class Triangle : Shape
    {
      public Triangle(IRenderer renderer) : base(renderer) => Name = "Triangle";
    }

    public class Square : Shape
    {
      public Square(IRenderer renderer) : base(renderer) => Name = "Square"; 
    }

    // public class VectorSquare : Square
    // {
    //   public override string ToString() => "Drawing {Name} as lines";
    // }

    // public class RasterSquare : Square
    // {
    //   public override string ToString() => "Drawing {Name} as pixels";
    // }

public class VectorRenderer : IRenderer
  {
    public string WhatToRenderAs {get;}   
    public VectorRenderer()
    {
      this.WhatToRenderAs = "lines";
    }

  }

public class RasterRenderer : IRenderer
  {
    public string WhatToRenderAs {get;}  
    public RasterRenderer()
    {
       this.WhatToRenderAs = "pixels";
    }
  }



    class Program
    {
        static void Main(string[] args)
        {
          Console.WriteLine(new Triangle(new RasterRenderer()).ToString());
        }
    }
}
