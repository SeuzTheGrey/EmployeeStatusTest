using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EmployeeStatusTestMVC.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {



            return View();
        }

        public ActionResult Login(FormCollection form)
        {
            List<Models.Staff> data = Models.Staff.GetStaffs();
            foreach (Models.Staff item in data)
            {
                if (form["Username"].ToString() == item.Username)
                {
                    Session["UserID"] = item.StaffID;
                    return Redirect("Home");
                }

            }
            return Redirect("Index");
        }

        public ActionResult Home()
        {
            List<Models.Staff> data = Models.Staff.GetStaffs();
            return View(data);
        }

        public ActionResult Card(int id)
        {

            Models.Staff staff = Models.Staff.GetDetail(id);

            return View(staff);

        }

        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(Models.Staff staff)
        {
            StaffDAL.InsertEmployee(staff);

            return Redirect("Home");
        }


        public ActionResult Change(FormCollection formCollection)
        {


            StaffInOutHistoryDAL.UpdateStatus(int.Parse(Request.Form["id"].ToString()), int.Parse(Session["UserID"].ToString()), Request.Form["Status"].ToString());

            return Redirect("Home");
        }

        public ActionResult Delete(int id)
        {

            StaffDAL.DeleteEmployee(id);

            return Redirect("\\Home\\Home");
        }

        public ActionResult Update(int id)
        {

            Models.Staff staff = Models.Staff.GetDetail(id);

            return View(staff);

        }

        public ActionResult Amend(Models.Staff smodel)
        {


            if (ModelState.IsValid)
            {

                StaffDAL.UpdateEmployeeDetails(smodel);

                return Redirect("Home");
            }
            else
            {
                return Redirect("Home");
            }


        }

        public ActionResult Report()
        {
            List<Models.Staff> data = Models.Staff.GetStaffs();

            return View(data);
        }
        public ActionResult ReportHistories(int id)
        {
            DatabaseDataSet.GetEmployeeHistoryDataTable getEmployeeHistories = StaffInOutHistoryDAL.GetEmployeeHistories(id);


            return View(getEmployeeHistories);
        }

        public ActionResult Exported()
        {
            Export.ExportReports();

            return Redirect("Index");
        }
    }
}