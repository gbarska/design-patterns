﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using MoreLinq;
using Autofac;

namespace DesignPatterns
{
  
public interface IDatabase
  {
    int GetPopulation(string name);
  }
  public class SingletonDatabase : IDatabase
  {
    private Dictionary<string, int> capitals;
    private static int instanceCount;
    public static int Count => instanceCount;

    private SingletonDatabase()
    {
      Console.WriteLine("Initializing database");

      capitals = File.ReadAllLines(
        Path.Combine(
          new FileInfo(typeof(IDatabase).Assembly.Location).DirectoryName, "capitals.txt")
        )
        .Batch(2)
        .ToDictionary(
          list => list.ElementAt(0).Trim(),
          list => int.Parse(list.ElementAt(1)));
    }

    public int GetPopulation(string name)
    {
      return capitals[name];
    }

    // laziness + thread safety
    private static Lazy<SingletonDatabase> instance = new Lazy<SingletonDatabase>(() =>
    {
      instanceCount++;
      return new SingletonDatabase();
    });

    public static IDatabase Instance => instance.Value;
  }

  public class OrdinaryDatabase : IDatabase
  {
    private Dictionary<string, int> capitals;

    private OrdinaryDatabase()
    {
      Console.WriteLine("Initializing database");

      capitals = File.ReadAllLines(
        Path.Combine(
          new FileInfo(typeof(IDatabase).Assembly.Location).DirectoryName, "capitals.txt")
        )
        .Batch(2)
        .ToDictionary(
          list => list.ElementAt(0).Trim(),
          list => int.Parse(list.ElementAt(1)));
    }

  public int GetPopulation(string name)
    {
      return capitals[name];
    }

  }
  public class SingletonRecordFinder
  {
    public int TotalPopulation(IEnumerable<string> names)
    {
      int result = 0;
      foreach (var name in names)
        result += SingletonDatabase.Instance.GetPopulation(name);
      return result;
    }
  }

  public class ConfigurableRecordFinder
  {
    private IDatabase database;

    public ConfigurableRecordFinder(IDatabase database)
    {
      this.database = database;
    }

    public int GetTotalPopulation(IEnumerable<string> names)
    {
      int result = 0;
      foreach (var name in names)
        result += database.GetPopulation(name);
      return result;
    }
  }

  public class DummyDatabase : IDatabase
  {
    public int GetPopulation(string name)
    {
      return new Dictionary<string, int>
      {
        ["alpha"] = 1,
        ["beta"] = 2,
        ["gamma"] = 3
      }[name];
    }
  }


    class Program
    {
        static void Main(string[] args)
        {
           Console.WriteLine("Hello World!");  var db = SingletonDatabase.Instance;

      // works just fine while you're working with a real database.
      var city = "Tokyo";
      Console.WriteLine($"{city} has population {db.GetPopulation(city)}");

      // now some tests
        }
    }
}
