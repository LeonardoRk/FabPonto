using System.Configuration;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using CsvHelper;
using FabPonto.DAL;
using FabPonto.Models;
/*
namespace FabPonto.Controllers
{
    public class CsvReport
    {
        private readonly FabContext _db = new FabContext();

        public void generateReport()
        {

            using (var csv = new CsvWriter(new StreamWriter("availabilityReporter.csv")))
            {
                var users = _db.Users;
                foreach (var user in users)
                {
                    var userName = user.Name;
                    var workdays = user.Workdays;
                    var availability = "";
                    foreach (var workday in workdays)
                    {
                        var dayID = workday.DayOfWeekID;
                        var schedID = workday.ScheduleID;
                        var dayOfWeek = _db.DaysOfWeek.FirstOrDefault(day => day.ID == dayID);
                        var schedule = _db.Schedules.FirstOrDefault(sched => sched.ID == schedID);
                        availability += dayOfWeek.Name + " das " + schedule.Starting + " às " + schedule.Ending + '\n';
                    }
                    csv.WriteField(userName);
                    csv.WriteField(availability);
                    csv.NextRecord();
                }
            }

        }
    }
}*/