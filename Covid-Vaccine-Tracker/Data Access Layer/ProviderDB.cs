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
    public static class ProviderDB
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
        public static Provider GetProvider(string Uname)
        {
            Provider provider = new Provider();
            string procedure = "[SpFindProvider]";
            var parameter = new { usrname = Uname };

            try
            {
                string conStr = GetConnection();

                using(IDbConnection db = new SqlConnection(conStr))
                {
                    provider = db.QuerySingle<Provider>(procedure, parameter, commandType: CommandType.StoredProcedure);
                }
            }
            catch(Exception ex)
            { throw ex; }

            return provider;
        }
        public static bool VerifyProvider(string Fname, string Lname)
        {
            bool providerFound;
            string procedure = "[SpVerifyProvider]";
            var parameters = new {firstname = Fname, lastname = Lname };

            try
            {
                string conStr = GetConnection();

                using (IDbConnection db = new SqlConnection(conStr))
                {
                    providerFound = db.ExecuteScalar<bool>(procedure, parameters, commandType: CommandType.StoredProcedure);
                }
            }
            catch (Exception ex)
            { throw ex; }

            return providerFound;
        }
        public static bool VerifyProviderVtck(string Vtck, string Fname, string Lname)
        {
            bool providerFound;
            string procedure = "[SpVerifyProviderVtck]";
            var parameters = new { vPin = Vtck, firstname = Fname, lastname = Lname };

            try
            {
                string conStr = GetConnection();

                using (IDbConnection db = new SqlConnection(conStr))
                {
                    providerFound = db.ExecuteScalar<bool>(procedure, parameters, commandType: CommandType.StoredProcedure);
                }
            }
            catch (Exception ex)
            { throw ex; }

            return providerFound;
        }
        public static bool AddProvider(Provider provider)
        {
            // variable to determine if succesful insert or not
            bool isSuccess;
            // variable to hold number of rows changed
            int rowsAffected;
            // specify stored procedure
            string procedure = "[SpAddProvider]";
            // this is how you specify multiple parameters to pass into a stored procedure
            // note the name of the parameters has to be the same inside the stored procedure

            var parameters = new
            {
               id = provider.Id,
               username = provider.Username,
               fname = provider.First_Name,
               lname = provider.Last_Name,
               suffix = provider.Provider_Suffix,
               vpin = provider.Vtcks_Pin,
               organization = provider.Parent_Organization,
               adminLoc = provider.Administered_Location,
               locType = provider.Location_Type,
               street = provider.Location_Street_Address,
               city = provider.Location_City,
               county = provider.Location_County,
               state = provider.Location_State,
               zip = provider.Location_Zipcode
            };

            try
            {
                // get connection string
                string connectionStr = GetConnection();

                //create connection to database
                using (IDbConnection db = new SqlConnection(connectionStr))
                {
                    // since this is not a query must use execute
                    // execute will return the number of rows affected
                    // pass in the procedure the parameters and specify the command type
                    rowsAffected = db.Execute(procedure, parameters, commandType: CommandType.StoredProcedure);
                }
            }
            catch (Exception ex)
            { throw ex; }

            // if rowsAffected is greater then zero isSuccess = true if not = false
            isSuccess = rowsAffected > 0 ? true : false;
            // return insert status
            return isSuccess;
        }
        public static bool UpdateProvider(Provider provider)
        {
            // variable to determine if succesful insert or not
            bool isSuccess;
            // variable to hold number of rows changed
            int rowsAffected;
            // specify stored procedure
            string procedure = "[SpUpdateProvider]";
            // this is how you specify multiple parameters to pass into a stored procedure
            // note the name of the parameters has to be the same inside the stored procedure

            var parameters = new
            {
                id = provider.Id,
                username = provider.Username,
                fname = provider.First_Name,
                lname = provider.Last_Name,
                suffix = provider.Provider_Suffix,
                vpin = provider.Vtcks_Pin,
                parentOrg = provider.Parent_Organization,
                adminLoc = provider.Administered_Location,
                locType = provider.Location_Type,
                street = provider.Location_Street_Address,
                city = provider.Location_City,
                county = provider.Location_County,
                state = provider.Location_State,
                zip = provider.Location_Zipcode
            };

            try
            {
                // get connection string
                string connectionStr = GetConnection();

                //create connection to database
                using (IDbConnection db = new SqlConnection(connectionStr))
                {
                    // since this is not a query must use execute
                    // execute will return the number of rows affected
                    // pass in the procedure the parameters and specify the command type
                    rowsAffected = db.Execute(procedure, parameters, commandType: CommandType.StoredProcedure);
                }
            }
            catch (Exception ex)
            { throw ex; }

            // if rowsAffected is greater then zero isSuccess = true if not = false
            isSuccess = rowsAffected > 0 ? true : false;
            // return insert status
            return isSuccess;
        }
        public static bool VerifyProviderId(string Pid)
        {
            bool providerIdFound;
            string procedure = "[SpVerifyProviderId]";
            var parameters = new { id = Pid };

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
        public static bool VerifyUsername(string username)
        {
            bool usernameFound;
            string procedure = "[SpVerifyUsername]";
            var parameters = new { user = username };

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
