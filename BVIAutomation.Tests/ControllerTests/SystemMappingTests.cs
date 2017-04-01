using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using BVIAutomation.Model.Entities;
using Bolado.Controllers;

namespace BVIAutomation.Tests
{
    [TestClass]
    public class SystemMappingTests
    {
        [TestMethod]
        public void GetMappingTest()
        {
            //This is the populated list
            var arrModules = new List<Module>();

            //Moque
            arrModules.Add(new Module { FcName = "A", Id = 1, IdModule = 0, IdSystem = 1 });
            arrModules.Add(new Module { FcName = "B", Id = 2, IdModule = 0, IdSystem = 1 });
            arrModules.Add(new Module { FcName = "C", Id = 3, IdModule = 1, IdSystem = 1 });

            var obj = new HomeController();

            var resultJson = obj.GetMap(arrModules);

            Assert.IsNotNull(resultJson);
        }
    }
}
