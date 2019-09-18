using System;
using NetMq.ReqRep.PeopleService;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NetMQ;
using NetMQ.Sockets;


namespace NetMq.ReqRep.Data.Test
{
    [TestClass]
    public class PeopleServiceTest
    {
        [TestMethod]
        public void PickUpAndReadFileOnly()
        {
            Reader readerTest = new Reader();

            List<IPerson> people = readerTest.ReadData("Data/People.csv");

            Assert.IsNotNull(people);

            Assert.AreNotEqual(0, people.Count);
        }

        [TestMethod]
        public void TestCommunicationOnly()
        {
            using (var response = new ResponseSocket("@tcp://localhost:9999")) 
            using (var request = new RequestSocket(">tcp://localhost:9999"))
                {
                request.SendFrame("Testing");

                var message = response.ReceiveFrameString();

                Console.WriteLine(message);

                message = request.ReceiveFrameString();

                Console.WriteLine(message);
            }
            
        }
    }

    [TestClass]
    public static class CleanUp { 
    
        [TestCleanup]
        public static void CleanTest()
        {
            NetMQ.NetMQConfig.Cleanup();
        }
    }

}
