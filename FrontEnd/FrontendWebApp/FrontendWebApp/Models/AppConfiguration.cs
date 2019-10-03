using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FrontendWebApp.Models
{
    public class AppConfiguration
    {

        public string ServiceURL
        {
            get;
            set;
        }

        public string RequestedServiceHardCoded
        {
            get;
            set;
        }

        public string RequestedServicePrivateNetwork
        {
            get;
            set;
        }


        public string RequestedServicePublicInternet
        {
            get;
            set;
        }

    }


}
