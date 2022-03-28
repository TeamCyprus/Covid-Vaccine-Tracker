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
    public static class Vax_ManufacturersDB
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
        public static List<Vaccine_Manufacturer> GetManufacturers()
        {
            List<Vaccine_Manufacturer> manufacturers = new List<Vaccine_Manufacturer>();
            string procedure = "[SpGetSpGetVaxManufactuers]";

            try
            {
                string conStr = GetConnection();

                using(IDbConnection db = new SqlConnection(conStr))
                {
                    manufacturers = db.Query<Vaccine_Manufacturer>(procedure, commandType: CommandType.StoredProcedure).ToList();
                }
            }
            catch(Exception ex)
            { throw ex; }

            return manufacturers;
        }
        public static Vaccine_Manufacturer GetManufacturer(string Mcode)
        {
            Vaccine_Manufacturer manufacturer = new Vaccine_Manufacturer();
            string procedure = "[SpGetSpGetVaxManufactuer]";
            var parameter = new { code = Mcode };

            try
            {
                string conStr = GetConnection();

                using(IDbConnection db = new SqlConnection(conStr))
                {
                    manufacturer = db.QuerySingle<Vaccine_Manufacturer>(procedure, parameter, commandType: CommandType.StoredProcedure);
                }
            }
            catch(Exception ex)
            { throw ex; }

            return manufacturer;
        }
    }
}
