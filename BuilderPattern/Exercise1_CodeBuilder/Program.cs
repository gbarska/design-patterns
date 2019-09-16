using System;

namespace Exercise1_CodeBuilder
{
     public class CodeBuilder
    {
        protected string text;
        public CodeBuilder(string txt)
        {
            this.text = $"public class {txt} "+ "{"+ Environment.NewLine;
        }
       public CodeBuilder AddField(string varName, string varType)
       {
        this.text += $"{varType} {varName};"+Environment.NewLine;
        return this;
       }

       public override string ToString()
       {
        return this.text+ "}";
       }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var cb = new CodeBuilder("Person").AddField("Name","string").AddField("age","int");
            Console.WriteLine(cb);
        }
    }
}
