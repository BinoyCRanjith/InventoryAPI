using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using InventoryAPI.Types;

namespace InventoryAPI.AptitudeCore
{

    public class DbRequestBase
    {
        public string ProcedureName { get; set; }
        public string InputJson { get; set; }
        public DbRequestType RequestType { get; set; }
    }
}