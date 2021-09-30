using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace InventoryAPI.AptitudeCore
{
    public class OutputParameter
    {
        public int RetVal { get; set; }
        public DataType DataType { get; set; }
        public int ErrorNumber { get; set; }
        public string ErrorMessage { get; set; }
    }
}