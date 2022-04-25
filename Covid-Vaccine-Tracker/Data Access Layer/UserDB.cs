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
    public static class UserDB
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
        public static List<User> GetUsers()
        {
            List<User> users = new List<User>();
            string procedure = "[SpGetUsers]";

            try
            {
                string conStr = GetConnection();

                using(IDbConnection db = new SqlConnection(conStr))
                {
                    users = db.Query<User>(procedure, commandType: CommandType.StoredProcedure).ToList();
                }
            }
            catch(Exception ex)
            { throw ex; }

            return users;
        }
        public static string GetUsername(string uName)
        {
            string username;
            string procedure = "[SpGetUsername]";
            var parameter = new { usr = uName };

            try
            {
                string conStr = GetConnection();

                using(IDbConnection db = new SqlConnection(conStr))
                {
                    username = db.QuerySingle<string>(procedure, parameter, commandType: CommandType.StoredProcedure);
                }
            }
            catch(Exception ex)
            { throw ex; }

            return username;
        }
        public static bool VerifyUsername(string username)
        {
            bool userFound;
            string procedure = "[SpVerifyUsername]";
            var parameters = new { user = username };

            try
            {
                string conStr = GetConnection();

                using (IDbConnection db = new SqlConnection(conStr))
                {
                    userFound = db.ExecuteScalar<bool>(procedure, parameters, commandType: CommandType.StoredProcedure);
                }
            }
            catch (Exception ex)
            { throw ex; }

            return userFound;
        }
        public static string GetPassword(string username)
        {
            string pwd;
            string procedure = "[SpGetPassword]";
            var parameter = new { usr = username };

            try
            {
                string conStr = GetConnection();

                using(IDbConnection db = new SqlConnection(conStr))
                {
                    pwd = db.QuerySingle<string>(procedure, parameter, commandType: CommandType.StoredProcedure);
                }
            }
            catch(Exception ex)
            { throw ex; }

            return pwd;
        }
        public static User GetUserCredentials(string usrname)
        {
            User requestedUsr = new User();
            string procedure = "[SpGetUserAccountType]";
            var parameter = new { usr = usrname };

            try
            {
                string conStr = GetConnection();

                using (IDbConnection db = new SqlConnection(conStr))
                {
                    requestedUsr = db.QuerySingle<User>(procedure, parameter, commandType: CommandType.StoredProcedure);
                }
            }
            catch(Exception ex)
            { throw ex; }

            return requestedUsr;
        }
        public static User GetUserInfo(string username)
        {
            User requestedUsr = new User();
            string procedure = "[SpGetUserInfo]";
            var parameter = new { usrname = username };

            try
            {
                string conStr = GetConnection();

                using (IDbConnection db = new SqlConnection(conStr))
                {
                    requestedUsr = db.QuerySingle<User>(procedure, parameter, commandType: CommandType.StoredProcedure);
                }
            }
            catch (Exception ex)
            { throw ex; }

            return requestedUsr;
        }
        public static string RecoverProviderUsername(string firstname, string lastname)
        {
            string usrname = string.Empty;
            string procedure = "[SpRecoverProviderUsername]";
            var parameter = new { fname = firstname, lname = lastname };

            try
            {
                string conStr = GetConnection();

                using (IDbConnection db = new SqlConnection(conStr))
                {
                    usrname = db.QuerySingle<string>(procedure, parameter, commandType: CommandType.StoredProcedure);
                }
            }
            catch (Exception ex)
            { throw ex; }

            return usrname;
        }
        public static string RecoverCDCUsername(string firstname, string lastname)
        {
            string usrname = string.Empty;
            string procedure = "[SpRecoverCDCUsername]";
            var parameter = new { fname = firstname, lname = lastname };

            try
            {
                string conStr = GetConnection();

                using (IDbConnection db = new SqlConnection(conStr))
                {
                    usrname = db.QuerySingle<string>(procedure, parameter, commandType: CommandType.StoredProcedure);
                }
            }
            catch (Exception ex)
            { throw ex; }

            return usrname;
        }
        public static string RecoverCDCUserId(string firstname, string lastname)
        {
            string usrID = string.Empty;
            string procedure = "[SpFindId_cdc]";
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
        public static string RecoverProviderUserId(string firstname, string lastname)
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
        public static bool AddUser(User user, string encryptPW)
        {
            // variable to determine if succesful insert or not
            bool isSuccess;
            // variable to hold number of rows changed
            int rowsAffected;
            // specify stored procedure
            string procedure = "[SpAddUser]";
            // this is how you specify multiple parameters to pass into a stored procedure
            // note the name of the parameters has to be the same inside the stored procedure

            var parameters = new
            {
                username = user.Username,
                password = encryptPW,
                userType = user.User_Type
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
        public static bool UpdateUser(User user)
        {
            // variable to determine if succesful insert or not
            bool isSuccess;
            // variable to hold number of rows changed
            int rowsAffected;
            // specify stored procedure
            string procedure = "[SpUpdateUser]";
            // this is how you specify multiple parameters to pass into a stored procedure
            // note the name of the parameters has to be the same inside the stored procedure

            var parameters = new
            {
                username = user.Username,
                password = user.Password,
                userType = user.User_Type
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
        public static bool UpdatePassword(string usrname, string passwd)
        {
            // variable to determine if succesful insert or not
            bool isSuccess;
            // variable to hold number of rows changed
            int rowsAffected;
            // specify stored procedure
            string procedure = "[SpUpdatePwd]";
            // this is how you specify multiple parameters to pass into a stored procedure
            // note the name of the parameters has to be the same inside the stored procedure

            var parameters = new { user = usrname, pwd = passwd };

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
        }// methods to recive user ids from username
        public static string GetUserId_Provider(string username)
        {
            string procedure = "[SpGetUserId_provider]";
            string usrname = string.Empty;
            var parameter = new { usr = username };

            try
            {
                string con = GetConnection();

                using (IDbConnection db = new SqlConnection(con))
                {
                    usrname = db.QuerySingle<string>(procedure, parameter, commandType: CommandType.StoredProcedure);
                }
            }
            catch(Exception ex)
            { throw ex; }

            return usrname;
        }
        public static string GetUserId_Cdc(string username)
        {
            string procedure = "[SpGetUserId_cdc]";
            string usrname = string.Empty;
            var parameter = new { usr = username };

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
        public static string GetUsername_CdcId(string userID)
        {
            string procedure = "[SpGetUsername_CdcId]";
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
