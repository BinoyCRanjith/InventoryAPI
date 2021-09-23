using OneTeamAptitudeMVC.ApiServices;
using OneTeamAptitudeMVC.AptitudeCore;
using OneTeamAptitudeMVC.Constants;
using OneTeamAptitudeMVC.Helper;
using OneTeamAptitudeMVC.Models;
using OneTeamAptitudeMVC.Web.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OneTeamAptitudeMVC.Controllers
{
    public class SalesAPIController : Controller
    {
        // GET: SalesAPI


        public ActionResult SalesHomeMain()
        {
            ApiRequestDTO apiRequest = new ApiRequestDTO()
            {
                RouteUrl = "api/Sales/SalesHome",
                RequestType = (RestSharp.Method)1,//"0->GET,1->POST"

            };
            var response = ApiServiceSalesShow.ExecuteMyApi<List<SalesDataAPI>>(apiRequest);
            return View(response.Data);
        }




        [HttpGet]


        public ActionResult InsertSales(int Id = 0)
        {
            SalesDataAPI SalesDataAPIView = new SalesDataAPI();

            setViewBag();

            if (Id > 0)
            {
                DbRequestBase request = new DbRequestBase
                {
                    InputJson = new { Id }.ToJson(),
                    ProcedureName = "SalesDetails",
                    RequestType = DbRequestType.Select
                };
                DbRepository dbRepository = new DbRepository();
                var dbResponse = dbRepository.GetResponse<SalesDataAPI>(request);
                SalesDataAPIView = dbResponse.Data;
            }
            return View(SalesDataAPIView);
        }


        [HttpGet]
        public ActionResult InsertProductAjax(int Id = 0)
        {
            ProductDataAPI ProductDataAPIView = new ProductDataAPI();

            setViewBag();

            if (Id > 0)
            {
                DbRequestBase request = new DbRequestBase
                {
                    InputJson = new { Id }.ToJson(),
                    ProcedureName = "ProductDetails",
                    RequestType = DbRequestType.Select
                };
                DbRepository dbRepository = new DbRepository();
                var dbResponse = dbRepository.GetResponse<ProductDataAPI>(request);
                ProductDataAPIView = dbResponse.Data;

            }

            return Json(ProductDataAPIView, JsonRequestBehavior.AllowGet);
        }


        [HttpPost]
        public ActionResult Save(SalesDataAPIView SalesDataAPI)
        {

            ApiRequestDTO apiRequest = new ApiRequestDTO()
            {
                RouteUrl = "api/Sales/SaveSales",
                RequestType = (RestSharp.Method)1,//"0->GET,1->POST"
                JsonData = SalesDataAPI.ToJson()

            };
            var response = ApiServiceSalesShow.ExecuteMyApi<List<SalesDataAPI>>(apiRequest);
            TempData["Message"] = SalesDataAPI.Id > 0 ? "SalesData updated Successfully" : "new Sales saved successfully";
            return RedirectToAction("SalesHomeMain");
        }



        public ActionResult Delete(int Id)
        {
            DbRequestBase request = new DbRequestBase
            {
                InputJson = new { Id }.ToJson(),
                ProcedureName = "DeleteSales",
                RequestType = DbRequestType.Delete

            };
            DbRepository dbRepository = new DbRepository();
            var dbResponse = dbRepository.GetResponse<List<SalesDataAPI>>(request);
            return RedirectToAction("SalesHomeMain");
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


            ViewBag.ProductList = ProductList.Data;

            
        }



    }
}