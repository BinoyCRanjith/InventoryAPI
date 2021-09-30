﻿using InventoryAPI.ApiServices;
using InventoryAPI.Helper;
using InventoryAPI.Models;
using InventoryAPI.Types;
using InventoryAPI.AptitudeCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace InventoryAPI.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        //public ActionResult ProductHomeMain()
        //{
        //    ApiRequestDTO apiRequest = new ApiRequestDTO()
        //    {
        //        RouteUrl = "api/Product/ProductHome",
        //        RequestType = (RestSharp.Method)1,//"0->GET,1->POST"

        //    };
        //    var response = ApiServiceMain.ExecuteMyApi<List<ProductData>>(apiRequest);
        //    return View(response.Data);
        //}


        //[HttpGet]


        //public ActionResult InsertProduct(int Id = 0)
        //{
        //    ProductData ProductDataView = new ProductData();

        //    if (Id > 0)
        //    {

        //        ApiRequestDTO apiRequest = new ApiRequestDTO()
        //        {
        //            RouteUrl = $"api/Product/ProductInsert?Id={Id}",
        //            RequestType = (RestSharp.Method)1,//"0->GET,1->POST"
        //            JsonData = null

        //        };
        //        var response = ApiServiceMain.ExecuteMyApi<ProductData>(apiRequest);
        //        ProductDataView = response.Data;

        //    }

        //    return View(ProductDataView);
        //}


        //[HttpPost]
        //public ActionResult Save(ProductDataView ProductData)
        //{

        //    ApiRequestDTO apiRequest = new ApiRequestDTO()
        //    {
        //        RouteUrl = "api/Product/ProductSave",
        //        RequestType = (RestSharp.Method)1,//"0->GET,1->POST"
        //        JsonData = ProductData.ToJson()

        //    };
        //    var response = ApiServiceMain.ExecuteMyApi<List<ProductDataView>>(apiRequest);
        //    TempData["Message"] = ProductData.Id > 0 ? "Product updated Successfully" : "new Product saved successfully";
        //    return RedirectToAction("ProductHomeMain");
        //}

        ////public ActionResult Delete(int Id)
        ////{
        ////    DbRequestBase request = new DbRequestBase
        ////    {
        ////        InputJson = new { Id }.ToJson(),
        ////        ProcedureName = "DeleteProduct",
        ////        RequestType = DbRequestType.Delete

        ////    };
        ////    DbRepository dbRepository = new DbRepository();
        ////    var dbResponse = dbRepository.GetResponse<List<ProductData>>(request);
        ////    return RedirectToAction("ProductHomeMain");
        ////}

        //public ActionResult Delete(int Id)
        //{
        //    ApiRequestDTO apiRequest = new ApiRequestDTO()
        //    {
        //        RouteUrl = $"api/Product/ProductDelete?Id={Id}",
        //        RequestType = (RestSharp.Method)1,//"0->GET,1->POST"
        //        JsonData = null,
        //    };
        //    var response = ApiServiceMain.ExecuteMyApi<List<ProductData>>(apiRequest);
        //    return RedirectToAction("ProductHomeMain");
        //}

        public ActionResult SalesHomeMain()
        {
            ApiRequestDTO apiRequest = new ApiRequestDTO()
            {
                RouteUrl = "api/Product/SalesHome",
                RequestType = (RestSharp.Method)1,//"0->GET,1->POST"

            };
            var response = ApiServiceMain.ExecuteMyApi<List<SalesData>>(apiRequest);
            return View(response.Data);
        }


        [HttpGet]
        public ActionResult InsertProductAjax(int Id = 0)
        {

            
            ApiRequestDTO apiRequest = new ApiRequestDTO()
            {
                RouteUrl = $"api/Product/InsertProductAjax?Id={Id}",
                RequestType = (RestSharp.Method)1,//"0->GET,1->POST"
                JsonData = null

            };
            var response = ApiServiceMain.ExecuteMyApi<ProductData>(apiRequest);

            return Json(response.Data, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]


        public ActionResult InsertSales(int Id = 0)
        {
            SalesData SalesDataView = new SalesData();
            setViewBag();
            if (Id > 0)
            {

                ApiRequestDTO apiRequest = new ApiRequestDTO()
                {
                    RouteUrl = $"api/Product/SalesInsert?Id={Id}",
                    RequestType = (RestSharp.Method)1,//"0->GET,1->POST"
                    JsonData = null

                };
                var response = ApiServiceMain.ExecuteMyApi<SalesData>(apiRequest);
                SalesDataView = response.Data;

            }

            return View(SalesDataView);
        }



        [HttpPost]
        public ActionResult SalesSave(SalesDataView SalesData)
        {

            ApiRequestDTO apiRequest = new ApiRequestDTO()
            {
                RouteUrl = "api/Product/SaveSales",
                RequestType = (RestSharp.Method)1,//"0->GET,1->POST"
                JsonData = SalesData.ToJson()

            };
            var response = ApiServiceMain.ExecuteMyApi<List<SalesData>>(apiRequest);
            TempData["Message"] = SalesData.Id > 0 ? "SalesData updated Successfully" : "new Sales saved successfully";
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
            var ProductList = dbRepository.GetResponse<List<ProductData>>(request);
            ProductList.Data.Insert(0, new ProductData() { Id = 0, ProductName = "--Select--" });


            ViewBag.ProductList = ProductList.Data;
        }
    }
}