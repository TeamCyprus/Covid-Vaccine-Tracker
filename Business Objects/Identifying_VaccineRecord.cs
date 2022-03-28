// Covid Vax Tracker - VaccineRecord_View Class
// by Zachary Palmer 2/15/2022
///<summary>
/// This class holds the values for the Joined Patient, PPRLs, and Vaccine_Records tables.
/// It is used by the Provider user type it allows Identifying Patient info to be displayed with Vax info
/// </summary>
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// Need for regex
using System.Text.RegularExpressions;

namespace Covid_Vaccine_Tracker.Business_Objects
{
    public class Identifying_VaccineRecord
    {
        public string first_name;
        public string last_name;
        public DateTime date_of_birth;
        public string city;
        public string county;
        public string state;
        public string extract_type;
        public string pprl;
        public string vaccine_event_id;
        public DateTime date;
        public string vaccine_type;
        public string dose_number;
        public string vax_series_complete;
        public string company;

        // need to test dataannotations and then add
        public string First_Name
        {
            get => this.first_name; // Lambda to get the value
            set
            {
                try
                {
                    // Check input against regexs
                    (bool, string) validData = InputValidator.IsValidStringData(value);

                    if (value.Length > 25)
                        throw new Exception("First name must be 25 characters or less");
                    else if (string.IsNullOrEmpty(value))
                        throw new Exception("First name cannot be empty or null");
                    else if (!validData.Item1)
                        throw new Exception("First name" + validData.Item2);
                    else
                        this.first_name = value;
                }
                catch(Exception ex)
                { throw ex; }
            }
        }
        public string Last_Name
        {
            get => this.last_name;
            set
            {
                try
                {
                    // Check input against regexs
                    (bool, string) validData = InputValidator.IsValidStringData(value);

                    if (value.Length > 35)
                        throw new Exception("Last name must be 35 characters or less");
                    else if (string.IsNullOrEmpty(value))
                        throw new Exception("Last name cannot be empty or null");
                    else if (!validData.Item1)
                        throw new Exception("Last name" + validData.Item2);
                    else
                        this.last_name = value;
                }
                catch (Exception ex)
                { throw ex; }
            }
        }
        public DateTime Date_of_Birth
        {
            get => this.date_of_birth;
            set
            {
                try
                {
                    // Check date is in correct format
                    (bool, string) validData = InputValidator.IsValidDate(value);

                    if (value.AddYears(-110) >= value || value >= DateTime.Today)
                        throw new Exception("Invalid date of birth");
                    else if (string.IsNullOrEmpty(value.ToString()))
                        throw new Exception("Date of birth cannot be empty or null");
                    else if (!validData.Item1)
                        throw new Exception(validData.Item2);
                    else
                        this.date_of_birth = value;
                }
                catch(Exception ex)
                { throw ex; }
            }
        }
        public string City
        {
            get => this.city;
            set
            {
                try
                {
                    // Check input against regexs
                    (bool, string) validData = InputValidator.IsValidStringData(value);

                    if (value.Length > 100)
                        throw new Exception("City must be 100 characters or less");
                    else if (string.IsNullOrEmpty(value))
                        throw new Exception("City cannot be empty or null");
                    else if (!validData.Item1)
                        throw new Exception("City" + validData.Item2);
                    else
                        this.city = value;
                }
                catch (Exception ex)
                { throw ex; }
            }
        }
        public string County
        {
            get => this.county;
            set
            {
                try
                {
                    // Check input against regexs
                    (bool, string) validData = InputValidator.IsValidStringData(value);

                    if (value.Length > 100)
                        throw new Exception("County must be 100 characters or less");
                    else if (string.IsNullOrEmpty(value))
                        throw new Exception("County cannot be empty or null");
                    else if (!validData.Item1)
                        throw new Exception("County" + validData.Item2);
                    else
                        this.county = value;
                }
                catch (Exception ex)
                { throw ex; }
            }
        }
        public string State
        {
            get => this.state;
            set
            {
                try
                {
                    // Check input against regexs
                    (bool, string) validData = InputValidator.IsValidStringData(value);

                    if (value.Length > 50)
                        throw new Exception("State must be 50 characters or less");
                    else if (string.IsNullOrEmpty(value))
                        throw new Exception("State cannot be empty or null");
                    else if (!validData.Item1)
                        throw new Exception("State" + validData.Item2);
                    else
                        this.state = value;
                }
                catch (Exception ex)
                { throw ex; }
            }
        }
        public string Extract_Type
        {
            get => this.extract_type;
            set
            {
                try
                {
                    // Check input against regexs
                    (bool, string) validData = InputValidator.IsValidStringData(value);

                    if (value.Length > 15)
                        throw new Exception("Extract type must be 15 characters or less");
                    else if (string.IsNullOrEmpty(value))
                        throw new Exception("Extract type cannot be empty or null");
                    else if (!validData.Item1)
                        throw new Exception("Extract type" + validData.Item2);
                    else
                        this.extract_type = value;
                }
                catch (Exception ex)
                { throw ex; }
            }
        }
        public string PPRL
        {
            get => this.pprl;
            set
            {               
                try
                {
                    (bool, string) validInput = InputValidator.IsValidPPRL(value);

                    if (value.Length > 10)
                        throw new Exception("PPRL number must be 10 characters");
                    else if (string.IsNullOrEmpty(value))
                        throw new Exception("PPRL number cannot be empty or null");
                    else if (!validInput.Item1)
                        throw new Exception(validInput.Item2);
                    else
                        this.pprl = value;
                }
                catch(Exception ex)
                { throw ex; }
            }
        }
        public string Vaccine_Event_Id
        {
            get => this.vaccine_event_id;
            set
            {
                try
                {
                    (bool, string) validInput = InputValidator.IsValidVaccineEvent(value);

                    if (value.Length > 10)
                        throw new Exception("Vaccine Event Id must be 10 characters");
                    else if (string.IsNullOrEmpty(value))
                        throw new Exception("Vaccine Event Id cannot be empty or null");
                    else if (!validInput.Item1)
                        throw new Exception(validInput.Item2);
                    else
                        this.vaccine_event_id = value;
                }
                catch(Exception ex)
                { throw ex; }
            }
        }
        public DateTime Date
        {
            get => this.date;
            set
            {
                try
                {
                    // Check date is in correct format
                    (bool, string) validData = InputValidator.IsValidDate(value);

                    if (value.AddYears(-3) >= value || value >= DateTime.Today)
                        throw new Exception("Invalid vaccine administration date");
                    else if (string.IsNullOrEmpty(value.ToString()))
                        throw new Exception("Administration date cannot be empty or null");
                    else if (!validData.Item1)
                        throw new Exception(validData.Item2);
                    else
                        this.date = value;
                }
                catch (Exception ex)
                { throw ex; }
            }
        }
        public string Vaccine_Type
        {
            get => this.vaccine_type;
            set
            {
                try
                {
                    (bool, string) validData = InputValidator.IsValidVaccineInfo(value);

                    if (value.Length > 150)
                        throw new Exception("Vaccine type must be 150 characters or less");
                    else if (string.IsNullOrEmpty(value))
                        throw new Exception("Vaccine type cannot be empty or null");
                    else if (!validData.Item1)
                        throw new Exception(validData.Item2);
                    else
                        this.vaccine_type = value;
                }
                catch(Exception ex)
                { throw ex; }
            }
        }
        public string Dose_Number
        {
            get => this.dose_number;
            set
            {
                try
                {
                    (bool, string) validData = InputValidator.IsValidDose(value);

                    if (value.Length > 3)
                        throw new Exception("Dose number must be 3 characters or less");
                    else if (string.IsNullOrEmpty(value))
                        throw new Exception("Dose number cannot be empty or null");
                    else if (!validData.Item1)
                        throw new Exception(validData.Item2);
                    else
                        this.dose_number = value;
                }
                catch(Exception ex)
                { throw ex; }
            }
        }
        public string Company
        {
            get => this.company;
            set
            {
                (bool, string) validData = InputValidator.IsValidStringData(value);

                if (value.Length > 35)
                    throw new Exception("Vaccine Manufacturer must be 25 characters or less");
                else if (string.IsNullOrEmpty(value))
                    throw new Exception("Vaccine Manufacturer cannot be empty or null");
                else if (!validData.Item1)
                    throw new Exception(validData.Item2);
                else
                    this.company = value;
            }
        }
    }
}
