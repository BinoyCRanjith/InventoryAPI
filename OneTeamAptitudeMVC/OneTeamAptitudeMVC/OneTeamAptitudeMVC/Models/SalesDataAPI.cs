using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace OneTeamAptitudeMVC.Models
{
    public class SalesDataAPI
    {
        public int Id { get; set; }


        [Required(ErrorMessage = "ProductId Required")]
        public int ProductId { get; set; }


        [Required(ErrorMessage = "SalesQTY Required")]
        public string SalesQTY { get; set; }


        [Required(ErrorMessage = "Price Required")]
        public string Price { get; set; }

        public string TotalPrice { get; set; }

        [Required(ErrorMessage = "ProductName Required")]
        public string ProductName { get; set; }

        
    }
}