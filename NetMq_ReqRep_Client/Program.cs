using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NetMQ;
using NetMQ.Sockets;

namespace NetMq_ReqRep_Client
{
   public class Program
    {
        static void Main(string[] args)
        {

            
           


            //using (var pubSocket = new PublisherSocket())
            //{
            //    Console.WriteLine("Started");
            //    pubSocket.Options.SendHighWatermark = 1000;

            //    pubSocket.Bind("tcp://localhost:9999");
            //    for (var i =0;i<100; i++)
            //    {
            //        var msg = "Topic A msg-" + i;
            //        pubSocket.SendMoreFrame("Topic A").SendFrame(msg);

            //    }

            //    Thread.Sleep(500);
            //}

            //Console.WriteLine("Done");
            //Console.ReadLine()


        }

    }
}
