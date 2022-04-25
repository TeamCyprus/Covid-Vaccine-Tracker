using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using System.Data.SqlClient;
using Covid_Vaccine_Tracker.Business_Objects;
using System.Data;

namespace Covid_Vaccine_Tracker.Data_Access_Layer
{
    public static class TestDB
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
        public static bool CheckTestQuestion(string Userid, string Anwser)
        {
            bool anwserFound;
            string procedure = "[SpCheckTestQuestion]";
            var parameter = new { uid = Userid, anwser = Anwser };
            try
            {
                string conStr = GetConnection();

                using (IDbConnection db = new SqlConnection(conStr))
                {
                    anwserFound = db.ExecuteScalar<bool>(procedure, parameter, commandType: CommandType.StoredProcedure);
                }
            }
            catch (Exception ex)
            { throw ex; }

            return anwserFound;
        }
        public static string FindTestPersonId(string firstname, string lastname)
        {
            string usrID = string.Empty;
            string procedure = "[SpFindId_provider]";
            var parameter = new { fname = firstname, lname = lastname };

            try
            {
                string conStr = GetConnection();

                using (IDbConnection db = new SqlConnection(conStr))
                {
                    usrID = db.QuerySingle<string>(procedure, parameter, commandType: CommandType.StoredProcedure);
                }
            }
            catch (Exception ex)
            { throw ex; }

            return usrID;
        }
        public static string GetUsername_ProviderId(string userID)
        {
            string procedure = "[SpGetUsername_providerId]";
            string usrname = string.Empty;
            var parameter = new { uid = userID };

            try
            {
                string con = GetConnection();

                using (IDbConnection db = new SqlConnection(con))
                {
                    usrname = db.QuerySingle<string>(procedure, parameter, commandType: CommandType.StoredProcedure);
                }
            }
            catch (Exception ex)
            { throw ex; }

            return usrname;
        }
    }
}
