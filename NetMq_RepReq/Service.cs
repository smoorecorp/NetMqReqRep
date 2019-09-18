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
            using (var server = new ResponseSocket(Config.URL))
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
    }
}
