using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Covid_Vaccine_Tracker.Business_Objects
{
    public class Provider
    {
        public string id;
        public string username;
        public string first_name;
        public string last_name;
        public string provider_suffix;
        public string vtcks_pin;
        public string parent_organization;
        public string administered_location;
        public string location_type;
        public string location_street_address;
        public string location_city;
        public string location_county;
        public string location_state;
        public string location_zipcode;

        // MUST ADD THE VALIDATION use InputValidator class
        public string Id {
            get => this.id;
            set
            {
                try 
                {
                    (bool, string) validData = InputValidator.IsValidIdFormat(value); //how many letters? numbers?

                    if (value.Length > 10)
                        throw new Exception("Id must be 10 characters or less");
                    else if (string.IsNullOrEmpty(value))
                        throw new Exception("Id cannot be empty or null");
                    else if (!validData.Item1) // If validData.item1 = false ID is in wrong format
                        throw new Exception(validData.Item2);
                    else
                        this.id = value; // If good assign value to Id
                }
                catch (Exception ex)
                { throw ex; }
            }
        } // 10
        public string Username
        {
            //sergio
            get => this.username;
            set
            {
                try
                {
                    (bool, string) validData = InputValidator.isValidUsername(value);
                    if (value.Length > 20)
                        throw new Exception("Username must be 20 characters or less");
                    else if (string.IsNullOrEmpty(value))
                        throw new Exception("Username cannot be empty or null");
                    else if (!validData.Item1)
                        throw new Exception(validData.Item2);
                    else
                        this.username = value;
                }
                catch (Exception ex)
                { throw ex; }
            }
        }//20
        public string First_Name
        {
            get => this.first_name;
            set
            {
                try
                {
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
                catch (Exception ex)
                { throw ex; }
            }
        }//25
        public string Last_Name
        {
            get => this.last_name;
            set
            {
                try
                {
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
        }//35
        public string Provider_Suffix
        {
            get => this.provider_suffix;
            set
            {
                try
                {
                    (bool, string) validData = InputValidator.IsValidStringData(value);

                    if (value.Length > 3)
                        throw new Exception("Provider suffix must be 3 characters or less");
                    else if (string.IsNullOrEmpty(value))
                        throw new Exception("Provider suffix cannot be empty or null");
                    else if (!validData.Item1)
                        throw new Exception("Provider suffix " + validData.Item2);
                    else
                        this.provider_suffix = value;
                }
                catch (Exception ex)
                { throw ex; }
            }
        }//3
        public string Vtcks_Pin
        {
            get => this.vtcks_pin;
            set
            {
                try 
                {
                    (bool, string) validData = InputValidator.IsValidVtck(value);

                    if (value.Length > 6) 
                        throw new Exception("Vtcks pin must be 6 characters or less");
                    else if (string.IsNullOrEmpty(value)) 
                        throw new Exception("Vtcks pin cannot be empty or null");
                    else if (!validData.Item1) // If validData.item1 = false ID is in wrong format
                        throw new Exception(validData.Item2);
                    else
                        this.vtcks_pin = value; // If good assign value to Id
                }
                catch (Exception ex)
                { throw ex; }
            }
        }// msut be 6
        public string Parent_Organization
        {
            get => this.parent_organization;
            set
            {
                try
                {
                    (bool, string) validData = InputValidator.IsValidStringData(value);

                    if (value.Length > 100)
                        throw new Exception("Organization name must be 100 characters or less");
                    else if (string.IsNullOrEmpty(value))
                        throw new Exception("Organization name cannot be empty or null");
                    else if (!validData.Item1)
                        throw new Exception("Parent organization" + validData.Item2);
                    else
                        this.parent_organization = value;
                }
                catch (Exception ex)
                { throw ex; }
            }
        }//100
        public string Administered_Location
        {
            get => this.administered_location;
            set
            {
                try
                {
                    (bool, string) validData = InputValidator.IsValidStringData(value);

                    if (value.Length > 100)
                        throw new Exception("Administered location name must be 100 characters or less");
                    else if (string.IsNullOrEmpty(value))
                        throw new Exception("Administered location name cannot be empty or null");
                    else if (!validData.Item1)
                        throw new Exception("Administered location " + validData.Item2);
                    else
                        this.administered_location = value;
                }
                catch (Exception ex)
                { throw ex; }
            }
        }//100
        public string Location_Type
        {
            get => this.location_type;
            set
            {
                try
                {
                    (bool, string) validData = InputValidator.IsValidStringData(value);

                    if (value.Length > 100)
                        throw new Exception("Location type must be 100 characters or less");
                    else if (string.IsNullOrEmpty(value))
                        throw new Exception("Location type cannot be empty or null");
                    else if (!validData.Item1)
                        throw new Exception("Location type " + validData.Item2);
                    else
                        this.location_type = value;
                }
                catch (Exception ex)
                { throw ex; }
            }
        }//100
        public string Location_Street_Address
        {
            get => this.location_street_address;
            set
            {
                try
                {
                    (bool, string) validInput = InputValidator.IsValidStreet(value);

                    if (value.Length > 100)
                        throw new Exception("Street address must be 100 characters or less");
                    else if (string.IsNullOrEmpty(value))
                        throw new Exception("Street address cannot be empty or null");
                    else if (!validInput.Item1)
                        throw new Exception("Street address " + validInput.Item2);
                    else
                        this.location_street_address = value;
                }
                catch (Exception ex)
                { throw ex; }
            }
        }//100
        public string Location_City
        {
            get => this.location_city;
            set
            {
                try
                {
                    (bool, string) validData = InputValidator.IsValidStringData(value);

                    if (value.Length > 100)
                        throw new Exception("City must be 100 characters or less");
                    else if (string.IsNullOrEmpty(value))
                        throw new Exception("City cannot be empty or null");
                    else if (!validData.Item1)
                        throw new Exception("City" + validData.Item2);
                    else
                        this.location_city = value;
                }
                catch (Exception ex)
                { throw ex; }
            }
        }//100
        public string Location_County
        {
            get => this.location_county;
            set
            {
                try
                {
                    (bool, string) validData = InputValidator.IsValidStringData(value);

                    if (value.Length > 100)
                        throw new Exception("County must be 100 characters or less");
                    else if (string.IsNullOrEmpty(value))
                        throw new Exception("County cannot be empty or null");
                    else if (!validData.Item1)
                        throw new Exception("County" + validData.Item2);
                    else
                        this.location_county = value;
                }
                catch (Exception ex)
                { throw ex; }
            }
        }//100
        public string Location_State
        {
            get => this.location_state;
            set
            {
                try
                {
                    (bool, string) validData = InputValidator.IsValidStringData(value);

                    if (value.Length > 50)
                        throw new Exception("State must be 50 characters or less");
                    else if (string.IsNullOrEmpty(value))
                        throw new Exception("State cannot be empty or null");
                    else if (!validData.Item1)
                        throw new Exception("State" + validData.Item2);
                    else
                        this.location_state = value;
                }
                catch (Exception ex)
                { throw ex; }
            }
        }//50
        public string Location_Zipcode
        {
            get => this.location_zipcode;
            set
            {
                try
                {
                    if (value.Length != 5)
                        throw new Exception("Zipcode must be 5 characters");
                    else if (string.IsNullOrEmpty(value))
                        throw new Exception("Zipcode cannot be empty or null");
                    else
                        this.location_zipcode = value;
                }
                catch (Exception ex)
                { throw ex; }
            }
        }//5
        public Provider CopyProvider()
        {
            // this copys the current provider object and allows you to assign
            // a copy to a new provider object
            return (Provider)this.MemberwiseClone();
        }
    }

}
