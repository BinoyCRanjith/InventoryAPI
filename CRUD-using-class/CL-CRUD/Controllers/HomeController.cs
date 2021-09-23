using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Domain;

namespace CL_CRUD.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public SqlConnection sqlConnection;
        public SqlCommand sqlCommand;
        public HomeController()
        {
            sqlConnection = new SqlConnection(@"Data Source=LAPTOP-U5N06BA6\VARUN;Initial Catalog=dbTestPurpose;User ID=sa;Password=1234");
            sqlConnection.Open();
        }

        public ActionResult Index()
        {
            //List To Page - But this is only for demo not for production purpose. For that we have another method
            sqlCommand = new SqlCommand("select * from tblStudent", sqlConnection);
            List<StudentDetails> students = new List<StudentDetails>();
            SqlDataReader dataReader = sqlCommand.ExecuteReader();
            while (dataReader.Read())
            {
                StudentDetails studentDetails = new StudentDetails
                {
                    ID = Convert.ToInt32(dataReader.GetValue(0)),
                    Name = dataReader.GetValue(1).ToString(),
                    Age  = dataReader.GetValue(2).ToString()
                };
                students.Add(studentDetails);
            }
            ViewBag.List = students;
            return View();
        }

        // GET: Home/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Home/Create
        public ActionResult Create()
        {
            return View();
        }

        //POST: Home/Create
        [HttpPost]
        public ActionResult Create(StudentDetails details)
        {
            try
            {
                sqlCommand = new SqlCommand("Insert into tblStudent(Name,Age)Values(@Name,@Age)",sqlConnection);
                sqlCommand.Parameters.AddWithValue("@Name", details.Name);
                sqlCommand.Parameters.AddWithValue("@Age", details.Age);
                sqlCommand.ExecuteNonQuery();
                TempData["Message"] = "Saved Data";
                sqlConnection.Close();
                // TODO: Add insert logic here
               // ViewBag.Message = "Hurray data saved";
                return RedirectToAction("Index");
            }
            catch(Exception ex)
            {
                return View();
            }
        }

        // GET: Home/Edit/5
        public ActionResult Edit(int id)
        {
            sqlCommand = new SqlCommand("select * from tblStudent where ID="+id, sqlConnection);
            StudentDetails studentDetails = new StudentDetails();
            SqlDataReader dataReader = sqlCommand.ExecuteReader();
            while (dataReader.Read())
            {
                studentDetails = new StudentDetails
                {
                    ID = Convert.ToInt32(dataReader.GetValue(0)),
                    Name = dataReader.GetValue(1).ToString(),
                    Age = dataReader.GetValue(2).ToString()
                };
               
            }
            ViewBag.Binoy = "welcome";
            return View(studentDetails);
        }

        // POST: Home/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Home/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Home/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
