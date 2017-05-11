using System.Configuration;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using FabPonto.DAL;
using FabPonto.Models;
/*
namespace FabPonto.Controllers
{
    public class CsvReport : Report
    {
        FabContext _db = FabContext.GetFabContextInstance();

        public override void generateReport()
        {

            DbSet<User> users;
            users = _db.Users;
            string cmd = null;
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
                    cmd = userName + availability;
                }
            }

            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM Customers"))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        using (DataTable dt = new DataTable())
                        {
                            sda.Fill(dt);

                            //Build the CSV file data as a Comma separated string.
                            string csv = string.Empty;

                            foreach (DataColumn column in dt.Columns)
                            {
                                //Add the Header row for CSV file.
                                csv += column.ColumnName + ',';
                            }

                            //Add new line.
                            csv += "\r\n";

                            foreach (DataRow row in dt.Rows)
                            {
                                foreach (DataColumn column in dt.Columns)
                                {
                                    //Add the Data rows.
                                    csv += row[column.ColumnName].ToString().Replace(",", ";") + ',';
                                }

                                //Add new line.
                                csv += "\r\n";
                            }

                            //Download the CSV file.
                            Response.Clear();
                            Response.Buffer = true;
                            Response.AddHeader("content-disposition", "attachment;filename=SqlExport.csv");
                            Response.Charset = "";
                            Response.ContentType = "application/text";
                            Response.Output.Write(csv);
                            Response.Flush();
                            Response.End();
                        }
                    }
                }
            }

        }
    }
}*/