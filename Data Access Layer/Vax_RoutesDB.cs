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
    public static class Vax_RoutesDB
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
        public static List<Vaccine_Route> GetRoutes()
        {
            List<Vaccine_Route> routes = new List<Vaccine_Route>();
            string procedure = "[SpGetVaxRoutes]";

            try
            {
                string conStr = GetConnection();

                using(IDbConnection db = new SqlConnection(conStr))
                {
                    routes = db.Query<Vaccine_Route>(procedure, commandType: CommandType.StoredProcedure).ToList();
                }
            }
            catch(Exception ex)
            { throw ex; }

            return routes;
        }
        public static Vaccine_Route GetRoute(string Rcode)
        {
            Vaccine_Route requestedRoute = new Vaccine_Route();
            string procedure = "[SpGetVaxRoute]";
            var parameter = new { code = Rcode };

            try
            {
                string conStr = GetConnection();

                using(IDbConnection db = new SqlConnection(conStr))
                {
                    requestedRoute = db.QuerySingle<Vaccine_Route>(procedure, parameter, commandType: CommandType.StoredProcedure);
                }
            }
            catch(Exception ex)
            { throw ex; }

            return requestedRoute;
        }
    }
}
