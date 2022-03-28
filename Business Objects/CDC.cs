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

        public string id { get; set; }
        public string Username { get; set; }
        public string First_name { get; set; }
        public string Last_name { get; set; }

        public CDC CopyCdcUser()
        {
            return (CDC)this.MemberwiseClone();
        }
    }
}
