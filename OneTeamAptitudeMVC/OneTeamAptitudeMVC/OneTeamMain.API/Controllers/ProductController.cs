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
    [RoutePrefix("api/Product")]
    public class ProductController : ApiController
    {

        [HttpPost]
        [Route("ProductHome")]
        public HttpResponseMessage ProductHomeMain()
            {
                DbRequestBase request = new DbRequestBase
                {
                    InputJson = new { }.ToJson(),
                    ProcedureName = "ShowProduct",
                    RequestType = DbRequestType.Select
                };
                DbRepository dbRepository = new DbRepository();
                var dbResponse = dbRepository.GetResponse<List<ProductDataAPI>>(request);


            return Request.CreateResponse(HttpStatusCode.OK, dbResponse, "application/json");
        }

        [HttpPost]
        [Route("ProductSave")]
        public HttpResponseMessage Save(ProductDataAPIView ProductDataAPI)
        {

            DbRequestBase request = new DbRequestBase
            {
                InputJson = ProductDataAPI.ToJson(),
                ProcedureName = "AddProduct",
                RequestType = DbRequestType.Insert
            };
            DbRepository dbRepository = new DbRepository();
            var dbResponse = dbRepository.GetResponse<List<ProductDataAPIView>>(request);
            
            return Request.CreateResponse(HttpStatusCode.OK, dbResponse, "application/json");
        }
    }
}
