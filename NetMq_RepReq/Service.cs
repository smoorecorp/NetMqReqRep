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
    /// People Service Contains methods to Provide or Request People 
    /// </summary>
    public static class Service 
    {

        //Provide People to the client
        public static void ProvidePeople()
        {
            using (var server = new ResponseSocket(Config.SERVER_URL))
            using (var poller = new NetMQPoller { server })
            {
                var reader = new Reader();

                server.ReceiveReady += (sender, e) =>
                {
                    var command = e.Socket.ReceiveFrameString();

                    switch (command.ToLower())
                    {
                        case "getpeople":
                         
                            List<IPerson> people = reader.ReadData(Config.DATA_FILE_PATH);

                            var message = new NetMQMessage(people.Count - 1);

                            people.ForEach(p => message.Append(p.ToString()));

                            e.Socket.SendMultipartMessage(message);

                            break;

                        default:
                            e.Socket.SendFrame(String.Format(Config.DEFAULT_SERVICE_MESSAGE, command));

                            break;
                    }

                    Console.Read();
                };

                poller.Run();
                Console.Read();
            }
        }

        /// <summary>
        /// Request Peope from the Server
        /// </summary>
        public static void RequestPeople()
        {
            using (var request = new RequestSocket(Config.CLIENT_URL))
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
