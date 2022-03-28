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
    public static class EthnicitiesDB
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
        public static List<Ethnicity> GetEthnicities()
        {
            List<Ethnicity> ethnicities = new List<Ethnicity>();
            string procedure = "[SpGetEthnicities]";

            try
            {
                string conStr = GetConnection();

                using(IDbConnection db = new SqlConnection(conStr))
                {
                    ethnicities = db.Query<Ethnicity>(procedure, commandType: CommandType.StoredProcedure).ToList();
                }
            }
            catch(Exception ex)
            { throw ex; }

            return ethnicities;
        }
        public static Ethnicity GetEthnicity(string Ecode)
        {
            Ethnicity requestedEthnicity = new Ethnicity();
            string procedure = "[SpGetEthnicity]";
            var parameter = new { code = Ecode };

            try
            {
                string conStr = GetConnection();

                using(IDbConnection db = new SqlConnection(conStr))
                {
                    requestedEthnicity = db.QuerySingle<Ethnicity>(procedure, parameter, commandType: CommandType.StoredProcedure);
                }
            }
            catch(Exception ex)
            { throw ex; }

            return requestedEthnicity;
        }
        public static string GetEthnicityType(string Ecode)
        {
            string EthnicityType;
            string procedure = "[SpGetEthnicityType]";
            var parameter = new { code = Ecode };

            try
            {
                string conStr = GetConnection();

                using (IDbConnection db = new SqlConnection(conStr))
                {
                    EthnicityType = db.QuerySingle<string>(procedure, parameter, commandType: CommandType.StoredProcedure);
                }
            }
            catch (Exception ex)
            { throw ex; }

            return EthnicityType;
        }
    }
}
