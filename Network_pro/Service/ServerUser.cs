﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Web;

namespace Service
{
    public class ServerUser
    {
        public int ID { get; set; }

        public string UserName { get; set; }

        public OperationContext operationContext { get; set; }
    }
}