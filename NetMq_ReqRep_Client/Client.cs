using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NetMQ;
using NetMQ.Sockets;
using System.Threading;

namespace NetMq.ReqRep.Client
{
    /// <summary>
    /// People Service Contains methods to Provide or Request People 
    /// </summary>
    public static class Client 
    {

        /// <summary>
        /// Request Peope from the Server
        /// </summary>
        public static void RequestPeople()
        {
            using (var request = new RequestSocket(Config.URL))
            using (var poller = new NetMQPoller { request })
            {

                request.ReceiveReady += (sender, e) =>
                {

                    bool moreData = true;

                    while (moreData)
                    {
                        Console.WriteLine(e.Socket.ReceiveFrameString(out moreData));
                    }
                    poller.StopAsync();
                };

                string command = Config.GET_PEOPLE_COMMAND;

                request.SendFrame(command);
                if (!poller.IsRunning)
                    poller.Run();

                command = Console.ReadLine();

            }
        }
    }
}
