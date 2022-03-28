using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// must include these using statements below to access other namespaces in project 
// and to use dapper and sql 
using Covid_Vaccine_Tracker.Business_Objects;
using System.Data.SqlClient;
using Dapper;
using System.Data;


namespace Covid_Vaccine_Tracker.Data_Access_Layer
{
    public static class RacesDB
    {
        public static string GetConnection()
        {
            string conStr = null;

            try
            {
                conStr = DBConnector.GetConnectionString();
            }
            catch (Exception ex)
            { throw ex; }

            return conStr;
        }
        public static List<Race> GetRaces()
        {
            List<Race> allRaces = new List<Race>();
            string procedure = "[SpGetRaces]";

            try
            {
                string conStr = GetConnection();

                using(IDbConnection db = new SqlConnection(conStr))
                {
                    allRaces = db.Query<Race>(procedure, commandType: CommandType.StoredProcedure).ToList();
                }
            }
            catch(Exception ex)
            { throw ex; }

            return allRaces;
        }
        public static Race GetRace(string Rcode)
        {
            Race requestedRace = new Race();
            string procedure = "[SpGetRace]";
            var parameter = new { code = Rcode };

            try
            {
                string conStr = GetConnection();

                using(IDbConnection db = new SqlConnection(conStr))
                {
                    requestedRace = db.QuerySingle<Race>(procedure, parameter, commandType: CommandType.StoredProcedure);  
                }
            }
            catch(Exception ex)
            { throw ex; }

            return requestedRace;
        }
        // this method is used to return just a string value of the Race Type 
        // so values can be selected from Db from a combo box selection
        public static string GetRaceType(string Rcode)
        {
            string raceType;
            string procedure = "[SpGetRaceType]";
            var parameter = new { code = Rcode };

            try
            {
                string conStr = GetConnection();

                using (IDbConnection db = new SqlConnection(conStr))
                {
                    raceType = db.QuerySingle<string>(procedure, parameter, commandType: CommandType.StoredProcedure);
                }
            }
            catch (Exception ex)
            { throw ex; }

            return raceType;
        }
    }
}
