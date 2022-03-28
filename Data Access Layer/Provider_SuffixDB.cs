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
    public static class Provider_SuffixDB
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
        public static List<Provider_Suffix> GetSuffixes()
        {
            List<Provider_Suffix> suffixes = new List<Provider_Suffix>();
            string procedure = "[SpGetProviderSuffixes]";

            try
            {
                string conStr = GetConnection();

                using(IDbConnection db = new SqlConnection(conStr))
                {
                    suffixes = db.Query<Provider_Suffix>(procedure, commandType: CommandType.StoredProcedure).ToList();
                }
            }
            catch(Exception ex)
            { throw ex; }

            return suffixes;

        }
        public static Provider_Suffix GetSuffix(string Scode)
        {
            Provider_Suffix requestedSuffix = new Provider_Suffix();
            string procedure = "[SpGetProviderSuffix]";
            var parameter = new { code = Scode };

            try
            {
                string conStr = GetConnection();
                
                using(IDbConnection db = new SqlConnection(conStr))
                {
                    requestedSuffix = db.QuerySingle<Provider_Suffix>(procedure, parameter, commandType: CommandType.StoredProcedure);
                }
            }
            catch(Exception ex)
            { throw ex; }

            return requestedSuffix;
        }

    }
    
}
