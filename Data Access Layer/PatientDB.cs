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
    public static class PatientDB
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
            catch(Exception ex)
            { throw ex; }

            return conStr;
        }
        // this method performs a stored procedure that selects all from patient table
        // so it must return a list of patients
        public static List<Patient> GetPatients()
        {
            // create a empty list of patients
            List<Patient> allPatients = new List<Patient>();

            // put the stored procedures name into a string
            string procedure = "[SpGetPatients]";
            
            try
            {
                // get connection to database
                string connectionStr = GetConnection();

                // use the using statement to create the cconnection to DB
                // note a using statement will automatically disconnect from the database
                // also using statements can be used with other types of objects such as file streams
                using(IDbConnection db = new SqlConnection(connectionStr))
                {
                    // dapper is a ORM or Object Relation Mapper so it will automatically convert
                    // data from the database into the object to specify

                    // this is the dapper in this case this puts the rows returned from DB into a list of patitent objects
                    // pass in the string that holds the procedure name and specify the command type and since it is a list
                    // convert to list with .ToList()
                    allPatients = db.Query<Patient>(procedure, commandType: CommandType.StoredProcedure).ToList();
                }
            }
            // if something goes wrong throw the exception back to calling code to display error msg
            catch(Exception ex)
            { throw ex; }

            // return the list of patients
            return allPatients;
        }
        // this method get a single patient record from database therefore
        // it must return a patient object
        public static Patient GetPatient(string patientId)
        {
            // create a empty patient object
            Patient requestedPatient = new Patient();

            // specify store procedure name
            string procedure = "[SpGetPatient]";

            // this is how you specify any parameters that you pass into the stored procedure
            // note the name of the parameters has to be the same inside the stored procedure
            var parameter = new { id = patientId };

            try
            {
                // get connection string
                string connectionStr = GetConnection();

                // using statement to create and close connection to database
                using(IDbConnection db = new SqlConnection(connectionStr))
                {
                    // dapper to query a single row from the database and put data into a patient object
                    // pass in the procedure name the parameter and specify the command type
                    requestedPatient = db.QuerySingle<Patient>(procedure, parameter, commandType: CommandType.StoredProcedure);
                }
            }
            catch(Exception ex)
            { throw ex; }

            // return patient
            return requestedPatient;
        }
        // this method adds a new patient into database inorder
        // to determine if it was successful it will return a bool
        public static bool AddPatient(Patient newPatient)
        {
            // variable to determine if succesful insert or not
            bool isSuccess;
            // variable to hold number of rows changed
            int rowsAffected;
            // specify stored procedure
            string procedure = "[SpAddPatient]";
            // this is how you specify multiple parameters to pass into a stored procedure
            // note the name of the parameters has to be the same inside the stored procedure
            
            var parameters = new
            {
                id = newPatient.Id,
                fname = newPatient.First_name,
                mname = newPatient.Middle_name,
                lname = newPatient.Last_name,
                dob = newPatient.Date_of_birth,
                street = newPatient.Street_address,
                city = newPatient.City,
                county = newPatient.County,
                state = newPatient.State,
                zip = newPatient.Zipcode,
                race1 = newPatient.Race1,
                race2 = newPatient.Race2,
                ethnicity = newPatient.Ethnicity,
                sex = newPatient.Sex,
                extract = newPatient.Extract_Type
            };

            try
            {
                // get connection string
                string connectionStr = GetConnection();
                
                //create connection to database
                using(IDbConnection db = new SqlConnection(connectionStr))
                {
                    // since this is not a query must use execute
                    // execute will return the number of rows affected
                    // pass in the procedure the parameters and specify the command type
                    rowsAffected = db.Execute(procedure, parameters, commandType: CommandType.StoredProcedure);
                }
            }
            catch(Exception ex)
            { throw ex; }

            // if rowsAffected is greater then zero isSuccess = true if not = false
            isSuccess = rowsAffected > 0 ? true : false;
            // return insert status
            return isSuccess;
        }
        // this method update a patient record in the database
        // will return a bool to determine if update was successful or not
        public static bool UpdatePatient(Patient updatedPatient)
        {
            // update status
            bool isSuccess;
            // number of rows changed
            int rowsAffected;
            // stored procedures name
            string procedure = "[SpUpdatePatient]";
            // parameters for procedure argument names must be same as inside procedure
            var parameters = new
            {
                id = updatedPatient.Id,
                fname = updatedPatient.First_name,
                mname = updatedPatient.Middle_name,
                lname = updatedPatient.Last_name,
                dob = updatedPatient.Date_of_birth,
                street = updatedPatient.Street_address,
                city = updatedPatient.City,
                county = updatedPatient.County,
                state = updatedPatient.State,
                zip = updatedPatient.Zipcode,
                race1 = updatedPatient.Race1,
                race2 = updatedPatient.Race2,
                ethnicity = updatedPatient.Ethnicity,
                sex = updatedPatient.Sex,
                extract = updatedPatient.Extract_Type
            };

            try
            {
                // get connection string
                string connectionStr = GetConnection();
                // create connection to database
                using(IDbConnection db = new SqlConnection(connectionStr))
                {
                    // execute returns the number of rows affected
                    // pass in procedure and parameters and specify command type
                    rowsAffected = db.Execute(procedure, parameters, commandType: CommandType.StoredProcedure);
                }
            }
            catch(Exception ex)
            { throw ex; }

            // if rows affected is > 0 then isSuccess will be true if not false
            isSuccess = rowsAffected > 0 ? true : false;
            // return update status
            return isSuccess;
        }
        // this method checks database verifys a patient already exists in database
        public static bool IsExistingPatient(string patientId, string firstName, string middleName, string lastName)
        {
            bool patientFound;
            Patient requstedPatient = new Patient();
            string procedure = "[SpCheckPatient]";
            var parameters = new
            {
                pId = patientId,
                fname = firstName,
                mname = middleName,
                lname = lastName
            };

            try
            {
                string conStr = GetConnection();

                using(IDbConnection db = new SqlConnection(conStr))
                {
                    requstedPatient = db.QuerySingle<Patient>(procedure, parameters, commandType: CommandType.StoredProcedure);
                }

                if (requstedPatient != null)
                    patientFound = true;
                else
                    patientFound = false;
            }
            catch(Exception ex)
            { throw ex; }

            return patientFound;
        }
        public static bool CheckPatientId(string pId)
        {
            bool patientFound;
            string procedure = "[SpCheckPatientId]";
            var parameters = new { id = pId, };

            try
            {
                string conStr = GetConnection();

                using (IDbConnection db = new SqlConnection(conStr))
                {
                    // ExecuteScalar<bool> will map the value returned from Database to either true or false
                    patientFound = db.ExecuteScalar<bool>(procedure, parameters, commandType: CommandType.StoredProcedure);
                }
            }
            catch (Exception ex)
            { throw ex; }

            return patientFound;
        }
        public static bool VerifyPatient(string pId, string Fname, string Mname, string Lname)
        {
            bool patientFound;
            Patient requstedPatient = new Patient();
            string procedure = "[SpVerifyPatient]";
            var parameters = new {id = pId, fname = Fname, mname = Mname, lname = Lname };

            try
            {
                string conStr = GetConnection();

                using (IDbConnection db = new SqlConnection(conStr))
                {
                    requstedPatient = db.QuerySingle<Patient>(procedure, parameters, commandType: CommandType.StoredProcedure);
                }

                if (requstedPatient != null)
                    patientFound = true;
                else
                    patientFound = false;
            }
            catch (Exception ex)
            { throw ex; }

            return patientFound;
        }
    }
}
