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
    public static class DosesDB
    {
        // this class is like the other data access layer classes but
        // the data will be binded to combo boxs and then will use the ValueMember proprety for comboboxs to
        // get the code to retrieve the value to be stored in either Paitient, HealthProvider, CDC, or Vaccine Record object
        // this class does not need update, delete, or insert

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
        public static List<Dose> GetDoses()
        {
            List<Dose> allDoses = new List<Dose>();
            string procedure = "[SpGetDoses]";

            try
            {
                string conStr = GetConnection();
                
                using(IDbConnection db = new SqlConnection(conStr))
                {
                    allDoses = db.Query<Dose>(procedure, commandType: CommandType.StoredProcedure).ToList();
                }
            }
            catch(Exception ex)
            { throw ex; }

            return allDoses;
        }
        public static Dose GetDose(string Dcode)
        {
            Dose requestedDose = new Dose();
            string procedure = "[SpGetDose]";
            var parameter = new { code = Dcode };

            try
            {
                string conStr = GetConnection();

                using(IDbConnection db = new SqlConnection(conStr))
                {
                    requestedDose = db.QuerySingle<Dose>(procedure, parameter, commandType: CommandType.StoredProcedure);
                }
            }
            catch(Exception ex)
            { throw ex; }

            return requestedDose;
        }
    }
}
