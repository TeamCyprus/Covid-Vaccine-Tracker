using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Covid_Vaccine_Tracker.Business_Objects
{
    public class Identifying_VaccineRecords_View
    {
        public string id;
        public string first_name;
        public string last_name;
        public DateTime date_of_birth;
        public string race1;
        public string race2;
        public string city;
        public string county;
        public string state;
        public string extract_type;
        public string pprl;
        public string vaccine_event_id;
        public DateTime vaccination_date;
        public string vaccine_type;
        public string dose_number;
        public string vax_series_complete;
        public string company;

        public string Id { get; set; }
        public string First_Name { get; set; }
        public string Last_Name { get; set; }
        public string Middle_Name { get; set; }
        public DateTime Date_of_Birth { get; set; }
        public string Race1 { get; set; }
        public string Race2 { get; set; }
        public string City { get; set; }
        public string County { get; set; }
        public string State { get; set; }
        public string Extract_Type { get; set; }
        public string PPRL { get; set; }
        public string Vaccine_Event_Id { get; set; }
        public DateTime Vaccination_Date { get; set; }
        public string Vaccine_Type { get; set; }
        public string Dose_Number { get; set; }
        public string Vax_Series_Complete { get; set; }
        public string Company { get; set; }


    }
}
