using OneTeamAptitudeMVC.AptitudeCore;
using OneTeamAptitudeMVC.Helper;
using OneTeamAptitudeMVC.Models;
using OneTeamAptitudeMVC.Web.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;


namespace OneTeamMain.API.Controllers
{
    [RoutePrefix("api/Sales")]
    public class SalesController : ApiController
    {
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
            var dbResponse = dbRepository.GetResponse<List<SalesDataAPI>>(request);


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
            var dbResponse = dbRepository.GetResponse<SalesDataAPI>(request);
            return Request.CreateResponse(HttpStatusCode.OK, dbResponse, "application/json");



        }

        [HttpPost]
        [Route("ProductInsert")]
        public HttpResponseMessage InsertProductAjax(int Id = 0)
        {
            ProductDataAPI ProductDataAPIView = new ProductDataAPI();

            
            
                DbRequestBase request = new DbRequestBase
                {
                    InputJson = new { Id }.ToJson(),
                    ProcedureName = "ProductDetails",
                    RequestType = DbRequestType.Select
                };
                DbRepository dbRepository = new DbRepository();
                var dbResponse = dbRepository.GetResponse<ProductDataAPI>(request);
                return Request.CreateResponse(HttpStatusCode.OK, dbResponse, "application/json");

            }

         




        [HttpPost]
        [Route("SaveSales")]
        public HttpResponseMessage Save(SalesDataAPIView SalesDataAPI)
        {
            //
            DbRequestBase request = new DbRequestBase
            {
                InputJson = SalesDataAPI.ToJson(),
                ProcedureName = "AddSales",
                RequestType = DbRequestType.Insert
            };
            DbRepository dbRepository = new DbRepository();
            var dbResponse = dbRepository.GetResponse<List<SalesDataAPIView>>(request);

            return Request.CreateResponse(HttpStatusCode.OK, dbResponse, "application/json");
        }



        [HttpPost]
        [Route("SalesDelete")]
        public HttpResponseMessage Delete(int Id)
        {
            DbRequestBase request = new DbRequestBase
            {
                InputJson = new { Id }.ToJson(),
                ProcedureName = "DeleteSales",
                RequestType = DbRequestType.Delete

            };
            DbRepository dbRepository = new DbRepository();
            var dbResponse = dbRepository.GetResponse<List<SalesDataAPI>>(request);
            return Request.CreateResponse(HttpStatusCode.OK, dbResponse, "application/json");
        }



    }
}
