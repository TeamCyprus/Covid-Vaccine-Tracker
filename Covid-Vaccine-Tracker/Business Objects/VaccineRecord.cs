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
        public string vaccine_product; //75data:image/pjpeg;base64,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
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
                    DateTime noVaxDate = DateTime.Today.AddYears(-3);

                    (bool, string) valid = InputValidator.IsValidDate(value);

                    if (value > DateTime.Today || value < noVaxDate)
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

                    if (value.Length > 3)
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
