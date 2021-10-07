using InventoryAPI.AptitudeCore;
using InventoryAPI.Helper;
using InventoryAPI.Models;
using InventoryAPI.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace InventoryData.API.Controllers
{
    [RoutePrefix("api/Product")]
    public class ProductAPIController : ApiController
    {
        
       


        [HttpPost]
        [Route("InsertProductAjax")]
        public HttpResponseMessage InsertProductAjax(int Id = 0)
        {
            ProductData ProductDataAPIView = new ProductData();



            DbRequestBase request = new DbRequestBase
            {
                InputJson = new { Id }.ToJson(),
                ProcedureName = "ProductDetails",
                RequestType = DbRequestType.Select
            };
            DbRepository dbRepository = new DbRepository();
            var dbResponse = dbRepository.GetResponse<ProductData>(request);
            return Request.CreateResponse(HttpStatusCode.OK, dbResponse, "application/json");

        }

        [HttpPost]
        [Route("SalesHome")]
        public HttpResponseMessage SalesHomeMain()
        {
            DbRequestBase request = new DbRequestBase
            {
                InputJson = new { }.ToJson(),
                ProcedureName = "ShowSales",
                RequestType = DbRequestType.Select
            };
            DbRepository dbRepository = new DbRepository();
            var dbResponse = dbRepository.GetResponse<List<SalesData>>(request);


            return Request.CreateResponse(HttpStatusCode.OK, dbResponse, "application/json");
        }

        [HttpPost]
        [Route("SalesInsert")]

        public HttpResponseMessage InsertSales(int Id = 0)
        {

            DbRequestBase request = new DbRequestBase
            {
                InputJson = new { Id }.ToJson(),
                ProcedureName = "SalesDetails",
                RequestType = DbRequestType.Select
            };
            DbRepository dbRepository = new DbRepository();
            var dbResponse = dbRepository.GetResponse<SalesData>(request);
            return Request.CreateResponse(HttpStatusCode.OK, dbResponse, "application/json");



        }

        [HttpPost]
        [Route("SaveSales")]
        public HttpResponseMessage Save(SalesDataView SalesData)
        {
            //
            DbRequestBase request = new DbRequestBase
            {
                InputJson = SalesData.ToJson(),
                ProcedureName = "SalesStore",
                RequestType = DbRequestType.Insert
            };
            DbRepository dbRepository = new DbRepository();
            var dbResponse = dbRepository.GetResponse<List<SalesData>>(request);

            return Request.CreateResponse(HttpStatusCode.OK, dbResponse, "application/json");
        }

        //[HttpPost]
        //[Route("ViewBag")]
        //public HttpResponseMessage setViewBag()
        //{
        //    DbRequestBase request = new DbRequestBase
        //    {
        //        InputJson = new { }.ToJson(),
        //        ProcedureName = "ShowProduct",
        //        RequestType = DbRequestType.Select
        //    };
        //    DbRepository dbRepository = new DbRepository();
        //    var dbResponse = dbRepository.GetResponse<List<ProductData>>(request);

            


        //    DbRequestBase request1 = new DbRequestBase
        //    {
        //        InputJson = new { }.ToJson(),
        //        ProcedureName = "InvoiceNumber",
        //        RequestType = DbRequestType.Select
        //    };
        //    DbRepository dbRepository1 = new DbRepository();
        //    var dbResponse1 = dbRepository1.GetResponse<SalesData>(request1).Data.InvoiceNo;
            

        //    return Request.CreateResponse(HttpStatusCode.OK, dbResponse1, "application/json");
        //    return Request.CreateResponse(HttpStatusCode.OK, dbResponse, "application/json");
        //}


    }
}
