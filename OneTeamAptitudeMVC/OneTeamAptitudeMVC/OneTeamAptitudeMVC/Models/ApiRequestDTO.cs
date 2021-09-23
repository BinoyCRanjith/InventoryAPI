using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OneTeamAptitudeMVC.Models
{
    public class ApiRequestDTO
    {

        public string RouteUrl { get; set; }
        public RestSharp.Method RequestType { get; set; }

        public string JsonData { get; set; }
    }
}