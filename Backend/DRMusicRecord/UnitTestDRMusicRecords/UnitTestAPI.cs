using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Music;
using Newtonsoft.Json;
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
            recordController = new RecordController();
        }

        [TestMethod]
        public void GetAllRecords()
        {
            int actual = recordController.Get().Count();
            Assert.AreEqual(8, actual);
        }

        [TestMethod]
        public void GetASingleTitle()
        {
            int actual = recordController.GetFromTitle("Stjerneskud").Count();
            Assert.AreEqual(1, actual);
        }

        #region AddRecordTest

        private Record GetRecord(string title = "test1")
        {
            return new Record()
            {
                Artist = "test",
                Duration = 150,
                Title = title,
                YearOfPublication = 2020
            };
        }


        [TestMethod]
        public void PostRecordTest()
        {

            //Arrange
             Record newRecord = GetRecord();

            int countBefore = recordController.Get().Count();

            //Act

            recordController.Post(JsonConvert.SerializeObject(newRecord));

            int countAfter = recordController.Get().Count();

            //Assert

            Assert.AreEqual(countBefore + 1, countAfter);

        }

        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [TestMethod]
        public void PostRecordMinCharTest()
        {
            //Arrange
            Record newRecord = GetRecord("b");

           
            //Act 
            recordController.Post(JsonConvert.SerializeObject(newRecord));

        }


        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [TestMethod]
        public void PostRecordMaxCharTest()
        {
            string testString = "EtHunredeOgEnChars";

            for (int i = 0; i < 101 - testString.Length; i++)
            {
                testString += "-";
            }

            //Arrange
            Record newRecord = GetRecord(testString);

            //Act 
            recordController.Post(JsonConvert.SerializeObject(newRecord));
        }


        [ExpectedException(typeof(ArgumentNullException))]
        [TestMethod]
        public void PostRecordNoEmptyTest()
        {
         
            //Arrange
            Record newRecord = GetRecord("");

            //Act 
            recordController.Post(JsonConvert.SerializeObject(newRecord));
        }

        [TestMethod]
        public void PostRecordMellemrumTest()
        {

            //Arrange
            Record newRecord = GetRecord("Test test");

            int countBefore = recordController.Get().Count();

            //Act

            recordController.Post(JsonConvert.SerializeObject(newRecord));

            int countAfter = recordController.Get().Count();

            //Assert

            Assert.AreEqual(countBefore + 1, countAfter);

        }

        [ExpectedException(typeof(Exception))]
        [TestMethod]
        public void PostRecordSameRecordTwiceTest()
        {

            //Arrange
            Record newRecord = GetRecord();
            recordController.Post(JsonConvert.SerializeObject(newRecord));

            //Act
            recordController.Post(JsonConvert.SerializeObject(newRecord));
        }


        #endregion
    }

}
