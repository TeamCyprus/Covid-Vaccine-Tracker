using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Covid_Vaccine_Tracker.Business_Objects
{
    class Identifying_VaccineRecords_View
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
        public string FirstName { get; set; }


    }
}
