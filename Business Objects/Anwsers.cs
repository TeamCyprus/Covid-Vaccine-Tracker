using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Covid_Vaccine_Tracker.Business_Objects
{
    public class Anwsers
    {
        // sinces this type of class is only used to bind 
        // choices to combo-boxs just have simple properties with get and set
        // no validation needed because these values wont be changed
        public int Id { get; set; }

        public string Anwser { get; set; }
    }
}
