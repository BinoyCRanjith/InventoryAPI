using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InventoryAPI.Models
{
    public class ApiResponse<T> where T : class
    {
        public T Data { get; set; }
        public bool Status { get; set; }
        public int RetVal { get; set; }
        public string ErrorMessage { get; set; }
        public int ErrorNumber { get; set; }
    }
}