using System;
using System.Collections;
using System.Web.Mvc;
using MySql.Data.MySqlClient;

namespace FabPonto.Controllers
{
    public class HoursController : Controller
    {



        public void storeHoursOnDatabase(string entryTime , string exitTime)
        {
            MySqlConnection connection = new MySqlConnection("Database=FabContext;Data Source=localhost;User " +
                                                             "Id=root;Password=root");
            connection.Open();

            MySqlCommand insertCommand = connection.CreateCommand();
            const string SECONDS = ":00";
            string VARIABLEFROMDATABASE = entryTime+SECONDS + "','" + exitTime+SECONDS ;
            insertCommand.CommandText = "INSERT INTO hours (entry_time,exit_time) VALUES ('" + VARIABLEFROMDATABASE +"')";
            insertCommand.ExecuteNonQuery();

        }


        public bool ValidateFiveLenght(string entryTimeLower, string exitTimeLower)
        {
            const int timeLength = 5;
            if (entryTimeLower.Length == timeLength && exitTimeLower.Length == timeLength)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        public bool ValidateTwoPointsOnHours(string entryTimeLower, string exitTimeLower)
        {
            const int POSITIONOFTWOPOINTS = 2;
            char pointOnEntry = entryTimeLower[POSITIONOFTWOPOINTS];
            char pointOnExit = exitTimeLower[POSITIONOFTWOPOINTS];

            const char TWOPOINTS = ':';

            if (pointOnEntry == TWOPOINTS && pointOnExit == TWOPOINTS)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        public bool ValidateHoursIsInLimit(string entryTimeLower, string exitTimeLower)
        {
            string entry_hour = Convert.ToString(entryTimeLower[0]) + Convert.ToString(entryTimeLower[1]);
            int entry_hour_int = Convert.ToInt32(entry_hour);

            string exit_hour = Convert.ToString(exitTimeLower[0]) + Convert.ToString(exitTimeLower[1]);
            int exit_hour_int = Convert.ToInt32(exit_hour);

            if (entry_hour_int >= 0 && entry_hour_int <= 23 &&
                exit_hour_int >= 0 && exit_hour_int <= 23)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        public ArrayList InsertErrors(bool exitBiggerEntry ,bool  hourInOfLimits ,
                                      bool minutesInOfLimits , bool timeNotEmpty)
        {
            const string INVALIDTIME = "Erro ao cadastrar hora. Siga o exemplo do campo.";
            const string TIMENULL = "Campo de hora não pode ser vazio(nulo)";
            const string ERROREXITBIGGERENTRY = "Hora de saída não pode ser antes de entrada.";
            const string ERRORHOURSOUTOFLIMITS = "Hora não pode ser menor que 00 nem maior que 23";
            const string ERRORMINUTESOUTOFLIMITS = "Minutos não pode ser menor que 00 nem maior que 59";

            ArrayList errors = new ArrayList();
            errors.Add(INVALIDTIME);

            if (!timeNotEmpty)
            {
                errors.Add(TIMENULL);
            }else if (!exitBiggerEntry)
            {
                errors.Add(ERROREXITBIGGERENTRY);
            }
            else if (!hourInOfLimits)
            {
                errors.Add(ERRORHOURSOUTOFLIMITS);
            }
            else if (!minutesInOfLimits)
            {
                errors.Add(ERRORMINUTESOUTOFLIMITS);
            }
            else
            {
                //Nothing to do
            }

            return errors;
        }


        public bool ValidateTimeContainsOnlyNumber(string entryTimeLower , string exitTimeLower)
        {
            string entry_hour = null, exit_hour= null , entry_minute = null , exit_minute = null;
            int entry_hour_int = -1, exit_hour_int = -1 , entry_minute_int = -1 , exit_minute_int = -1;
            try
            {
                entry_hour = Convert.ToString(entryTimeLower[0]) + Convert.ToString(entryTimeLower[1]);
                entry_hour_int = Convert.ToInt32(entry_hour);

                exit_hour = Convert.ToString(exitTimeLower[0]) + Convert.ToString(exitTimeLower[1]);
                exit_hour_int = Convert.ToInt32(exit_hour);

                entry_minute = Convert.ToString(entryTimeLower[3]) + Convert.ToString(entryTimeLower[4]);
                entry_minute_int = Convert.ToInt32(entry_minute);

                exit_minute = Convert.ToString(exitTimeLower[3]) + Convert.ToString(exitTimeLower[4]);
                exit_minute_int = Convert.ToInt32(exit_minute);
            }
            catch (FormatException exception)
            {
                return false;
            }

            return true;

        }


        public bool ValidateMinutesIsInLimits(string entryTimeLower, string exitTimeLower)
        {
            string entry_hour = Convert.ToString(entryTimeLower[3]) + Convert.ToString(entryTimeLower[4]);
            int entry_minute_int = Convert.ToInt32(entry_hour);

            string exit_hour = Convert.ToString(exitTimeLower[3]) + Convert.ToString(exitTimeLower[4]);
            int exit_minute_int = Convert.ToInt32(exit_hour);

            if (entry_minute_int >= 00 && entry_minute_int <=59 &&
                exit_minute_int >= 00 && exit_minute_int <= 59)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        public bool ValidateTimeIsNotEmpty(string entryTimeLower, string exitTimeLower)
        {
            const string emptyString = "";
            if (entryTimeLower != emptyString && exitTimeLower != emptyString)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        public  bool AssertExitTimeIsAfterThanEntryTime(string entry_time, string exit_time)
        {

            string entry_hour = Convert.ToString(entry_time[0]) + Convert.ToString(entry_time[1]);
            int entry_hour_int = Convert.ToInt32(entry_hour);

            string exit_hour = Convert.ToString(exit_time[0])  + Convert.ToString(exit_time[1]);
            int exit_hour_int = Convert.ToInt32(exit_hour);

            if (exit_hour_int > entry_hour_int)
            {
                return true;
            }

            else if (exit_hour == entry_hour && AssertExitMinuteIsAfterEntryMinute(entry_time, exit_time))
            {
                return true;
            }
            else
            {
                return false;
            }
        }



        public bool AssertExitMinuteIsAfterEntryMinute(string entryTime, string exitTime)
        {
            string entry_minute = Convert.ToString(entryTime[3]) + Convert.ToString(entryTime[4]);

            int entry_minute_int = Convert.ToInt32(entry_minute);

            string exit_minute = Convert.ToString(exitTime[3]) + Convert.ToString(exitTime[4]);
            int exit_minute_int = Convert.ToInt32(exit_minute);

            if (exit_minute_int > entry_minute_int)
            {
                return true;
            }else
            {
                return false;
            }
        }


    }
}