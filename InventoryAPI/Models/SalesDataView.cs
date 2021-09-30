using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InventoryAPI.Models
{
    public class SalesDataView
    {
        public int Id { get; set; }

        public int ProductId { get; set; }

        public string SalesQTY { get; set; }


        
        public string Price { get; set; }

        public string TotalPrice { get; set; }

        
        public string ProductName { get; set; }

        
        public string CategoryName { get; set; }

        
        public string SubCategoryName { get; set; }

        public DateTime SalesDate { get; set; }

    }
}