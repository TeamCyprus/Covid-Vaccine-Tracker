using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Covid_Vaccine_Tracker.Business_Objects
{
    // Stats class will be the base object to hold the the values from each data lists
    public class Stats
    {
        public string DataName { get; set; }
        public int DataValue { get; set; }
    }
    public class TotalDose
    {
        public int Total_Doses { get; set; }
    }
    public class AverageDose
    {
        //SpGetAverageDose
        public int Average_Dose { get; set; }
    }
    public class PatientCount
    {
        public int Patient_Count { get; set; }
    }
    public class TopDose
    {
        //SpGetTopDoses
        public int Dose_Number { get; set; }
        public int Doses_Administered { get; set; }
    }
    public class DoseRank
    {
        public int Dose_Number { get; set; }
        public int Doses_Administered { get; set; }
    }
    public class VaccineRollOut
    {
        // SpGetRollout
        public int Vaccines_Administered { get; set; }
        public DateTime Date { get; set; }
    }
    public class VaccineStatus
    {
        public string Complete { get; set; }
        public int Patients { get; set; }
    }
    public class EthnicityVaccine
    {
        public string Ethnicity { get; set; }
        public int People_Vaccinated { get; set; }
    }
    public class RaceVaccine
    {
        public string Race { get; set; }
        public int Doses_Administered { get; set; }
    }
    public class SexVaccine
    {
        public string Sex { get; set; }
        public int People_Vaccinated { get; set; }
    }
    // next to vaccine count
    public class VaccineCount
    {
        public int Vax_Count { get; set; }
    }
    // this class can be used for top3 manufacturer also
    public class ManufacturerVaccine
    {
        public string Manufacturer { get; set; }
        public int Doses_Administered { get; set; }
    }
    public class VaccineCity
    {
        public string City { get; set; }
        public int People_Vaccinated { get; set; }
    }
    public class VaccineCounty
    {
        public string County { get; set; }
        public int People_Vaccinated { get; set; }
    }
    // need calcu zscore and std dev methods
    public static class VaccineStatistics
    {
        public static double CalculateMean(List<int> values)
        {
            var mean = values.Average();
            return (mean / values.Count);
        }
        public static double CalculateMean(List<double> values)
        {
            var mean = values.Average();
            return (mean / values.Count);
        }
        public static double CalculateStandardDev(List<int> values)
        {
            double std;
            try
            {
                double mean = values.Average();
                double sum = values.Sum(val => Math.Pow(val - mean, 2));
                std = Math.Sqrt((sum) / (values.Count() - 1));
            }
            catch(Exception ex)
            { throw ex; }

            return std;
        }
        public static double CalculateSampleStandardDev(List<double> values)
        {
            double std;
            try
            {
                double mean = CalculateMean(values);
                double sum = values.Sum(val => Math.Pow(val - mean, 2));
                std = Math.Sqrt((sum) / (values.Count() - 1));
            }
            catch (Exception ex)
            { throw ex; }

            return std;
        }
        public static double CalculateSampleStandardDev(List<VaccineRollOut> rollOuts)
        {
            int total = 0;
            double mean = 0;
            List<double> deviations = new List<double>();
            double sumDevs, varriance, std;
            try
            {
                // calc the mean
                foreach(VaccineRollOut v in rollOuts)
                    total += v.Vaccines_Administered;
                mean = total / rollOuts.Count;
                // calc sum of deviations and square them
                foreach(VaccineRollOut v in rollOuts)
                    deviations.Add(Math.Pow((v.Vaccines_Administered - mean), 2));
                // now find sum of deviations
                sumDevs = deviations.Sum();
                // calc the varriance
                varriance = sumDevs / (rollOuts.Count() - 1);
                // calc the std
                std = Math.Sqrt(varriance);
            }
            catch (Exception ex)
            { throw ex; }

            return std;
        }
        public static double CalculateSampleVarriance(List<VaccineRollOut> rollOuts)
        {
            int total = 0;
            double mean = 0;
            List<double> deviations = new List<double>();
            double sumDevs, varriance;
            try
            {
                // calc the mean
                foreach (VaccineRollOut v in rollOuts)
                    total += v.Vaccines_Administered;
                mean = total / rollOuts.Count;
                // calc sum of deviations and square them
                foreach (VaccineRollOut v in rollOuts)
                    deviations.Add(Math.Pow((v.Vaccines_Administered - mean), 2));
                // now find sum of deviations
                sumDevs = deviations.Sum();
                // calc the varriance
                varriance = sumDevs / (rollOuts.Count() - 1);
            }
            catch (Exception ex)
            { throw ex; }

            return varriance;
        }
        // double check this is correct
        public static double CalculateSampleVariance(List<int> values)
        {
            double variance;
            try
            {
                double mean = CalculateMean(values);
                double sum = values.Sum(val => Math.Pow(val - mean, 2));
                variance = (sum / (values.Count() - 1));
            }
            catch(Exception ex)
            { throw ex; }

            return variance;
        }
        public static double CalculateSampleVariance(List<double> values)
        {
            double variance;
            try
            {
                double mean = CalculateMean(values);
                double sum = values.Sum(val => Math.Pow(val - mean, 2));
                variance = (sum / (values.Count() - 1));
            }
            catch (Exception ex)
            { throw ex; }

            return variance;
        }
        public static double CalculateMovingAverage(List<int> values, int timePeriod)
        {
            return (values.Sum() / timePeriod);
        }
        public static double CalculateMovingAverage(List<double> values, int timePeriod)
        {
            return (values.Sum() / timePeriod);
        }
        public static double CalculateMovingAverage<T>(int total, int timePeriod)
        {
            return (total / timePeriod);
        }
        public static double CalculateMovingAverage(double total, int timePeriod)
        {
            return (total / timePeriod);
        }
    }
}

