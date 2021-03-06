using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace OneTeamAptitudeMVC.Models
{
    public class ProductDataAPI
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public string SubCategoryId { get; set; }

        public string Price { get; set; }
        public string CategoryName { get; set; }

        public string SubCategoryName { get; set; }

        [Required(ErrorMessage = "ProductName Required")]
        public string ProductName { get; set; }

    }
}