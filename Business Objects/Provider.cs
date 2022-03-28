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
        public string Id { get; set; } // 10
        public string Username { get; set; }// 20
        public string First_Name { get; set; }//25
        public string Last_Name { get; set; }//35
        public string Provider_Suffix { get; set; }//3
        public string Vtcks_Pin { get; set; }// msut be 6
        public string Parent_Organization { get; set; }//100
        public string Administered_Location { get; set; }//100
        public string Location_Type { get; set; }//100
        public string Location_Street_Address { get; set; }//100
        public string Location_City { get; set; }//100
        public string Location_County { get; set; }//100
        public string Location_State { get; set; }//50
        public string Location_Zipcode { get; set; }//5
        public Provider CopyProvider()
        {
            // this copys the current provider object and allows you to assign
            // a copy to a new provider object
            return (Provider)this.MemberwiseClone();
        }
    }

}
