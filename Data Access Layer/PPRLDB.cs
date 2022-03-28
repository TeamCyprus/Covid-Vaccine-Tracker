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
    public static class PPRLDB
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
        public static bool AddPPRL(PPRL pprlnumber)
        {
            string procedure = "[SpAddPPRL]";
            var parameters = new { pId = pprlnumber.Patient_Id, pprl = pprlnumber.PPRL_Number };
            bool WasSuccess;
            int rowsAffected;

            try
            {
                string conStr = GetConnection();

                using (IDbConnection db = new SqlConnection(conStr))
                {
                    rowsAffected = db.Execute(procedure, parameters, commandType: CommandType.StoredProcedure);
                }
            }
            catch(Exception ex)
            { throw ex; }

            WasSuccess = rowsAffected > 0 ? true : false;
            return WasSuccess;
        }
        public static List<PPRL> GetPPRLs()
        {
            List<PPRL> pprls = new List<PPRL>();
            string procedure = "[SpGetPPRLs]";

            try
            {
                string conStr = GetConnection();

                using(IDbConnection db = new SqlConnection(conStr))
                {
                    pprls = db.Query<PPRL>(procedure, commandType: CommandType.StoredProcedure).ToList();
                }
            }
            catch(Exception ex)
            { throw ex; }

            return pprls;
        }
        public static string GetPPRL(string pId)
        {
            string pprl;
            string procedure = "[SpGetPPRL]";
            var parameter = new { patientId = pId };

            try
            {
                string conStr = GetConnection();

                using(IDbConnection db = new SqlConnection(conStr))
                {
                    pprl = db.QuerySingle(procedure, parameter, commandType: CommandType.StoredProcedure);
                }
            }
            catch(Exception ex)
            { throw ex; }

            return pprl;
        }
        public static string GetPatientId(string PPRL)
        {
            string patientId;
            string procedure = "[SpGetPatientIdByPPRL]";
            var parameter = new { pprl = PPRL };

            try
            {
                string conStr = GetConnection();

                using(IDbConnection db = new SqlConnection(conStr))
                {
                    patientId = db.QuerySingle<string>(procedure, parameter, commandType: CommandType.StoredProcedure);
                }
            }
            catch(Exception ex)
            { throw ex; }

            return patientId;
        }
        public static string GetPPRLNumber(string patientID)
        {
            string pprl;
            string procedure = "[SpGetPPRLNumber]";
            var parameter = new { patientId = patientID };

            try
            {
                string conStr = GetConnection();

                using(IDbConnection db = new SqlConnection(conStr))
                {
                    //111111aaa is a patient Id that I used. It returns null because that id has no PPRL. We create that pprl when we create 
                    //a new patient. So add a patient, remember the id, and now it will return a pprl when you run this. 
                    pprl = db.QuerySingle<string>(procedure, parameter, commandType: CommandType.StoredProcedure);
                }
            }
            catch(Exception ex)
            { throw ex; }

            return pprl;
        }
        public static bool VerifyNewPPRL(string pprlNum)
        {
            bool pprlFound;
            string procedure = "[SpCheckPPRL]";
            var parameters = new { pprl = pprlNum };

            try
            {
                string conStr = GetConnection();

                using(IDbConnection db = new SqlConnection(conStr))
                {
                    pprlFound = db.ExecuteScalar<bool>(procedure, parameters, commandType: CommandType.StoredProcedure);
                }
            }
            catch(Exception ex)
            { throw ex; }

            return pprlFound;
        }
        
    }
}
