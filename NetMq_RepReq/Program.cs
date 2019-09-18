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
                Console.WriteLine(Config.TITLE);

                SetUp(Service.ProvidePeople);

            }
            catch (Exception ex)
            {
                Console.WriteLine(String.Format(Config.ERROR_MESSAGE, ex.Message));
            }

        }

        /// <summary>
        /// Setup initializes the service
        /// </summary>
        /// <param name="iniitalize"></param>
        public static void SetUp(Action iniitalize)
        {
            Task work = Task.Factory.StartNew(() => iniitalize());

            Task.WaitAll(work);
        }


    }
}
