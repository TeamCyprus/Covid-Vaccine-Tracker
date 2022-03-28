using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Covid_Vaccine_Tracker.Business_Objects;
using System.Data.SqlClient;
using Dapper;
using System.Data;

namespace Covid_Vaccine_Tracker.Data_Access_Layer
{
    public static class VtcksDB
    {
        public static string GetConnection()
        {
            // this method gets the connection string to the database from
            // the DBConnector class

            string conStr = null;

            try
            {
                conStr = DBConnector.GetConnectionString();
            }
            catch (Exception ex)
            { throw ex; }

            return conStr;
        }
        public static bool VerifyVtck(string vId)
        {
            bool vtckFound;
            string procedure = "[SpVerifyVtck]";
            var parameters = new { vtck = vId};

            try
            {
                string conStr = GetConnection();

                using (IDbConnection db = new SqlConnection(conStr))
                {
                    vtckFound = db.ExecuteScalar<bool>(procedure, parameters, commandType: CommandType.StoredProcedure);
                }
            }
            catch (Exception ex)
            { throw ex; }

            return vtckFound;
        }
        public static bool VerifyProviderAccess(string vId)
        {
            bool vtckFound;
            string procedure = "[SpVerifyProviderAccess]";
            var parameters = new { vPin = vId };

            try
            {
                string conStr = GetConnection();

                using (IDbConnection db = new SqlConnection(conStr))
                {
                    vtckFound = db.ExecuteScalar<bool>(procedure, parameters, commandType: CommandType.StoredProcedure);
                }
            }
            catch (Exception ex)
            { throw ex; }

            return vtckFound;
        }
    }
}
