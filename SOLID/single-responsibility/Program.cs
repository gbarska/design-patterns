using System.IO;
using System;
using System.Collections.Generic;

namespace DesignPatterns
{
    class Program
    {

        public class Journal{
            private readonly List<string> entries = new List<string>();
            private static int count = 0;

            public int AddEntry(string text){
                entries.Add($"{++count}: {text}");
                return count;
            }

            public void RemoveEntry(int index){
                entries.RemoveAt(index);
            }

            public override string ToString(){
                return string.Join(Environment.NewLine, entries);
            }

            //single responsability instead of having methods to save in a file 
            //separate the logic for saving and implementation in other class 

            // public void Save(string filename){
            //     File.WriteAllText(filename, ToString());
            // }

            //  public void Load(string filename){
            //   //implementation
            // }

            //  public void Load(Uri uri){
            //   //implementation
            // }
        }

        public class Persistence{
            public void SaveToFile(Journal journal, string filename, bool overwrite = false){
                if (overwrite || !File.Exists(filename))
                    File.WriteAllText(filename,journal.ToString());
            }
        }
        static void Main(string[] args)
        {
            // Console.WriteLine("Hello World!");
            var j = new Journal();
            j.AddEntry("I cried today");
            j.AddEntry("I ate a bug");
            Console.WriteLine(j);

            var p = new Persistence();
            var filename = @"./journal.txt";
            p.SaveToFile(j,filename,true);
        }
    }
}
