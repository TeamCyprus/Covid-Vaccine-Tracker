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
    public static class ResponsesDB
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
        public static List<Response> GetResponses()
        {
            List<Response> allResponses = new List<Response>();
            string procedure = "[SpGetResponses]";

            try
            {
                string conStr = GetConnection();

                using (IDbConnection db = new SqlConnection(conStr))
                {
                    allResponses = db.Query<Response>(procedure, commandType: CommandType.StoredProcedure).ToList();
                }
            }
            catch (Exception ex)
            { throw ex; }

            return allResponses;
        }
        public static Response GetResponse(string Rcode)
        {
            Response requestedResponse = new Response();
            string procedure = "[SpGetResponse]";
            var parameter = new { id = Rcode };

            try
            {
                string conStr = GetConnection();

                using (IDbConnection db = new SqlConnection(conStr))
                {
                    requestedResponse = db.QuerySingle<Response>(procedure, commandType: CommandType.StoredProcedure);
                }
            }
            catch(Exception ex)
            { throw ex; }

            return requestedResponse;
        }
    }
}