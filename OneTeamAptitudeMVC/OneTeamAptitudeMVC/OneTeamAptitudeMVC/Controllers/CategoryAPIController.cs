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
    public class CategoryAPIController : Controller
    {
        // GET: CategoryAPI
        public ActionResult CategoryHomeMain()
        {
            ApiRequestDTO apiRequest = new ApiRequestDTO()
            {
                RouteUrl = "api/Category/CategoryHome",
                RequestType = (RestSharp.Method)1,//"0->GET,1->POST"

            };
            var response = ApiServiceSalesShow.ExecuteMyApi<List<SubCategoryDataAPI>>(apiRequest);
            return View(response.Data);
        }

        public ActionResult Index()
        {
            ApiRequestDTO apiRequest = new ApiRequestDTO()
            {
                RouteUrl = "api/Category/CategoryIndex",
                RequestType = (RestSharp.Method)1,//"0->GET,1->POST"

            };
            var response = ApiServiceSalesShow.ExecuteMyApi<List<CategoryDataAPI>>(apiRequest);
            return View(response.Data);
        }
        [HttpGet]
        public ActionResult InsertCategory(int Id = 0)
        {
            CategoryDataAPI CategoryDataAPIView = new CategoryDataAPI();

            //SetViewBag();
            if (Id > 0)
            {
                DbRequestBase request = new DbRequestBase
                {
                    InputJson = new { Id }.ToJson(),
                    ProcedureName = "CategoryDetails",
                    RequestType = DbRequestType.Select
                };
                DbRepository dbRepository = new DbRepository();
                var dbResponse = dbRepository.GetResponse<CategoryDataAPI>(request);
                CategoryDataAPIView = dbResponse.Data;
            }
            return View(CategoryDataAPIView);
        }
        [HttpPost]
        public ActionResult Save(CategoryDataAPIView CategoryDataAPI)
        {
            ApiRequestDTO apiRequest = new ApiRequestDTO()
            {
                RouteUrl = "api/Category/CategorySave",
                RequestType = (RestSharp.Method)1,//"0->GET,1->POST"
                JsonData = CategoryDataAPI.ToJson()

            };
            var response = ApiServiceSalesShow.ExecuteMyApi<List<CategoryDataAPI>>(apiRequest);
            TempData["Message"] = CategoryDataAPI.Id > 0 ? "Category updated Successfully" : "new Category saved successfully";
            return RedirectToAction("Index");
        }
        
         

        public ActionResult Delete(int Id)
        {
            DbRequestBase request = new DbRequestBase
            {
                InputJson = new { Id }.ToJson(),
                ProcedureName = "DeleteCategory",
                RequestType = DbRequestType.Delete

            };
            DbRepository dbRepository = new DbRepository();
            var dbResponse = dbRepository.GetResponse<List<CategoryDataAPI>>(request);
            return RedirectToAction("Index");
        }
        //SubCategory
        public ActionResult SubCategoryHomeMain()
        {
            ApiRequestDTO apiRequest = new ApiRequestDTO()
            {
                RouteUrl = "api/Category/SubCategoryHome",
                RequestType = (RestSharp.Method)1,//"0->GET,1->POST"

            };
            var response = ApiServiceSalesShow.ExecuteMyApi<List<SubCategoryDataAPI>>(apiRequest);
            return View(response.Data);
        }
        [HttpGet]
        public ActionResult InsertSubCategory(int Id = 0)
        {
            SubCategoryDataAPI SubCategoryDataAPIView = new SubCategoryDataAPI();

            setViewBag();
            if (Id > 0)
            {
                DbRequestBase request = new DbRequestBase
                {
                    InputJson = new { Id }.ToJson(),
                    ProcedureName = "SubCategoryDetails",
                    RequestType = DbRequestType.Select
                };
                DbRepository dbRepository = new DbRepository();
                var dbResponse = dbRepository.GetResponse<SubCategoryDataAPI>(request);
                SubCategoryDataAPIView = dbResponse.Data;
            }
            return View(SubCategoryDataAPIView);
        }
        [HttpPost]
        public ActionResult SaveSubCategory(SubCategoryDataAPIView SubCategoryDataAPI)
        {
            ApiRequestDTO apiRequest = new ApiRequestDTO()
            {
                RouteUrl = "api/Category/SubCategorySave",
                RequestType = (RestSharp.Method)1,//"0->GET,1->POST"
                JsonData = SubCategoryDataAPI.ToJson()

            };
            var response = ApiServiceSalesShow.ExecuteMyApi<List<SubCategoryDataAPI>>(apiRequest);
            TempData["Message"] = SubCategoryDataAPI.Id > 0 ? "Category updated Successfully" : "new Category saved successfully";
            return RedirectToAction("SubCategoryHomeMain");
        }

        public ActionResult DeleteSubCategory(int Id)
        {
            DbRequestBase request = new DbRequestBase
            {
                InputJson = new { Id }.ToJson(),
                ProcedureName = "DeleteSubCategory",
                RequestType = DbRequestType.Delete

            };
            DbRepository dbRepository = new DbRepository();
            var dbResponse = dbRepository.GetResponse<List<SubCategoryDataAPI>>(request);
            return RedirectToAction("SubCategoryHomeMain");
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
        }
    }
}
