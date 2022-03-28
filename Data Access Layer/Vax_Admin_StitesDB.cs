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
    public static class Vax_Admin_StitesDB
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
        public static List<Vaccine_Admin_Site> GetAdminSites()
        {
            List<Vaccine_Admin_Site> adminSites = new List<Vaccine_Admin_Site>();
            string procedure = "[SpGetAdminSites]";

            try
            {
                string conStr = GetConnection();
                using(IDbConnection db = new SqlConnection(conStr))
                {
                    adminSites = db.Query<Vaccine_Admin_Site>(procedure, commandType: CommandType.StoredProcedure).ToList();
                }
            }
            catch(Exception ex)
            { throw ex; }

            return adminSites;
        }
        public static Vaccine_Admin_Site GetAdminSite(string Vcode)
        {
            Vaccine_Admin_Site site = new Vaccine_Admin_Site();
            string procedure = "[SpGetAdminSite]";
            var parameters = new { code = Vcode };

            try
            {
                string conStr = GetConnection();

                using(IDbConnection db = new SqlConnection(conStr))
                {
                    site = db.QuerySingle<Vaccine_Admin_Site>(procedure, parameters, commandType: CommandType.StoredProcedure);
                }
            }
            catch(Exception ex)
            { throw ex; }

            return site;
        }
    }
}
