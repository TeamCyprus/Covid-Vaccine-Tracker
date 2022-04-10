﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Covid_Vaccine_Tracker.Business_Objects
{
    public class VaccineRecords_View
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

        public string Extract_Type { get; set; }
        public string MyProperty { get; set; }
    }
}
