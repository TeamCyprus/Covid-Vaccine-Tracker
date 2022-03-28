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
        public static bool VerifyUsername(string Entered_username)
        {
            bool foundUser = false;
            string username = string.Empty;
            string procedure = "[SpGetUsername]";
            var parameter = new { usr = Entered_username };

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

            if (!string.IsNullOrEmpty(username))
                foundUser = true;

            return foundUser;
        }
        public static string GetPassword(string username)
        {
            string pwd;
            string procedure = "[SpGetPassword]";
            var parameter = new { urs = username };

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
    }
}
