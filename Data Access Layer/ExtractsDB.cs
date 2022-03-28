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
    public static class ExtractsDB
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
        public static List<Extracts> GetExtracts()
        {
            List<Extracts> allExtracts = new List<Extracts>();
            string procedure = "[SpGetExtracts]";

            try
            {
                string conStr = GetConnection();

                using(IDbConnection db = new SqlConnection(conStr))
                {
                    allExtracts = db.Query<Extracts>(procedure, commandType: CommandType.StoredProcedure).ToList();
                }
            }
            catch(Exception ex)
            { throw ex; }

            return allExtracts;
        }
        public static Extracts GetExtract(string Ecode)
        {
            Extracts requestedExtract = new Extracts();
            string procedure = "[SpGetExtract]";
            var parameter = new { code = Ecode };

            try
            {
                string conStr = GetConnection();

                using(IDbConnection db = new SqlConnection(conStr))
                {
                    requestedExtract = db.QuerySingle<Extracts>(procedure, parameter, commandType: CommandType.StoredProcedure);
                }
            }
            catch(Exception ex)
            { throw ex; }

            return requestedExtract;
        }
        public static Extracts GetExtractByType(string Etype)
        {
            Extracts requestedExtract = new Extracts();
            string procedure = "[SpGetExtractByType]";
            var parameter = new { type = Etype };

            try
            {
                string conStr = GetConnection();

                using(IDbConnection db = new SqlConnection(conStr))
                {
                    requestedExtract = db.QuerySingle<Extracts>(procedure, parameter, commandType: CommandType.StoredProcedure);
                }
            }
            catch(Exception ex)
            { throw ex; }

            return requestedExtract;
        }
    }
}
