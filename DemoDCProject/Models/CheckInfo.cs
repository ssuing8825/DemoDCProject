using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DemoDCProject.Models
{
    public class CheckInfo : AccountBase
    {
        public string AccountNumber { get; set; }
        public string RoutingNumber { get; set; }
    }
}