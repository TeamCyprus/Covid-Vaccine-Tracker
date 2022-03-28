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
    public static class SexesDB
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
        public static List<Sex> GetSexes()
        {
            List<Sex> allSexes = new List<Sex>();
            string procedure = "[SpGetSexes]";

            try
            {
                string conStr = GetConnection();

                using(IDbConnection db = new SqlConnection(conStr))
                {
                    allSexes = db.Query<Sex>(procedure, commandType: CommandType.StoredProcedure).ToList();
                }
            }
            catch(Exception ex)
            { throw ex; }

            return allSexes;
        }
        public static Sex GetSex(string sCode)
        {
            Sex requestedSex = new Sex();
            string procedure = "[SpGetSex]";
            var parameters = new { code = sCode };

            try
            {
                string conStr = GetConnection();

                using(IDbConnection db = new SqlConnection(conStr))
                {
                    requestedSex = db.QuerySingle<Sex>(procedure, parameters, commandType: CommandType.StoredProcedure);
                }
            }
            catch(Exception ex)
            { throw ex; }

            return requestedSex;
        }
        // this method is used to return just a string value of the sex Type 
        // so values can be selected from Db from a combo box selection
        public static string GetSexType(string Scode)
        {
            string sexType;
            string procedure = "[SpGetSexType]";
            var parameter = new { code = Scode };

            try
            {
                string conStr = GetConnection();

                using (IDbConnection db = new SqlConnection(conStr))
                {
                    sexType = db.QuerySingle<string>(procedure, parameter, commandType: CommandType.StoredProcedure);
                }
            }
            catch (Exception ex)
            { throw ex; }

            return sexType;
        }
    }
}
