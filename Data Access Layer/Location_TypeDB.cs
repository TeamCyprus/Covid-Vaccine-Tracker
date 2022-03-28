using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// Need using statements for project namespaces and other libraries
using Covid_Vaccine_Tracker.Business_Objects;
using System.Data.SqlClient;
using Dapper;
using System.Data;

namespace Covid_Vaccine_Tracker.Data_Access_Layer
{
    public static class Location_TypeDB
    {
        public static string GetConnection()
        {
            // GetConnection retrieves the connection string from the app.config file
            string conStr = null;

            try
            {
                conStr = DBConnector.GetConnectionString();
            }
            catch (Exception ex)
            { throw ex; }

            return conStr;
        }
        public static List<Location_Types> GetLocationTypes()
        {
            List<Location_Types> locations = new List<Location_Types>();
            string procedure = "[SpGetLocations]";

            try
            {
                string conStr = GetConnection();

                using(IDbConnection db = new SqlConnection(conStr))
                {
                    locations = db.Query<Location_Types>(procedure, commandType: CommandType.StoredProcedure).ToList();
                }
            }
            catch(Exception ex)
            { throw ex; }

            return locations;
        }
        public static Location_Types GetLocationType(string lType)
        {
            Location_Types location = new Location_Types();
            string procedure = "[SpGetLocation]";
            var parameter = new { code = lType };

            try
            {
                string conStr = GetConnection();

                using (IDbConnection db = new SqlConnection(conStr))
                {
                    location = db.QuerySingle<Location_Types>(procedure, commandType: CommandType.StoredProcedure);
                }
            }
            catch (Exception ex)
            { throw ex; }

            return location;
        }
    }
}
