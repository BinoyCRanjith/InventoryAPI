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
    public class StudentJsonController : Controller
    {
        // GET: StudentJson
        public ActionResult Index(int ID = 0)
        {

            DbRequestBase request = new DbRequestBase
            {
                InputJson = new { ID }.ToJson(),
                ProcedureName = "StudentList",
                RequestType = DbRequestType.Select
            };
            // 
            DbRepository dbRepository = new DbRepository();
            var dbResponse = dbRepository.GetResponse<List<StudentViewModel>>(request);
            return View(dbResponse.Data);
        }

        [HttpGet]
        public ActionResult AddEdit(int id = 0)
        {
            StudentViewModel StudentViewModel = new StudentViewModel();
            SetViewBag();
            if (id > 0)
            {
                DbRequestBase request = new DbRequestBase
                {
                    InputJson = new { ID = id }.ToJson(),
                    ProcedureName = "StudentDetails",
                    RequestType = DbRequestType.Select
                };
                DbRepository dbRepository = new DbRepository();
                var dbResponse = dbRepository.GetResponse<StudentViewModel>(request);
                StudentViewModel = dbResponse.Data;
            }
            return View(StudentViewModel);
        }
        [HttpPost]
        public ActionResult Save(StudentViewModel user)
        {

            DbRequestBase request = new DbRequestBase
            {
                InputJson = user.ToJson(),
                ProcedureName = "StudentSave",
                RequestType = DbRequestType.Insert
            };
            DbRepository dbRepository = new DbRepository();
            var dbResponse = dbRepository.GetResponse<List<StudentViewModel>>(request);
            TempData["Message"] = user.Id > 0 ? "User updated Successfully" : "new user saved successfully";
            return RedirectToAction("index");
        }
        public void SetViewBag()
        {
            List<UserDepartment> userDepartments = new List<UserDepartment>();
            userDepartments.Add(new UserDepartment() { DepartmentId = 1, DepartmentName = "A" });

            List<UserRoll> userRolls = new List<UserRoll>();
            userRolls.Add(new UserRoll() { RollId = 1, RollName = "A" });
            
            ViewBag.UserDepartment = userDepartments;//UserDTO.SelectAllDepartment();
            ViewBag.UserRoll = userRolls;// UserDTO.Usroll();
        }
    }
}