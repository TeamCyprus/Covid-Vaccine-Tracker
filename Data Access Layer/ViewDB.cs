//Covid Vaccine Tracker - ViewDB class
// By Zachary Palmer
///<summary>
/// This class is part of the DAC or Data Access Layer
/// It gets a connection string from the app.Config file 
/// Then connects to database and gets the view options for different user types
/// </summary>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// Include namespace for project's business objects and the namespaces for sqlClient dapper and data mainpulations
using Covid_Vaccine_Tracker.Business_Objects;
using System.Data.SqlClient;
using Dapper;
using System.Data;


namespace Covid_Vaccine_Tracker.Data_Access_Layer
{
    public static class ViewDB
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
        public static List<Views> GetProviderViews()
        {
            string procedure = "[SpGetProviderViews]";
            List<Views> views = new List<Views>();

            try
            {
                string conStr = GetConnection();
                using(IDbConnection db = new SqlConnection(conStr))
                {
                    views = db.Query<Views>(procedure, commandType: CommandType.StoredProcedure).ToList();
                }
            }
            catch(Exception ex)
            { throw ex; }

            return views;
        }
        public static string GetProviderView(int Vid)
        {
            string procedure = "[SpGetProviderView]";
            var parameter = new { id = Vid };
            string view;

            try
            {
                string conStr = GetConnection();

                using(IDbConnection db = new SqlConnection(conStr))
                {
                    view = db.QuerySingle<string>(procedure, parameter, commandType: CommandType.StoredProcedure);
                }
            }
            catch(Exception ex)
            { throw ex; }

            return view;
        }
        public static List<Views> GetCdcViews()
        {
            string procedure = "[SpGetCDCViews]";
            List<Views> views = new List<Views>();

            try
            {
                string conStr = GetConnection();
                using (IDbConnection db = new SqlConnection(conStr))
                {
                    views = db.Query<Views>(procedure, commandType: CommandType.StoredProcedure).ToList();
                }
            }
            catch (Exception ex)
            { throw ex; }

            return views;
        }
        public static string GetCDCView(int Vid)
        {
            string procedure = "[SpGetCDCView]";
            var parameter = new { id = Vid };
            string view;

            try
            {
                string conStr = GetConnection();

                using (IDbConnection db = new SqlConnection(conStr))
                {
                    view = db.QuerySingle<string>(procedure, parameter, commandType: CommandType.StoredProcedure);
                }
            }
            catch (Exception ex)
            { throw ex; }

            return view;
        }

    }
}
