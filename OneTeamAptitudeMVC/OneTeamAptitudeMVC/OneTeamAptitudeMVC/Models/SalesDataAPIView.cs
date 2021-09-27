using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OneTeamAptitudeMVC.Models
{
    public class SalesDataAPIView
    {
        public int Id { get; set; }
        public int ProductId { get; set; }

       
        public int CategoryId { get; set; }


        
        public int SubCategoryId { get; set; }

        public string SalesQTY { get; set; }

        public string Price { get; set; }

        public string TotalPrice { get; set; }

        public string ProductName { get; set; }
    }
}