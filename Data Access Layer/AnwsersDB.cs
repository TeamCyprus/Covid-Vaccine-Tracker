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
    public static class AnwsersDB
    {
        // this class is like the other data access layer classes but
        // the data will be binded to combo boxs and then will use the ValueMember proprety for comboboxs to
        // get the code to retrieve the value to be stored in either Paitient, HealthProvider, CDC, or Vaccine Record object
        // this class does not need update, delete, or insert

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
        public static List<Anwsers> GetAnwsers()
        {
            List<Anwsers> allAnwsers = new List<Anwsers>();
            string procedure = "[SpGetAnwsers]";

            try
            {
                string conStr = GetConnection();
                
                using(IDbConnection db = new SqlConnection(conStr))
                {
                    allAnwsers = db.Query<Anwsers>(procedure, commandType: CommandType.StoredProcedure).ToList();
                }
            }
            catch(Exception ex)
            { throw ex; }

            return allAnwsers;
        }
        public static Anwsers GetAnwser(string code)
        {
            Anwsers reqeustedAnwser = new Anwsers();
            string procedure = "[SpGetAnwser]";
            var parameter = new { id = code };

            try
            {
                string conStr = GetConnection();
                using(IDbConnection db = new SqlConnection(conStr))
                {
                    reqeustedAnwser = db.QuerySingle<Anwsers>(procedure, parameter, commandType: CommandType.StoredProcedure);
                }
            }
            catch(Exception ex)
            { throw ex; }

            return reqeustedAnwser;
        }
    }
}
