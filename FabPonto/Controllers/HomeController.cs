using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using CsvHelper;
using FabPonto.DAL;
using DataTables.AspNet.Core;
using DataTables.AspNet.Mvc5;
using Newtonsoft.Json;

namespace FabPonto.Controllers
{
    public class HomeController : Controller
    {
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
            using (var db = new FabContext())
            {
                var dayOfWeek = db.DaysOfWeek.FirstOrDefault(day => day.Name == name);
                var schedule = db.Schedules.FirstOrDefault(sched => sched.Starting == starting &&
                                                                     sched.Ending == ending);
                var workday = db.Workdays.FirstOrDefault(wd => wd.DayOfWeekID == dayOfWeek.ID &&
                                                                wd.ScheduleID == schedule.ID);
                var user = db.Users.First();

                workday?.Users.Add(user);
                db.SaveChanges();

                return new JsonResult { Data = new {status = true} };
            }
        }

        [HttpPost]
        public ActionResult RemoveAvailability(Dictionary<string, string> availability)
        {
            var name = availability["name"];
            var starting = availability["starting"];
            var ending = availability["ending"];
            using (var db = new FabContext())
            {
                var dayOfWeek = db.DaysOfWeek.FirstOrDefault(day => day.Name == name);
                var schedule = db.Schedules.FirstOrDefault(sched => sched.Starting == starting &&
                                                                     sched.Ending == ending);
                var workday = db.Workdays.FirstOrDefault(wd => wd.DayOfWeekID == dayOfWeek.ID &&
                                                                wd.ScheduleID == schedule.ID);
                var currentUser = db.Users.First();

                workday?.Users.Remove(currentUser);
                db.SaveChanges();
            }

            return new JsonResult { Data = new {status = true} };
        }

        [HttpGet]
        public ActionResult GetWorkdays()
        {
            object json;
            using (var db = new FabContext())
            {
                var currentUser = db.Users.First();
                var workDays = currentUser.Workdays;
                json = JsonConvert.SerializeObject(workDays, Formatting.Indented, new JsonSerializerSettings
                {
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                });
            }

            return Json(json, JsonRequestBehavior.AllowGet);
        }

        private IEnumerable<Dictionary<string, string>> GetWorkdayData()
        {
            var workdayData = new List<Dictionary<string, string>>();

            using (var db = new FabContext())
            {
                foreach (var workday in db.Workdays.ToList())
                {
                    var dayOfWeek = db.DaysOfWeek.Find(workday.DayOfWeekID);
                    var schedule = db.Schedules.Find(workday.ScheduleID);
                    var workdayConcat = new Dictionary<string, string>
                    {
                        {"Name", dayOfWeek?.Name},
                        {"Starting", schedule?.Starting},
                        {"Ending", schedule?.Ending}
                    };

                    workdayData.Add(workdayConcat);
                }
            }
            return workdayData;
        }

        public FileContentResult DownloadCSV()
        {
            GenerateReport();
            var fileBytes = System.IO.File.ReadAllBytes("availabilityReporter.csv");

            return File(fileBytes, "text/csv", "availabilityReporter.csv");
        }

        public void GenerateReport()
        {
            using (var csv = new CsvWriter(new StreamWriter("availabilityReporter.csv")))
            {
                csv.WriteField("Nome");
                csv.WriteField("Disponibilidade");
                csv.NextRecord();
                using (var db = new FabContext())
                {
                    foreach (var user in db.Users.ToList())
                    {
                        var userName = user.Name;
                        var workdays = user.Workdays;
                        var availability = "";
                        foreach (var workday in workdays)
                        {
                            var dayID = workday.DayOfWeekID;
                            var schedID = workday.ScheduleID;
                            var dayOfWeek = db.DaysOfWeek.FirstOrDefault(day => day.ID == dayID);
                            var schedule = db.Schedules.FirstOrDefault(sched => sched.ID == schedID);
                            availability += dayOfWeek.Name + " das " + schedule.Starting + " às " + schedule.Ending +
                                            '\n';
                        }
                        csv.WriteField(userName);
                        csv.WriteField(availability);
                        csv.NextRecord();
                    }
                }
            }
        }
    }
}