using System.Collections.Generic;

namespace Covid_Vaccine_Tracker.Business_Objects
{
    public  static class Errors
    {
        public static string field, number, format, obj;
        public static string charLenErr = " characters or less";
        public static string digitLenErr = " digits or less";
        public static string err = "Error,";
        public static string errorStart = "Must be ";
        public static string formatStr = " format only";
        public static Dictionary<int, string> ErrorsDict = new Dictionary<int, string>()
        {           
            {1, " cannot be blank or empty." },
            {2, " must contain " },
            {3, " digits long" },
            {4, "Error, you must " }
            
        };
        public static Dictionary<int, string> GeneralErrors = new Dictionary<int, string>()
        {
            {1, " cannot contain numbers" },
            {2, " must contain numbers only" },
            {3, " must contain letters only" },
            {4, " cannot contain letter or symbols, ie @,#,$,%,^,&,*,(,),-,+,!,~." },
            {5, " id does not exist." },
            {6, " is null or empty" },
            {7, " already exists" },
            {8, " format error, must be in " },
            {9, " not found"  },
            {10,  " was not added" },
            {11, " was not updated" },
            {12, " not found, access denied" },


        };
        public static Dictionary<int, string> GeneralErrors2 = new Dictionary<int, string>()
        {
            {0, "You must enter a " },
            {1, "Error unknown " },
            {2, "You must select a " },
            {3, "An error occured while storing " },
            {4, "There was an error while creating " },
            {5, "Invalid " },
            {6, "An error occured while updating " },
            {7, "An error occured while adding " },
            {8, "You must verify " },
        };
        public static Dictionary<int, string> SimpleErrors = new Dictionary<int, string>()
        {          
            {1, "Date must be prior to today's date." },
            {2, "Vaccines cannot be administered to people under 5 years of age." },
            {3, "Invalid birthday, the would be dead." },
            {4, "Password must contain one upper case letter and one special character." },
            {5, "Date cannot be in the future" },
            {6, "You must select a way to agregate the data" },
            {7, "You must select a data option" },
            {8,"Password cannot be blank or empty" },
            {9, "Passwords do not match" },
            {10, "Invalid password" },
            {11,"You must enter a value to search by" },
            {12,"You must select a way to view the record(s)" },
            {13,"There were no results found for specified search criteria" },
            {14, "Unknown operation please try again" },
            {15, "Invalid operation please select a value" },
            {16, "Warning, any data entered is not saved. Do still you wish to close the application?" },
            {17, "Do you wish to close the entire application?" },
            {18, "Invalid username" },
            {19, "Reached max digits allowed" },
            {20, "End of field you cannot add more data" },
            {21, "The security question anwsers do not match" },
        };
        public static string GetCharLengthError(string input, string num)
        {
            return err + input + ErrorsDict[2] + num + charLenErr;
        }
        public static string GetDigitLengthError(string input, string num)
        {
            return err + input + ErrorsDict[2] + num + digitLenErr;
        }
        public static string GetFormatError(string input, string formt)
        {
            return input + ErrorsDict[32] + formt + formatStr;
        }
        public static string GetGeneralError(int ecode, string input)
        {
            return input + GeneralErrors[ecode];
        }
        public static string GetGeneralError2(int code, string input)
        {
            return GeneralErrors2[code] + input;
        }
        public static string GetError(int ecode) => SimpleErrors[ecode];
    }
}
