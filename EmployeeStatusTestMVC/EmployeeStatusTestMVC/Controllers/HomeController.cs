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

        public ActionResult Change(int id, FormCollection formCollection)
        {


            StaffInOutHistoryDAL.UpdateStatus(id, id, formCollection["Status"].ToString());

            return Redirect("Index");
        }

        public ActionResult Delete(int id)
        {

            StaffDAL.DeleteEmployee(id);

            return Redirect("Index");
        }

        public ActionResult Update(int id)
        {

            Models.Staff staff = Models.Staff.GetDetail(id);

            return View(staff);
        }

        public ActionResult Amend(Models.Staff StaffStuff)
        {

            StaffDAL.UpdateEmployeeDetails(StaffStuff);

            return Redirect("Index");
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