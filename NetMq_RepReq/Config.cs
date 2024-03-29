﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetMq.ReqRep.PeopleService
{
    /// <summary>
    /// Constant Values.  In a normal situation we some of these values can benefit from localization.
    /// </summary>
    public static class Config
    {
        public const string URL = "@tcp://*:56000";
        public const string DEFAULT_COMMAND_MESSAGE = "{0} has been executed successfully." ;
        public const string DATA_FILE_PATH = "Data/People.csv";
        public const string TITLE = "Welcome To Working People Server";
        public const string DEFAULT_SERVICE_MESSAGE = "No application type provided.Please restart and provide application type of Server or Client.";
        public const string ERROR_MESSAGE = "The Following error has occured: {0}";

    }
}
