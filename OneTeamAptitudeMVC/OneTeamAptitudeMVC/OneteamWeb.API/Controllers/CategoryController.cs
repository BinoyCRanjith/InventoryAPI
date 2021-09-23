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

namespace OneteamWeb.API.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Category
        public ActionResult CategoryHomeMain()
        {
            DbRequestBase request = new DbRequestBase
            {
                InputJson = new { }.ToJson(),
                ProcedureName = "ShowCategoryMain",
                RequestType = DbRequestType.Select
            };
            DbRepository dbRepository = new DbRepository();
            var dbResponse = dbRepository.GetResponse<List<SubCategoryDataAPI>>(request);


            return View(dbResponse.Data);
        }
    }
}