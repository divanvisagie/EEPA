﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EEPA.Producer
{
    public class QueueMessage
    {
        public string Type { get; set; }
        public string MessageBody { get; set; }
    }

    public class User
    {
        public string UserName { get; set; }
    }
}