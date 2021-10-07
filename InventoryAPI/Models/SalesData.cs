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

        public DateTime PurchaseDate { get; set; }

        [Required(ErrorMessage = "CustomerName Required")]
        public string CustomerName { get; set; }
        [Required(ErrorMessage = "InvoiceNo Required")]
        public int InvoiceNo { get; set; }

        public int GrandTotal { get; set; }

        public int PInvoiceNo { get; set; }


        public int ProductId { get; set; }

        [Required(ErrorMessage = "SalesQTY Required")]
        public string SalesQTY { get; set; }



        public string Price { get; set; }

        public string TotalPrice { get; set; }


        public string ProductName { get; set; }


        public List<PurchaseDetails> PurchaseDetailsList { get; set; }


    }
    public class PurchaseDetails
    {

        public int Id { get; set; }

        public int PInvoiceNo { get; set; }


        public int ProductId { get; set; }


        public string SalesQTY { get; set; }



        public string Price { get; set; }

        public string TotalPrice { get; set; }


        public string ProductName { get; set; }





    }
    public class SalesInvoiceNumber
    {
        public int InvoiceNo { get; set; }
    }
}


