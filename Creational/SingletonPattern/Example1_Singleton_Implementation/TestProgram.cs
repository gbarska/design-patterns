using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Diagnostics;
using Autofac;

namespace DesignPatterns
{
   [TestClass]
  public class SingletonTests
  {
     [TestMethod]
    public void IsSingletonTest()
    {
      var db = SingletonDatabase.Instance;
      var db2 = SingletonDatabase.Instance;
      Assert.AreEqual(db,db2);
      Assert.AreEqual(SingletonDatabase.Count,1);
    }

   [TestMethod]
    public void SingletonTotalPopulationTest()
    {
      // testing on a live database
      var rf = new SingletonRecordFinder();
      var names = new[] {"Seoul", "Mexico City"};
      int tp = rf.TotalPopulation(names);
      Assert.AreEqual(tp, 17500000 + 17400000);
    }

      [TestMethod]
    public void DependantTotalPopulationTest()
    {
      var db = new DummyDatabase();
      var rf = new ConfigurableRecordFinder(db);
      Assert.AreEqual(
        rf.GetTotalPopulation(new[]{"alpha", "gamma"}),
        4);
    }

    [TestMethod]
    public void DIPopulationTest()
    {
        var cb = new ContainerBuilder();
        cb.RegisterType<OrdinaryDatabase>().As<IDatabase>()
        .SingleInstance();

        cb.RegisterType<ConfigurableRecordFinder>();

        using(var c= cb.Build())
        {
          var rf = c.Resolve<ConfigurableRecordFinder>();
        }
    }
  }
}