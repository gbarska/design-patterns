using System.Xml.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System;

namespace DesignPatterns {

    public static class ExtensionMethods
    {
        public static T DeepCopy<T>(this T self)
        {
            var stream = new MemoryStream();
            var formatter = new BinaryFormatter();
            //we are serializing the object into stream to copy the entire tree
            formatter.Serialize(stream, self);

            stream.Seek(0,SeekOrigin.Begin);

            object copy= formatter.Deserialize(stream);
            stream.Close();

            return (T) copy;
        }

        public static T DeepCopyXml<T>(this T self)
        {
            using(var ms = new MemoryStream()){
            
            var s = new XmlSerializer(typeof(T));

            //we are serializing the object into stream to copy the entire tree
            s.Serialize(ms, self);
            ms.Position = 0;

            return (T) s.Deserialize(ms);
            }
          
        }

    }
    // [Serializable]
    public class Person  {
        public string[] Names;
        public Address Address;

        public Person()
        {
            
        }

        public Person (string[] names, Address address) {
            this.Names = names;
            this.Address = address;
        } 

        public override string ToString () => $" Names: {string.Join(" ",Names)}, Address: {Address} ";
    }

    // [Serializable] //required for binary serializer
    public class Address {
        public string StreetName;
        public int HouseNumber;

        public Address()//empty constructor required for xml serializer
        {
            
        }
        public Address (string streetName, int houseNumber) {
            this.StreetName = streetName;
            this.HouseNumber = houseNumber;
        }
        public override string ToString () => $" StreetName: {StreetName}, HouseNumber: {HouseNumber} ";
    
    }
    class Program {
        static void Main (string[] args) {
            var john = new Person(new []{"John", "Smith"},new Address("London",30));
            Console.WriteLine (john);

            var lisa = john.DeepCopyXml();
            lisa.Names[0] ="Lisa";
            
            Console.WriteLine (john);
            Console.WriteLine (lisa);
        }
    }
}