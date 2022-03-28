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

        public static bool VerifyCDCUser( string Fname, string Lname)
        {
            bool cdcUserFound;
            string procedure = "[SpVerifyCDCUser]";
            var parameters = new {firstname = Fname, lastname = Lname };

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
        public static bool VerifyCDCId(string CDCid)
        {
            bool providerIdFound;
            string procedure = "[SpVerifyCdcId]";
            var parameters = new { id = CDCid };

            try
            {
                string conStr = GetConnection();

                using (IDbConnection db = new SqlConnection(conStr))
                {
                    providerIdFound = db.ExecuteScalar<bool>(procedure, parameters, commandType: CommandType.StoredProcedure);
                }
            }
            catch (Exception ex)
            { throw ex; }

            return providerIdFound;
        }
        public static bool AddCDCuser(CDC cdc_usr)
        {
            bool isSuccess;
            int rowsAffected;
            string procedure = "[SpAddCDCUser]";

            var parameters = new
            {
                id = cdc_usr.Id,
                usrname = cdc_usr.Username,
                fname = cdc_usr.First_name,
                lname = cdc_usr.Last_name,
            };

            try
            {
                string connectionStr = GetConnection();
                using (IDbConnection db = new SqlConnection(connectionStr))
                {
                    rowsAffected = db.Execute(procedure, parameters, commandType: CommandType.StoredProcedure);
                }
            }
            catch (Exception ex)
            { throw ex; }
            isSuccess = rowsAffected > 0 ? true : false;
            return isSuccess;
        }
        public static bool VerifyUsername(string username)
        {
            bool usernameFound;
            string procedure = "[SpVerifyUsername]";
            var parameters = new { user = username};

            try
            {
                string conStr = GetConnection();

                using (IDbConnection db = new SqlConnection(conStr))
                {
                    usernameFound = db.ExecuteScalar<bool>(procedure, parameters, commandType: CommandType.StoredProcedure);
                }
            }
            catch (Exception ex)
            { throw ex; }

            return usernameFound;
        }
    }
}
