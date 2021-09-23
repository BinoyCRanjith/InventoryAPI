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
using Oneteammain.ViewModel;

namespace OneTeamMain.API.Controllers
{
    [RoutePrefix("api/Category")]
    public class CategoryController : ApiController
    {
        [HttpPost]
        [Route("CategoryHome")]
        public HttpResponseMessage CategoryHomeMain()
        {
            DbRequestBase request = new DbRequestBase
            {
                InputJson = new { }.ToJson(),
                ProcedureName = "ShowCategoryMain",
                RequestType = DbRequestType.Select
            };
            DbRepository dbRepository = new DbRepository();
            var dbResponse = dbRepository.GetResponse<List<SubCategoryDataAPI>>(request);

            return Request.CreateResponse(HttpStatusCode.OK, dbResponse, "application/json");
        }

        [HttpPost]
        [Route("CategoryIndex")]
        public HttpResponseMessage Index()
        {
            DbRequestBase request = new DbRequestBase
            {
                InputJson = new { }.ToJson(),
                ProcedureName = "ShowCategory",
                RequestType = DbRequestType.Select
            };
            DbRepository dbRepository = new DbRepository();
            var dbResponse = dbRepository.GetResponse<List<CategoryDataAPI>>(request);


            return Request.CreateResponse(HttpStatusCode.OK, dbResponse, "application/json");
        }

        [HttpPost]
        [Route("CategorySave")]
        public HttpResponseMessage Save(CategoryDataAPIView CategoryDataAPI)
        {

            DbRequestBase request = new DbRequestBase
            {
                InputJson = CategoryDataAPI.ToJson(),
                ProcedureName = "AddCategory",
                RequestType = DbRequestType.Insert
            };
            DbRepository dbRepository = new DbRepository();
            var dbResponse = dbRepository.GetResponse<List<CategoryDataAPIView>>(request);

            return Request.CreateResponse(HttpStatusCode.OK, dbResponse, "application/json");
        }


        [HttpPost]
        [Route("SubCategoryHome")]
        public HttpResponseMessage SubCategoryHomeMain()
        {
            DbRequestBase request = new DbRequestBase
            {
                InputJson = new { }.ToJson(),
                ProcedureName = "[ShowSubCategoryData]",
                RequestType = DbRequestType.Select
            };
            DbRepository dbRepository = new DbRepository();
            var dbResponse = dbRepository.GetResponse<List<SubCategoryDataAPI>>(request);


            return Request.CreateResponse(HttpStatusCode.OK, dbResponse, "application/json");
        }



        [HttpPost]
        [Route("SubCategorySave")]
        public HttpResponseMessage SaveSubCategory(SubCategoryDataAPIView SubCategoryDataAPI)
        {

            DbRequestBase request = new DbRequestBase
            {
                InputJson = SubCategoryDataAPI.ToJson(),
                ProcedureName = "AddSubCategory",
                RequestType = DbRequestType.Insert
            };
            DbRepository dbRepository = new DbRepository();
            var dbResponse = dbRepository.GetResponse<List<SubCategoryDataAPIView>>(request);
            
            return Request.CreateResponse(HttpStatusCode.OK, dbResponse, "application/json");
        }
    }


}