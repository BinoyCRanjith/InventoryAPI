﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InventoryAPI.Models
{
    public class SalesDataView
    {
        public int Id { get; set; }

        public DateTime PurchaseDate { get; set; }

        public string CustomerName { get; set; }

        public int InvoiceNo { get; set; }

        public int GrandTotal { get; set; }

        public int PInvoiceNo { get; set; }


        public int ProductId { get; set; }


        public string SalesQTY { get; set; }



        public string Price { get; set; }

        public string TotalPrice { get; set; }


        public string ProductName { get; set; }


        public List<PurchaseDetailsView> PurchaseDetailsList { get; set; }


    }
    public class PurchaseDetailsView
    {

        public int Id { get; set; }

        public int PInvoiceNo { get; set; }


        public int ProductId { get; set; }


        public string SalesQTY { get; set; }



        public string Price { get; set; }

        public string TotalPrice { get; set; }


        public string ProductName { get; set; }





    }
}