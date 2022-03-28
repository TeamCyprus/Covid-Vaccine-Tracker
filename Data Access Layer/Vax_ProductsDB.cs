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
    public static class Vax_ProductsDB
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
        public static List<Vaccine_Product> GetProducts()
        {
            List<Vaccine_Product> products = new List<Vaccine_Product>();
            string procedure = "[SpGetVaxProducts]";

            try
            {
                string conStr = GetConnection();

                using(IDbConnection db = new SqlConnection(conStr))
                {
                    products = db.Query<Vaccine_Product>(procedure, commandType: CommandType.StoredProcedure).ToList();
                }
            }
            catch(Exception ex)
            { throw ex; }

            return products;
        }
        public static Vaccine_Product GetProduct(string Pcode)
        {
            Vaccine_Product product = new Vaccine_Product();
            string procedure = "[SpGetVaxProduct]";
            var parameter = new { code = Pcode };

            try
            {
                string conStr = GetConnection();

                using(IDbConnection db = new SqlConnection(conStr))
                {
                    product = db.QuerySingle<Vaccine_Product>(procedure, commandType: CommandType.StoredProcedure);
                }
            }
            catch(Exception ex)
            { throw ex; }

            return product;
        }
    }
}
