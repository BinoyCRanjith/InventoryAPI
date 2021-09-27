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

                ApiRequestDTO apiRequest = new ApiRequestDTO()
                {
                    RouteUrl = $"api/Sales/SalesInsert?Id={Id}",
                    RequestType = (RestSharp.Method)1,//"0->GET,1->POST"
                    JsonData = null

                };
                var response = ApiServiceSalesShow.ExecuteMyApi<SalesDataAPI>(apiRequest);
                SalesDataAPIView = response.Data;

            }

            return View(SalesDataAPIView);
        }



        [HttpGet]
        public ActionResult InsertProductAjax(int Id = 0)
        {

            setViewBag();
            ApiRequestDTO apiRequest = new ApiRequestDTO()
            {
                RouteUrl = $"api/Sales/ProductInsert?Id={Id}",
                RequestType = (RestSharp.Method)1,//"0->GET,1->POST"
                JsonData = null

            };
            var response = ApiServiceSalesShow.ExecuteMyApi<ProductDataAPI>(apiRequest);

            return Json(response.Data, JsonRequestBehavior.AllowGet);
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
            ApiRequestDTO apiRequest = new ApiRequestDTO()
            {
                RouteUrl = $"api/Sales/SalesDelete?Id={Id}",
                RequestType = (RestSharp.Method)1,//"0->GET,1->POST"
                JsonData =  null,
            };
            var response = ApiServiceSalesShow.ExecuteMyApi<List<SalesDataAPI>>(apiRequest);
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

            DbRequestBase request1 = new DbRequestBase
            {
                InputJson = new { }.ToJson(),
                ProcedureName = "ShowSubCategoryData",
                RequestType = DbRequestType.Select
            };

            var SubCategoryList = dbRepository.GetResponse<List<SubCategoryDataAPI>>(request1);
            SubCategoryList.Data.Insert(0, new SubCategoryDataAPI() { Id = 0, SubCategoryName = "--Select--" });
            ViewBag.SubCategoryList = SubCategoryList.Data;

            DbRequestBase request2 = new DbRequestBase
            {
                InputJson = new { }.ToJson(),
                ProcedureName = "ShowCategory",
                RequestType = DbRequestType.Select
            };

            var CategoryList = dbRepository.GetResponse<List<CategoryDataAPI>>(request2);
            CategoryList.Data.Insert(0, new CategoryDataAPI() { Id = 0, CategoryName = "--Select--" });
            ViewBag.CategoryList = CategoryList.Data;


        }



    }
}