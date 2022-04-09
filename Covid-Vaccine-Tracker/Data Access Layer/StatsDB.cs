// Covid Vaccine Tracker - Stats class
/// <summary>
/// This class will hold multiple static classes that will be set up to map with dapper
/// These classes will hold the data pulled from the more analitical type stored procedures
/// Then be used to create charts
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
    public static class StatsDB
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
        public static double GetAverageDose()
        {
            double avg;
            string procedure = "[SpGetAvgDose]";

            try
            {
                string conStr = GetConnection();
                
                using (IDbConnection db = new SqlConnection(conStr))
                {
                    avg = db.QuerySingle<double>(procedure, commandType: CommandType.StoredProcedure);
                }
            }
            catch(Exception ex)
            { throw ex; }

            return Math.Round(avg,4,MidpointRounding.AwayFromZero);
        }
        public static List<DoseRank> GetDoseRanks()
        {
            List<DoseRank> ranking = new List<DoseRank>();
            string procedure = "[SpGetDoseRank]";
            try
            {
                string con = GetConnection();

                using(IDbConnection db = new SqlConnection(con))
                {
                    ranking = db.Query<DoseRank>(procedure, commandType: CommandType.StoredProcedure).ToList();
                }
            }
            catch(Exception ex)
            { throw ex; }

            return ranking;
        }
        public static int GetTopDose()
        {
            int doseNumber;
            string procedure = "[SpGetTopDoseNumber]";

            try
            {
                string conStr = GetConnection();

                using(IDbConnection db = new SqlConnection(conStr))
                {
                    doseNumber = db.Execute(procedure, commandType: CommandType.StoredProcedure);
                }
            }
            catch(Exception ex)
            { throw ex; }

            return doseNumber;
        }
        public static List<TopDose> GetTop3Doses()
        {
            List<TopDose> Tds = new List<TopDose>();
            string procedure = "[SpGetTopDoses]";

            try
            {
                string conStr = GetConnection();

                using(IDbConnection db = new SqlConnection(conStr))
                {
                    Tds = db.Query<TopDose>(procedure, commandType: CommandType.StoredProcedure).ToList();
                }
            }
            catch(Exception ex)
            { throw ex; }

            return Tds;
        }
        public static List<VaccineRollOut> GetVaccineRollout()
        {
            List<VaccineRollOut> rollout = new List<VaccineRollOut>();
            string procedure = "[SpGetVaccineRollout]";

            try
            {
                string conStr = GetConnection();

                using(IDbConnection db = new SqlConnection(conStr))
                {
                    rollout = db.Query<VaccineRollOut>(procedure, commandType: CommandType.StoredProcedure).ToList();
                }
            }
            catch(Exception ex)
            { throw ex; }

            return rollout;
        }
        public static List<VaccineStatus> GetVaccineStatuses()
        {
            List<VaccineStatus> statuses = new List<VaccineStatus>();
            string procedure = "[SpGetVaccineStatuses]";

            try
            {
                string conStr = GetConnection();

                using(IDbConnection db = new SqlConnection(conStr))
                {
                    statuses = db.Query<VaccineStatus>(procedure, commandType: CommandType.StoredProcedure).ToList();
                }
            }
            catch(Exception ex)
            { throw ex; }

            return statuses;
        }
        public static List<VaccineCity> GetCityVaccines()
        {
            List<VaccineCity> cities = new List<VaccineCity>();
            string procedure = "[SpCityVaccines]";

            try
            {
                string conStr = GetConnection();

                using(IDbConnection db = new SqlConnection(conStr))
                {
                    cities = db.Query<VaccineCity>(procedure, commandType: CommandType.StoredProcedure).ToList();
                }
            }
            catch(Exception ex)
            { throw ex; }

            return cities;
        }
        public static List<VaccineCounty> GetCountyVaccines()
        {
            List<VaccineCounty> counties = new List<VaccineCounty>();
            string procedure = "[SpGetCountyVaccines]";

            try
            {
                string conStr = GetConnection();

                using(IDbConnection db  = new SqlConnection(conStr))
                {
                    counties = db.Query<VaccineCounty>(procedure, commandType: CommandType.StoredProcedure).ToList();
                }
            }
            catch(Exception ex)
            { throw ex; }

            return counties;
        }
        public static List<SexVaccine> GetSexVaccines()
        {
            List<SexVaccine> sexes = new List<SexVaccine>();
            string procedure = "[SpGetSexVaccines]";

            try
            {
                string conStr = GetConnection();

                using(IDbConnection db = new SqlConnection(conStr))
                {
                    sexes = db.Query<SexVaccine>(procedure, commandType: CommandType.StoredProcedure).ToList();
                }
            }
            catch(Exception ex)
            { throw ex; }

            return sexes;
        }
        public static List<RaceVaccine> GetRaceVaccines()
        {
            // there are two columns for race so create two lists of races then put them together
            List<RaceVaccine> races1 = new List<RaceVaccine>();
            List<RaceVaccine> races2 = new List<RaceVaccine>();
            // create a list to hold list 1 and 2
            List<RaceVaccine> races = new List<RaceVaccine>();
            string procedure1 = "[SpGetRace1Vaccines]";
            string procedure2 = "[SpGetRace2Vaccines]";

            try
            {
                string conStr = GetConnection();

                using (IDbConnection db = new SqlConnection(conStr))
                {
                    races1 = db.Query<RaceVaccine>(procedure1, commandType: CommandType.StoredProcedure).ToList();
                    races2 = db.Query<RaceVaccine>(procedure2, commandType: CommandType.StoredProcedure).ToList();
                }
                // now check each list to get correct count
                // races1.Except will return every thing in races1 that is not in races2
                races = (List<RaceVaccine>)races1.Except(races2);

                // now go through the list and find the values that are the same then add them to the list
                foreach(RaceVaccine r1 in races1)
                    foreach(RaceVaccine r2 in races2)
                    {
                        if (r1.Race == r2.Race)
                        {
                            RaceVaccine updateRaceCount = new RaceVaccine(r1.Race, (r1.Doses_Administered + r2.Doses_Administered));
                            races.Add(updateRaceCount);
                        }
                    }
            }
            catch(Exception ex)
            { throw ex; }

            return races;

        }
        public static List<EthnicityVaccine> GetEthnicityVaccines()
        {
            List<EthnicityVaccine> ethnicities = new List<EthnicityVaccine>();
            string procedure = "[SpGetEthnicityVaccines]";

            try
            {
                string conStr = GetConnection();

                using (IDbConnection db = new SqlConnection(conStr))
                {
                    ethnicities = db.Query<EthnicityVaccine>(procedure, commandType: CommandType.StoredProcedure).ToList();
                }
            }
            catch (Exception ex)
            { throw ex; }

            return ethnicities;
        }
        public static List<ManufacturerVaccine> GetTopManufacturerVaccines()
        {
            List<ManufacturerVaccine> manufacturers = new List<ManufacturerVaccine>();
            string procedure = "[SpGetTopManufacturers]";

            try
            {
                string conStr = GetConnection();

                using (IDbConnection db = new SqlConnection(conStr))
                {
                    manufacturers = db.Query<ManufacturerVaccine>(procedure, commandType: CommandType.StoredProcedure).ToList();
                }    
            }
            catch(Exception ex)
            { throw ex; }

            return manufacturers;
        }
        public static List<ManufacturerVaccine> GetManufacturerVaccines()
        {
            List<ManufacturerVaccine> manufacturers = new List<ManufacturerVaccine>();
            string procedure = "[SpManufacturerVaccines]";

            try
            {
                string conStr = GetConnection();

                using (IDbConnection db = new SqlConnection(conStr))
                {
                    manufacturers = db.Query<ManufacturerVaccine>(procedure, commandType: CommandType.StoredProcedure).ToList();
                }
            }
            catch(Exception ex)
            { throw ex; }

            return manufacturers;
        }
        public static int GetDoseCount()
        {
            int totalDoses;
            string procedure = "[SpGetVaccineCount]";

            try
            {
                string con = GetConnection();
                
                using(IDbConnection db = new SqlConnection(con))
                {
                    totalDoses = db.QuerySingle<int>(procedure, commandType: CommandType.StoredProcedure);
                }
            }
            catch(Exception ex)
            { throw ex; }

            return totalDoses;
        }
        public static int GetPatientCount()
        {
            int count;
            string procedure = "[SpGetPatientCount]";

            try
            {
                string con = GetConnection();

                using(IDbConnection db = new SqlConnection(con))
                {
                    count = db.QuerySingle<int>(procedure, commandType: CommandType.StoredProcedure);
                }
            }
            catch(Exception ex)
            { throw ex; }

            return count;
        }

    }
}
