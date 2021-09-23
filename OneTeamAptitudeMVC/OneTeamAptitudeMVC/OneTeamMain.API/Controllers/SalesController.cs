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


        //[HttpPost]
        //[Route("SalesInsert")]

        //public HttpResponseMessage InsertSales(int Id = 0)
        //{
        //    SalesDataAPI SalesDataAPIView = new SalesDataAPI();

        //    setViewBag();

        //    if (Id > 0)
        //    {
        //        DbRequestBase request = new DbRequestBase
        //        {
        //            InputJson = new { Id }.ToJson(),
        //            ProcedureName = "SalesDetails",
        //            RequestType = DbRequestType.Select
        //        };
        //        DbRepository dbRepository = new DbRepository();
        //        var dbResponse = dbRepository.GetResponse<List<SalesDataAPI>>(request);
        //        SalesDataAPIView = dbResponse.Data;
        //    }
        //        return Request.CreateResponse(HttpStatusCode.OK, SalesDataAPIView, "application/json");
            
        //}






        [HttpPost]
        [Route("SaveSales")]
        public HttpResponseMessage Save(SalesDataAPIView SalesDataAPI)
        {

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


        public void setViewBag()
        {
            DbRequestBase request = new DbRequestBase
            {
                InputJson = new { }.ToJson(),
                ProcedureName = "ShowProduct",
                RequestType = DbRequestType.Select
            };
            DbRepository dbRepository = new DbRepository();
            var ProductList = dbRepository.GetResponse<List<ProductDataAPI>>(request);
            ProductList.Data.Insert(0, new ProductDataAPI() { Id = 0, ProductName = "--Select--" });


            

            DbRequestBase request1 = new DbRequestBase
            {
                InputJson = new { }.ToJson(),
                ProcedureName = "ShowSubCategoryData",
                RequestType = DbRequestType.Select
            };

            var SubCategoryList = dbRepository.GetResponse<List<SubCategoryDataAPI>>(request1);
            SubCategoryList.Data.Insert(0, new SubCategoryDataAPI() { Id = 0, SubCategoryName = "--Select--" });


            
        }

    }
}
