using System;

namespace DesignPatterns
{

    public class Document
    {

    }

    public interface IMachine
    {
        void Print(Document d);
        void Scan(Document d);
        void Fax(Document d);

    }

    public class MultiFunctionPrinter : IMachine
    {
        public void Print(Document d)
        {
             //ok it can print
        }
         public void Scan(Document d)
        {
           //ok it can scan        
        }
        public void Fax(Document d)
        {
             //ok it can fax
        }
    }

    public class OldFashionedPrinter : IMachine
    {
        public void Print(Document d)
        {
            //ok it can print
        }
         public void Scan(Document d)
        {
            throw new NotImplementedException();
        }
        public void Fax(Document d)
        {
            throw new NotImplementedException();
        }
    }


public interface IPrinter
{
    void Print(Document d);
}

public interface IScanner
{
    void Print(Document d);
}

public class Photocopier :IPrinter, IScanner
{
        public void Print(Document d)
        {
             //ok it can print
        }
         public void Scan(Document d)
        {
           //ok it can scan        
        }
}

public interface IMultiFunctionMachine: IScanner,IPrinter //some extra interfaces need to be added...
{

}

//this way with separeted interfaces, supposelly you need to refactor your code in future
//if you already has separeted implementation of interfaces and u want to add extra interfaces like above
public class MultiFunctionMachine: IMultiFunctionMachine 
{
    private IPrinter printer;
    private IScanner scanner;

    public MultiFunctionMachine(IScanner scanner, IPrinter printer)
    {
        if (printer == null )        
        {
            throw new ArgumentNullException(paramName: nameof(printer));
        }
         if (scanner == null )        
        {
            throw new ArgumentNullException(paramName: nameof(scanner));
        }
        
        this.printer = printer;
        this.scanner = scanner;
    }
        public void Print(Document d)
        {
            //use the existing implementations
            this.printer.Print();
        }
         public void Scan(Document d)
        {
           this.scanner.Scan();
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
