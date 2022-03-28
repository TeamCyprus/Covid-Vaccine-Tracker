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
        public string Username { get; set; }
        public string Password { get; set; }
        public string User_Type { get; set; }
    }
}
