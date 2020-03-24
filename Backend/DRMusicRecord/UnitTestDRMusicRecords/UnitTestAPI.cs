using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestAPI.Controllers;

namespace UnitTestDRMusicRecords
{
    [TestClass]
    public class UnitTestAPI
    {
        private RecordController recordController;

        [TestInitialize]
        public void init()
        {
           recordController = new RestAPI.Controllers.RecordController();
        }

        [TestMethod]
        public void GetAllRecords()
        {
            int actual = recordController.Get().Count();
            Assert.AreEqual(8, actual);
        }
    }
}
