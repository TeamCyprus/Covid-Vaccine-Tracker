using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace Covid_Vaccine_Tracker.Business_Objects
{
    public class User
    {
        public string username;
        public string password;
        public string user_type;
        public string Username { get; set; }
        public string Password
        {
            get => this.password;
            set
            {
                try
                {
                    (bool, string) validData = InputValidator.isValidPwd(value);

                    if (value.Length > 65)
                        throw new Exception("Password must be 65 characters or less");
                    else if (string.IsNullOrEmpty(value))
                        throw new Exception("Provider suffix cannot be empty or null");
                    else if (!validData.Item1)
                        throw new Exception(validData.Item2);
                    else
                        this.password = value;
                }
                catch (Exception ex)
                { throw ex; }
            }
        }
        public string User_Type { get; set; }
    }
}
