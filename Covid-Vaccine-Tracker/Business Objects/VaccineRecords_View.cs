using System;
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
        public string Vaccine_Event_Id { get; set; }
        public DateTime Administration_Date { get; set; }
        public string Vaccine_Type { get; set; }
        public string Vaccine_Product { get; set; }
        public string Vaccine_Manufacturer { get; set; }
        public string Lot_Number { get; set; }
        public DateTime Vaccine_Experation_Date { get; set; }
        public string Vaccine_Admin_Site { get; set; }
        public string Vaccine_Admin_Route { get; set; }
        public string Dose_Number { get; set; }
        public string Vaccine_Series_Complete { get; set; }
        public string Responsibile_Organization { get; set; }
        public string Administrated_Location { get; set; }
        public string Vtcks_Pin { get; set; }
        public string Administrated_Loc_Type { get; set; }
        public string Admin_Street_Address { get; set; }
        public string Admin_City { get; set; }
        public string Admin_County { get; set; }
        public string Admin_State { get; set; }
        public string Admin_Zip { get; set; }
        public string Admin_Suffix { get; set; }
        public string Comorbidity_Status { get; set; }
        public string Serology_Results { get; set; }
        public string PPRL { get; set; }
    }
}
