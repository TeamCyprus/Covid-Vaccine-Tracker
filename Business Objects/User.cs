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
        [Required]
        [MaxLength(20,ErrorMessage ="Username must be 20 characters or less")]
        [RegularExpression(@"[0-9*?a-z*?A-Z*?]{1,20}",ErrorMessage ="Username must contain letters and numbers only")]
        public string Username { get; set; }

        [Required]
        [MaxLength(65, ErrorMessage = "Password must be 25 characters or less")]
        [RegularExpression(@"^(?=.*[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&+-]).{25,}$",
            ErrorMessage="Password must contain Atleast: " +
            "one uppercase letter, one lowercase letter, one digit, and one special character")]       
        public string Password { get; set; }

        [Required]
        [MaxLength(35,ErrorMessage ="User type must contain 353 characters or less")]
        [RegularExpression(@"[a-zA-Z]{1,35}$",ErrorMessage ="User type can only contain letters")]
        public string User_Type { get; set; }



    }
}
