using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Diagnostics;


namespace DesignPatterns
{
    [TestClass]
    public class FirstTestSuite
    {
      [TestMethod]
      public void Test()
      {
        var obj = new object();
        Assert.IsTrue(SingletonTester.IsSingleton(() => obj));
        Assert.IsFalse(SingletonTester.IsSingleton(() => new object()));
      }
    }
}