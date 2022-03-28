using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// need using statement below to access app.config file to get connection string 
// also have to add a reference to it in solution explorer
using System.Configuration;
using System.IO;

namespace Covid_Vaccine_Tracker.Data_Access_Layer
{
    public static class DBConnector
    {

        // orginal con string name in app.config trying something new
        // "Covid_Vaccine_Tracker.Properties.Settings.CovidVax_TrackerConnectionString"
        // must pull the connection string out of the app.config file
        public static string GetConnectionString()
        {
            string connectionString;

            try
            {
                connectionString = ConfigurationManager.ConnectionStrings["Covid_Vaccine_Tracker_Connection"].ConnectionString;
            }
            catch (Exception ex)
            { throw ex; }

            if (string.IsNullOrEmpty(connectionString))
                throw new ArgumentException("Error getting connection string");

            else
                return connectionString;
        }
        //public static string GetConnectionString()
        //{
        //    var conStr = string.Empty;
        //    // this method reads connection string from a file so conString is not on github
        //    try
        //    {
        //        using(var sReader = new StreamReader("Connection.txt"))
        //        {
        //            conStr = sReader.ReadLine();
        //        }
        //    }
        //    catch(Exception ex)
        //    { throw ex; }

        //    return conStr;
        //}
    }
}
