using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NetMQ;
using NetMQ.Sockets;
using System.Threading;

namespace NetMq.ReqRep.PeopleService
{

    /// <summary>
    /// Start up a Client of a Server based on the input 
    /// </summary>
    class Program
    {

        static void Main(string[] args)
        {
            try
            {
                switch (args[0].ToLower())
                {
                    case "client": //use client to start the client app

                        Console.WriteLine(Config.CLIENT_TITLE);

                        Console.WriteLine(Config.CLIENT_STARTUP_MESSAGE);

                        Thread.Sleep(1000);

                        SetUp(Service.RequestPeople);

                        break;
                    case "server": //use srver to start the server app
                        Console.WriteLine(Config.SERVER_TITLE);

                        SetUp(Service.ProvidePeople);

                        break;
                    default:
                        Console.WriteLine(Config.DEFAULT_SERVICE_MESSAGE);
                        break;
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(String.Format(Config.ERROR_MESSAGE, ex.Message));
            }

        }
        public static void SetUp(Action iniitalize)
        {
            Task work = Task.Factory.StartNew(() => iniitalize());

            Task.WaitAll(work);
        }


    }
}
