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
    public static class CDCDB
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
        public static CDC GetCDCUser(string username)
        {
            CDC cdcUsr = new CDC();
            string procedure = "[SpFindCDCUsr]";
            var parameter = new { usr = username };

            try
            {
                string conStr = GetConnection();

                using(IDbConnection db = new SqlConnection(conStr))
                {
                    cdcUsr = db.QuerySingle<CDC>(procedure, parameter, commandType: CommandType.StoredProcedure);
                }
            }
            catch(Exception ex)
            { throw ex; }

            return cdcUsr;
        }

        public static bool VerifyCDCUser(string pId, string Fname, string Mname, string Lname)
        {
            bool cdcUserFound;
            string procedure = "[SpVerifyCDCUser]";
            var parameters = new { id = pId, fname = Fname, mname = Mname, lname = Lname };

            try
            {
                string conStr = GetConnection();

                using (IDbConnection db = new SqlConnection(conStr))
                {
                    cdcUserFound = db.ExecuteScalar<bool>(procedure, parameters, commandType: CommandType.StoredProcedure);
                }
            }
            catch (Exception ex)
            { throw ex; }

            return cdcUserFound;
        }
    }
}
