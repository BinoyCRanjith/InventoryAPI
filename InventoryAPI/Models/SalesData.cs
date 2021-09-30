using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace InventoryAPI.Models
{
    public class SalesData
    {
        public int Id { get; set; }

        public int ProductId { get; set; }


        [Required(ErrorMessage = "SalesQTY Required")]
        public string SalesQTY { get; set; }


        [Required(ErrorMessage = "Price Required")]
        public string Price { get; set; }

        public string GrandTotal { get; set; }

        public string TotalPrice { get; set; }

        [Required(ErrorMessage = "ProductName Required")]
        public string ProductName { get; set; }


        public DateTime PurchaseDate { get; set; }

        public string CustomerName { get; set; }

        public int InvoiceNo { get; set; }

        public List<PurchaseDetails> PurchaseDetailsList { get; set; }
    }

    
    public class PurchaseDetails
    {

        public int Id { get; set; }

        public int ProductId { get; set; }


        [Required(ErrorMessage = "SalesQTY Required")]
        public string SalesQTY { get; set; }


        [Required(ErrorMessage = "Price Required")]
        public string Price { get; set; }

        public string TotalPrice { get; set; }

        [Required(ErrorMessage = "ProductName Required")]
        public string ProductName { get; set; }

        [Required(ErrorMessage = "CategoryName Required")]
        public string CategoryName { get; set; }

        [Required(ErrorMessage = "SubCategoryName Required")]
        public string SubCategoryName { get; set; }



    }
}