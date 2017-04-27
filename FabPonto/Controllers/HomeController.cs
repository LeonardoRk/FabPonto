using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using FabPonto.DAL;
using DataTables.AspNet.Core;
using DataTables.AspNet.Mvc5;

namespace FabPonto.Controllers
{
    public class HomeController : Controller
    {

        private FabContext db = new FabContext();

        public ActionResult Index()
        {
            return View();
        }


        public ActionResult About()
        {


            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

//        public ActionResult AvailabilityRegister()
//        {
//            var workdays = new List<List<object>>();
//
//            foreach (var workday in db.Workdays.ToList())
//            {
//                var dayOfWeek = db.DaysOfWeek.Find(workday.DayOfWeekID);
//                var schedule = db.Schedules.Find(workday.ScheduleID);
//                var list = new List<object> {dayOfWeek, schedule};
//
//                workdays.Add(list);
//            }
//
//            ViewBag.DaysOfWeek = db.DaysOfWeek;
//            ViewBag.Schedules = db.Schedules;
//            ViewBag.Workdays = workdays;
//
//            return View();
//        }

        public ActionResult PageData(IDataTablesRequest request)
        {
            
            // Nothing important here. Just creates some mock data.
            var data = Models.SampleEntity.GetSampleData();

            // Global filtering.
            // Filter is being manually applied due to in-memmory (IEnumerable) data.
            // If you want something rather easier, check IEnumerableExtensions Sample.
            var filteredData = data.Where(_item => _item.Name.Contains(request.Search.Value));

            // Paging filtered data.
            // Paging is rather manual due to in-memmory (IEnumerable) data.
            var dataPage = filteredData.Skip(request.Start).Take(request.Length);

            // Response creation. To create your response you need to reference your request, to avoid
            // request/response tampering and to ensure response will be correctly created.
            var response = DataTablesResponse.Create(request, data.Count(), filteredData.Count(), dataPage);

            // Easier way is to return a new 'DataTablesJsonResult', which will automatically convert your
            // response to a json-compatible content, so DataTables can read it when received.
            return new DataTablesJsonResult(response, JsonRequestBehavior.AllowGet);
        }
    }
}