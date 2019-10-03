using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackendService.Models
{
    public class AppConfiguration
    {
        public string ServiceURLPublicInternet
        {
            get;
            set;
        }

        public string RequestedServicePublicInternet
        {
            get;
            set;
        }

        public string ServiceURLPrivateNetwork
        {
            get;
            set;
        }

        public string RequestedServicePrivateNetwork
        {
            get;
            set;
        }

    }
}
