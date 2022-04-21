using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Covid_Vaccine_Tracker.Business_Objects;
using System.Data.SqlClient;
using Dapper;
using System.Data;

namespace Covid_Vaccine_Tracker.Data_Access_Layer
{
    public static class SecurityQuestionDB
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
        // next couple methods get the data from the SecurityAnwsers table in the database
        // this table holds records of each user and their selected question and the anwser
        // add security questions are just the users question and anwser
        public static bool AddSecurityQuestion(string id, string question, string anwser)
        {
            string procedure = "[SpAddSecurityQuestion]";
            var parameters = new { uid = id, q = question, a = anwser };
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
            catch (Exception ex)
            { throw ex; }

            WasSuccess = rowsAffected > 0 ? true : false;
            return WasSuccess;
        }
        // this gets takes a user id and a question from the question combo box and then returns a SecurityAnwser object which holds
        // a user id, question and anwser
        public static SecurityAnwser GetSingleQuestionSet(string userId, string questin)
        {
            SecurityAnwser question = new SecurityAnwser();
            string procedure = "[SpGetSingleQuestion]";
            var parameters = new { uid = userId, q = questin };

            try
            {
                string conStr = GetConnection();

                using (IDbConnection db = new SqlConnection(conStr))
                {
                    question= db.QuerySingle<SecurityAnwser>(procedure,parameters, commandType: CommandType.StoredProcedure);
                }
            }
            catch (Exception ex)
            { throw ex; }

            return question;
        }
        // this accepts a user id and then return a list of all the questions tied to that user
        public static List<SecurityAnwser> GetUserSecurityQuestions(string userId)
        {
            List<SecurityAnwser> questions = new List<SecurityAnwser>();
            string procedure = "[SpGetUserSecurityQuestions]";
            var parameters = new { uid = userId};

            try
            {
                string conStr = GetConnection();

                using (IDbConnection db = new SqlConnection(conStr))
                {
                    questions = db.Query<SecurityAnwser>(procedure, parameters, commandType: CommandType.StoredProcedure).ToList();
                }
            }
            catch (Exception ex)
            { throw ex; }

            return questions;
        }
        // this method gets all the security questions from the SecurityQuestions table in database
        public static List<SecurityQuestion> GetAllSecurityQuestions()
        {
            List<SecurityQuestion> questions = new List<SecurityQuestion>();
            string procedure = "[SpGetUserSecurityQuestions]";

            try
            {
                string conStr = GetConnection();

                using (IDbConnection db = new SqlConnection(conStr))
                {
                    questions = db.Query<SecurityQuestion>(procedure, commandType: CommandType.StoredProcedure).ToList();
                }
            }
            catch (Exception ex)
            { throw ex; }

            return questions;
        }
        // not sure if this will be needed but allows a single question to be selected out of SecurityQuestions table
        public static SecurityQuestion GetSecurityQuestion()
        {
            SecurityQuestion question = new SecurityQuestion();
            string procedure = "[SpSelectSecurityQuestion]";

            try
            {
                string conStr = GetConnection();

                using (IDbConnection db = new SqlConnection(conStr))
                {
                    question = db.QuerySingle<SecurityQuestion>(procedure, commandType: CommandType.StoredProcedure);
                }
            }
            catch (Exception ex)
            { throw ex; }

            return question;
        }
    }
}
