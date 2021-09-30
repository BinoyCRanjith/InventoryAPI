using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace InventoryAPI.Models
{
    public class ProductData
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public string SubCategoryId { get; set; }

        [Required(ErrorMessage = "Price Required")]
        public string Price { get; set; }

        [Required(ErrorMessage = "CategoryName Required")]
        public string CategoryName { get; set; }

        [Required(ErrorMessage = "SubCategoryName Required")]
        public string SubCategoryName { get; set; }

        [Required(ErrorMessage = "ProductName Required")]
        public string ProductName { get; set; }

    }
}