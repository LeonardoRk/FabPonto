using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using FabPonto.DAL;
using DataTables.AspNet.Core;
using DataTables.AspNet.Mvc5;
using Newtonsoft.Json;

namespace FabPonto.Controllers
{
    public class HomeController : Controller
    {

        private readonly FabContext _db = FabContext.GetFabContextInstance();

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

        public ActionResult AvailabilityRegister()
        {
            return View();
        }

        public ActionResult WorkTimeRegister()
        {
            return View();
        }

        public ActionResult PageData(IDataTablesRequest request)
        {
            var data = GetWorkdayData();

            // String to lower then to title case
            var searchedContent = new CultureInfo("pt-BR").TextInfo.ToTitleCase(request.Search.Value.ToLower());

            var filteredData = data.Where(dic => dic["Name"].Contains(searchedContent));
            var dataPage = filteredData.Skip(request.Start).Take(request.Length);

            var response = DataTablesResponse.Create(request, data.Count(), filteredData.Count(), dataPage);

            return new DataTablesJsonResult(response, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult AddAvailability(Dictionary<string, string> availability)
        {
            var name = availability["name"];
            var starting = availability["starting"];
            var ending = availability["ending"];
            var dayOfWeek = _db.DaysOfWeek.FirstOrDefault(day => day.Name == name);
            var schedule = _db.Schedules.FirstOrDefault(sched => sched.Starting == starting &&
                                                                 sched.Ending == ending);
            var workday = _db.Workdays.FirstOrDefault(wd => wd.DayOfWeekID == dayOfWeek.ID &&
                                                            wd.ScheduleID == schedule.ID);
            var user = _db.Users.First();

            workday?.Users.Add(user);
            _db.SaveChanges();

            return new JsonResult { Data = new {status = true} };
        }

        [HttpPost]
        public ActionResult RemoveAvailability(Dictionary<string, string> availability)
        {
            var name = availability["name"];
            var starting = availability["starting"];
            var ending = availability["ending"];
            var dayOfWeek = _db.DaysOfWeek.FirstOrDefault(day => day.Name == name);
            var schedule = _db.Schedules.FirstOrDefault(sched => sched.Starting == starting &&
                                                                 sched.Ending == ending);
            var workday = _db.Workdays.FirstOrDefault(wd => wd.DayOfWeekID == dayOfWeek.ID &&
                                                            wd.ScheduleID == schedule.ID);
            var currentUser = _db.Users.First();

            workday?.Users.Remove(currentUser);
            _db.SaveChanges();

            return new JsonResult { Data = new {status = true} };
        }

        [HttpGet]
        public ActionResult GetWorkdays()
        {
            var currentUser = _db.Users.First();
            var workDays = currentUser.Workdays;
            var json = JsonConvert.SerializeObject(workDays, Formatting.Indented, new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });
            
            return Json(json, JsonRequestBehavior.AllowGet);
        }

        private IEnumerable<Dictionary<string, string>> GetWorkdayData()
        {
            var workdayData = new List<Dictionary<string, string>>();

            foreach (var workday in _db.Workdays.ToList())
            {
                var dayOfWeek = _db.DaysOfWeek.Find(workday.DayOfWeekID);
                var schedule = _db.Schedules.Find(workday.ScheduleID);
                var workdayConcat = new Dictionary<string, string>
                {
                    {"Name", dayOfWeek?.Name},
                    {"Starting", schedule?.Starting},
                    {"Ending", schedule?.Ending}
                };

                workdayData.Add(workdayConcat);
            }
            return workdayData;
        }
    }
}