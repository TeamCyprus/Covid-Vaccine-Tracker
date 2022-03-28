using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Covid_Vaccine_Tracker.Business_Objects
{
    public class VaccineRecord
    {
        public string extract_type; //15
        public string vaccine_event_id; //10
        public DateTime administration_date; 
        public string vaccine_type; // 150
        public string vaccine_product; //75
        public string vaccine_manufacturer;//35
        public string lot_number;//10
        public DateTime vaccine_experation_date;
        public string vaccine_admin_site;//50
        public string vaccine_admin_route;//35
        public string dose_number;//3
        public string vaccine_series_complete;//7
        public string responsible_organization;//100
        public string administrated_location;//100
        public string vtcks_pin;//6
        public string administered_loc_type;//35
        public string admin_street_address;//100
        public string admin_city;//100
        public string admin_county;//100
        public string admin_state;//50
        public string admin_zip;//5
        public string admin_suffix;//3
        public string comorbidity_status;//7
        public string serology_results;//7
        public string pprl;//10

        public string Extract_Type
        {
            get => this.extract_type;
            set
            {
                try
                {
                    (bool, string) validData = InputValidator.IsValidStringData(value);

                    if (value.Length > 15)
                        ThrowError("Extract type must be 15 characters or less");
                    else if (string.IsNullOrEmpty(value))
                        ThrowError("Extract type cannot be empty or null");
                    else if (!validData.Item1)
                        throw new Exception(validData.Item2);
                    else
                        this.extract_type = value;
                }
                catch (Exception ex)
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
                    (bool, string) validData = InputValidator.IsValidVaccineEvent(value);

                    if (value.Length > 10)
                        ThrowError("Vaccine Event must 10 characters");
                    else if (string.IsNullOrEmpty(value))
                        ThrowError("Vaccine Event Id cannot be empty or null");
                    else if (!validData.Item1)
                        throw new Exception(validData.Item2);
                    else
                        this.vaccine_event_id = value;
                }
                catch(Exception ex)
                { throw ex; }
            }
        }
        public DateTime Administration_Date
        {
            get => this.administration_date;
            set
            {
                try
                {
                    (bool, string) valid = InputValidator.IsValidDate(value);

                    if (value > DateTime.Today || value < DateTime.Now.AddYears(-3))
                        ThrowError("Invald date, date of vaccine administration is out of bounds");
                    else if (string.IsNullOrEmpty(value.ToString()))
                        ThrowError("Administration date cannot be blank");
                    else if (!valid.Item1)
                        throw new Exception(valid.Item2);
                    else
                        this.administration_date = value;
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

                    (bool, string) valid = InputValidator.IsValidVaccineInfo(value);

                    if (value.Length > 150)
                        ThrowError("Vaccine type must be 150 characters or less");
                    else if (string.IsNullOrEmpty(value))
                        ThrowError("Vaccine type cannot be empty or null");
                    else if (!valid.Item1)
                        ThrowError(valid.Item2);
                    else
                        this.vaccine_type = value;
                }
                catch (Exception ex)
                { throw ex; }
            }
        }
        public string Vaccine_Product
        {
            get => this.vaccine_product;
            set
            {
                try
                {
                    (bool, string) valid = InputValidator.IsValidVaccineInfo(value);

                    if (value.Length > 75)
                        ThrowError("Vaccine product must be 75 characters or less");
                    else if (string.IsNullOrEmpty(value))
                        ThrowError("Vaccine product cannot be empty or null");
                    else if (!valid.Item1)
                        ThrowError(valid.Item2);
                    else
                        this.vaccine_product = value;
                }
                catch (Exception ex)
                { throw ex; }
            }
        }
        public string Vaccine_Manufacturer
        {
            get => this.vaccine_manufacturer;
            set
            {
                try
                {
                    (bool, string) valid = InputValidator.IsValidStringData(value);

                    if (value.Length > 35)
                        ThrowError("Vaccine Manufacuturer must be 35 characters or less");
                    else if (string.IsNullOrEmpty(value))
                        ThrowError("Vaccine Manufacturer cannot be empty or null");
                    else if (!valid.Item1)
                        ThrowError(valid.Item2);
                    else
                        this.vaccine_manufacturer = value;
                }
                catch(Exception ex)
                { throw ex; }
            }
        }
        public string Lot_Number
        {
            get => this.lot_number;
            set
            {
                try
                {
                    (bool, string) valid = InputValidator.IsValidLotNumber(value);

                    if (value.Length > 10)
                        ThrowError("Lot number must be 10 characters or less");
                    else if (string.IsNullOrEmpty(value))
                        ThrowError("Lot Number cannot be empty or null");
                    else if (!valid.Item1)
                        ThrowError(valid.Item2);
                    else
                        this.lot_number = value;
                }
                catch(Exception ex)
                { throw ex; }
            }
        }
        public DateTime Vaccine_Experation_Date
        {
            get => this.vaccine_experation_date;
            set
            {
                try
                {
                    (bool, string) valid = InputValidator.IsValidDate(value);

                    if (value < DateTime.Today)
                        ThrowError("Vaccine experation date is passed do not use vaccine");
                    else if (string.IsNullOrEmpty(value.ToString()))
                        ThrowError("Vaccine experation cannot be empty or null");
                    else if (!valid.Item1)
                        ThrowError(valid.Item2);
                    else
                        this.vaccine_experation_date = value;
                }
                catch(Exception ex)
                { throw ex; }
            }
        }
        public string Vaccine_Admin_Site
        {
            get => this.vaccine_admin_site;
            set
            {
                try
                {
                    (bool, string) valid = InputValidator.IsValidStringData(value);

                    if (value.Length > 50)
                        ThrowError("Vaccine administration Site must be 50 characters or less");
                    else if (string.IsNullOrEmpty(value))
                        ThrowError("Vaccine administration Site cannot be empty or null");
                    else if (!valid.Item1)
                        ThrowError(valid.Item2);
                    else
                        this.vaccine_admin_site = value;
                }
                catch(Exception ex)
                { throw ex; }
            }
        }

        public string Vaccine_Admin_Route
        {
            get => this.vaccine_admin_route;
            set
            {
                try
                {
                    (bool, string) valid = InputValidator.IsValidStringData(value);

                    if (value.Length > 35)
                        ThrowError("Vaccine administration route must be 35 characters or less");
                    else if (string.IsNullOrEmpty(value))
                        ThrowError("Vaccine administration route cannot be empty or null");
                    else if (!valid.Item1)
                        ThrowError(valid.Item2);
                    else
                        this.vaccine_admin_route = value;
                }
                catch (Exception ex)
                {
                    throw ex;

                }
            }
        }

        public string Dose_Number


        {
            get => this.dose_number;
            set
            {
                try
                {
                    (bool, string) valid = InputValidator.IsValidDose(value);

                    if (value.Length > 3) //what is this? 
                        ThrowError("Dose number must be 3 characters or less");
                    else if (string.IsNullOrEmpty(value))
                        ThrowError("Dose number cannot be empty or null");
                    else if (!valid.Item1)
                        ThrowError(valid.Item2);
                    else
                        this.dose_number = value;
                }
                catch(Exception ex)
                { throw ex; }
            }
        }
        public string Vaccine_Series_Complete
        {
            get => this.vaccine_series_complete;
            set
            {
                try
                {
                    (bool, string) valid = InputValidator.IsValidStringData(value);

                    if (value.Length > 7)
                        ThrowError("Vaccinne sereis status must be 7 characters or less");
                    else if (string.IsNullOrEmpty(value))
                        ThrowError("Vaccine Series status cannot be empty or null");
                    else if (!valid.Item1)
                        ThrowError(valid.Item2);
                    else
                        this.vaccine_series_complete = value;
                }
                catch(Exception ex)
                { throw ex; }
            }
        }
        public string Responsible_Organization
        {
            get => this.responsible_organization;
            set
            {
                try
                {
                    (bool, string) valid = InputValidator.IsValidStringData(value);

                    if (value.Length > 100)
                        ThrowError("Responsible organization must be 100 characters or less");
                    else if (string.IsNullOrEmpty(value))
                        ThrowError("Responsible organization cannot be empty or null");
                    else if (!valid.Item1)
                        ThrowError(valid.Item2);
                    else
                        this.responsible_organization = value;
                }
                catch(Exception ex)
                { throw ex; }
            }
        }
        public string Administrated_Location
        {
            get => this.administrated_location;
            set
            {
                try
                {
                    (bool, string) valid = InputValidator.IsValidStringData(value);

                    if (value.Length > 100)
                        ThrowError("Adminstrated locatioin must be 100 characters or less");
                    else if (string.IsNullOrEmpty(value))
                        ThrowError("Administrated location cannot be empty or null");
                    else if (!valid.Item1)
                        ThrowError(valid.Item2);
                    else
                        this.administrated_location = value;
                }
                catch(Exception ex)
                { throw ex; }
            }
        }
        public string Vtcks_Pin
        {
            get => this.vtcks_pin;
            set
            {
                try
                {
                    (bool, string) valid = InputValidator.IsValidVtck(value);

                    if (value.Length > 6 || value.Length < 6)
                        ThrowError("Vtcks pin must be 6 characters");
                    else if (string.IsNullOrEmpty(value))
                        ThrowError("Vtcks pin cannot be empty or null");
                    else if (!valid.Item1)
                        ThrowError(valid.Item2);
                    else
                        this.vtcks_pin = value;
                }
                catch(Exception ex)
                { throw ex; }
            }
        }
        public string Administrated_Loc_Type
        {
            get => this.administered_loc_type;
            set
            {
                try
                {
                    (bool, string) valid = InputValidator.IsValidStringData(value);

                    if (value.Length > 35)
                        ThrowError("Administrated location type must be 35 characters or less");
                    else if (string.IsNullOrEmpty(value))
                        ThrowError("Administrated location type cannot be empty or null");
                    else if (!valid.Item1)
                        ThrowError(valid.Item2);
                    else
                        this.administered_loc_type = value;
                }
                catch(Exception ex)
                { throw ex; }
            }
        }
        public string Admin_Street_Address
        {
            get => this.admin_street_address;
            set
            {
                try
                {
                    (bool, string) valid = InputValidator.IsValidStreet(value);

                    if (value.Length > 100)
                        ThrowError("Admin street address must be 100 characters or less");
                    else if (string.IsNullOrEmpty(value))
                        ThrowError("Admin street address cannot be empty or null");
                    else if (!valid.Item1)
                        ThrowError(valid.Item2);
                    else
                        this.admin_street_address = value;
                }
                catch(Exception ex)
                { throw ex; }
            }
        }
        public string Admin_City
        {
            get => this.admin_city;
            set
            {
                try
                {
                    (bool, string) valid = InputValidator.IsValidStringData(value);

                    if (value.Length > 100)
                        ThrowError("Admin city must be 100 characters or less");
                    else if (string.IsNullOrEmpty(value))
                        ThrowError("Admin city cannot be empty or null");
                    else if (!valid.Item1)
                        ThrowError(valid.Item2);
                    else
                        this.admin_city = value;
                }
                catch(Exception ex)
                { throw ex; }
            }
        }
        public string Admin_County
        {
            get => this.admin_county;
            set
            {
                try
                {
                    (bool, string) valid = InputValidator.IsValidStringData(value);

                    if (value.Length > 100)
                        ThrowError("Admin county must be 100 characters or less");
                    else if (string.IsNullOrEmpty(value))
                        ThrowError("Admin county cannot be empty or null");
                    else if (!valid.Item1)
                        ThrowError(valid.Item2);
                    else
                        this.admin_county = value;
                }
                catch(Exception ex)
                { throw ex; }
            }
        }
        public string Admin_State
        {
            get => this.admin_state;
            set
            {
                try
                {
                    (bool, string) valid = InputValidator.IsValidStringData(value);

                    if (value.Length > 50)
                        ThrowError("Admin state must be 50 characters or less");
                    else if (string.IsNullOrEmpty(value))
                        ThrowError("Admin state cannot be empty or null");
                    else if (!valid.Item1)
                        ThrowError(valid.Item2);
                    else
                        this.admin_state = value;
                }
                catch(Exception ex)
                { throw ex; }
            }
        }
        public string Admin_Zip
        {
            get => this.admin_zip;
            set
            {
                try
                {
                    (bool, string) valid = InputValidator.IsAllNumbers(value);

                    if (value.Length > 5 || value.Length < 5)
                        ThrowError("Admin zipcode must be 5 characters");
                    else if (string.IsNullOrEmpty(value))
                        ThrowError("Admin zipcode cannot be empty or null");
                    else if (!valid.Item1)
                        ThrowError(valid.Item2);
                    else
                        this.admin_zip = value;
                }
                catch(Exception ex)
                { throw ex; }
            }
        }
        public string Admin_Suffix
        {
            get => this.admin_suffix;
            set
            {
                try
                {
                    (bool, string) valid = InputValidator.IsValidStringData(value);

                    if (value.Length > 3)
                        ThrowError("Provider suffix must be 3 characters or less");
                    else if (string.IsNullOrEmpty(value))
                        ThrowError("Provider suffix cannot be empty or null");
                    else if (!valid.Item1)
                        ThrowError(valid.Item2);
                    else
                        this.admin_suffix = value;
                }
                catch(Exception ex)
                { throw ex; }
            }
        }
        public string Comorbidity_Status
        {
            get => this.comorbidity_status;
            set
            {
                try
                {
                    (bool, string) valid = InputValidator.IsValidStringData(value);

                    if (value.Length > 7)
                        ThrowError("Comorbidity status must be 7 characters or less");
                    else if (string.IsNullOrEmpty(value))
                        ThrowError("Comorbidity status cannot be empty or null");
                    else if (!valid.Item1)
                        ThrowError(valid.Item2);
                    else
                        this.comorbidity_status = value;
                }
                catch(Exception ex)
                { throw ex; }
            }
        }
        public string Serology_Results
        {
            get => this.serology_results;
            set
            {
                try
                {
                    (bool, string) valid = InputValidator.IsValidStringData(value);

                    if (value.Length > 7)
                        ThrowError("Serology Results must be 7 characters or less");
                    else if (string.IsNullOrEmpty(value))
                        ThrowError("Serology Results cannot be empty or null");
                    else if (!valid.Item1)
                        ThrowError(valid.Item2);
                    else
                        this.serology_results = value;
                }
                catch(Exception ex)
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
                    (bool, string) valid = InputValidator.IsValidPPRL(value);

                    if (value.Length > 10)
                        ThrowError("PPRL number must be 10 characters or less");
                    else if (string.IsNullOrEmpty(value))
                        ThrowError("PPRL number cannot be empty or null");
                    else if (!valid.Item1)
                        ThrowError(valid.Item2);
                    else
                        this.pprl = value;
                }
                catch(Exception ex)
                { throw ex; }
            }
        }
        public static void ThrowError(string msg)
        {
            throw new Exception(msg);
        }
    }
}
