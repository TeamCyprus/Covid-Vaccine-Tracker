using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Covid_Vaccine_Tracker.Business_Objects
{
    public class CDC
    {
        // need to add the Data Annotations
        public string id;
        public string username;
        public string first_name;
        public string last_name;

        public string Id
        {
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
        }
        public string Username
        {
            get => this.username;
            set
            {
                try
                {
                    (bool, string) validData = InputValidator.isValidUsername(value);
                    if (value.Length > 20)
                        throw new Exception("CDC username must be 20 characters or less");
                    else if (string.IsNullOrEmpty(value))
                        throw new Exception("CDC username cannot be empty or null");
                    else if (!validData.Item1)
                        throw new Exception(validData.Item2);
                    else
                        this.username = value;
                }
                catch (Exception ex)
                { throw ex; }
            }
        }
        public string First_name
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
        }
        public string Last_name
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
        }

        public CDC CopyCdcUser()
        {
            return (CDC)this.MemberwiseClone();
        }
    }
}
