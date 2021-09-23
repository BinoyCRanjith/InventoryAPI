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
    public class ProductAPIController : Controller
    {
        // GET: ProductAPI
        public ActionResult ProductHomeMain()
        {
            ApiRequestDTO apiRequest = new ApiRequestDTO()
            {
                RouteUrl = "api/Product/ProductHome",
                RequestType = (RestSharp.Method)1,//"0->GET,1->POST"

            };
            var response = ApiServiceSalesShow.ExecuteMyApi<List<ProductDataAPI>>(apiRequest);
            return View(response.Data);
        }



        [HttpGet]
        public ActionResult InsertProduct(int Id = 0)
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
             return View(ProductDataAPIView);
            
        }
        [HttpPost]
        public ActionResult Save(ProductDataAPIView ProductDataAPI)
        {

            ApiRequestDTO apiRequest = new ApiRequestDTO()
            {
                RouteUrl = "api/Product/ProductSave",
                RequestType = (RestSharp.Method)1,//"0->GET,1->POST"
                JsonData = ProductDataAPI.ToJson()

            };
            var response = ApiServiceSalesShow.ExecuteMyApi<List<ProductDataAPIView>>(apiRequest);
            TempData["Message"] = ProductDataAPI.Id > 0 ? "Product updated Successfully" : "new Product saved successfully";
            return RedirectToAction("ProductHomeMain");
        }

        public ActionResult Delete(int Id)
        {
            DbRequestBase request = new DbRequestBase
            {
                InputJson = new { Id }.ToJson(),
                ProcedureName = "DeleteProduct",
                RequestType = DbRequestType.Delete

            };
            DbRepository dbRepository = new DbRepository();
            var dbResponse = dbRepository.GetResponse<List<ProductDataAPI>>(request);
            return RedirectToAction("ProductHomeMain");
        }
        private void setViewBag()
        {
            DbRequestBase request = new DbRequestBase
            {
                InputJson = new { }.ToJson(),
                ProcedureName = "ShowCategory",
                RequestType = DbRequestType.Select
            };
            DbRepository dbRepository = new DbRepository();
            var CategoryList = dbRepository.GetResponse<List<CategoryDataAPI>>(request);
            CategoryList.Data.Insert(0, new CategoryDataAPI() { Id = 0, CategoryName = "--Select--" });


            ViewBag.CategoryList = CategoryList.Data;

            DbRequestBase request1 = new DbRequestBase
            {
                InputJson = new { }.ToJson(),
                ProcedureName = "ShowSubCategoryData",
                RequestType = DbRequestType.Select
            };

            var SubCategoryList = dbRepository.GetResponse<List<SubCategoryDataAPI>>(request1);
            SubCategoryList.Data.Insert(0, new SubCategoryDataAPI() { Id = 0, SubCategoryName = "--Select--" });


            ViewBag.SubCategoryList = SubCategoryList.Data;
        }



    }
}