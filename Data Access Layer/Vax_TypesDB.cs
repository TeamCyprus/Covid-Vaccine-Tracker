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
    public static class Vax_TypesDB
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
        public static List<Vaccine_Type> GetTypes()
        {
            List<Vaccine_Type> types = new List<Vaccine_Type>();
            string procedure = "[SpGetVaxTypes]";

            try
            {
                string conStr = GetConnection();

                using(IDbConnection db = new SqlConnection(conStr))
                {
                    types = db.Query<Vaccine_Type>(procedure, commandType: CommandType.StoredProcedure).ToList();
                }
            }
            catch(Exception ex)
            { throw ex; }

            return types;
        }
        public static Vaccine_Type GetType(string Tcode)
        {
            Vaccine_Type type = new Vaccine_Type();
            string procedure = "[SpGetVaxType]";
            var parameter = new { code = Tcode };

            try
            {
                string conStr = GetConnection();

                using(IDbConnection db = new SqlConnection(conStr))
                {
                    type = db.QuerySingle<Vaccine_Type>(procedure, parameter, commandType: CommandType.StoredProcedure);
                }
            }
            catch(Exception ex)
            { throw ex; }

            return type;
        }
        // this method will get vaccine types by manufacturer so it needs to return a list of VaxTypes
        public static List<Vaccine_Type> GetTypeByManufacturer(string manufacturerId)
        {
            List<Vaccine_Type> types = new List<Vaccine_Type>();
            string procedure = "[SpGetVaxTypeByManufacturer]";
            var parameter = new { manufacturer = manufacturerId };

            try
            {
                string conStr = GetConnection();

                using(IDbConnection db = new SqlConnection(conStr))
                {
                    types = db.Query<Vaccine_Type>(procedure, parameter, commandType: CommandType.StoredProcedure).ToList();
                }
            }
            catch(Exception ex)
            { throw ex; }

            return types;
        }
    }
}
