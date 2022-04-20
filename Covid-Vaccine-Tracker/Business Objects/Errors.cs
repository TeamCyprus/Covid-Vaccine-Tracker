using System.Collections.Generic;

namespace Covid_Vaccine_Tracker.Business_Objects
{
    public  class Errors
    {
        public static string field, number, format, obj;
        public static Dictionary<int, string> ErrorsDict = new Dictionary<int, string>()
        {
            {0, $"Error, You must enter a {field}" },
            {1, $"Error, {field} cannot be blank or empty." },
            {2, $"Error, {field} must contain {number} characters or less." },
            {3, $"Error, {field} cannot contain numbers" },
            {4, $"Error, {field} must contain numbers only" },
            {5, $"Error, {field} must contain letters only" },
            {6, $"Error, {field} cannot contain letter or symbols, ie @,#,$,%,^,&,*,(,),-,+,!,~." },
            {7, $"Error, date must be prior to today's date." },
            {8, $"Error, vaccines cannot be administered to people under 5 years of age." },
            {9, $"Invalid birthday, the would be dead." },
            {10, $"Password must contain one upper case letter and one special character." },
            {11, $"Error, you must select a {field}." },
            {12, $"Error, id does not exist." },
            {13, $"Error, date cannot be in the future" },
            {14, $"Error, you must select a way to agregate the data" },
            {15, $"Error, you must select a data option" },
            {16, $"Error, {field} is null or empty" },
            {17,$"Error, password cannot be blank or empty" },
            {18, $"Error, passwords do not match" },
            {19, $"Error, invalid password" },
            {20,$"You must enter a value to search by" },
            {21,$"You must select a way to view the record(s)" },
            {22,$"There were no {field}(s) found for specified search criteria" },
            {23, $"Error, unknown operation please try again" },
            {24, $"Error, invalid operation please select a value" },
            {25, $"Error, that {field} already exists" },
            {26, $"Error, {field} already exists" },
            {27, $"Error, invalid {field}" },
            {28, $"Error, {field} must be {number} digits long" },
            {29, $"Error, {field} must be {number} digits or less" },
            {30, $"Error, {field} must be less than {number} digits" },
            {31, $"Error, you cannot add extra digits to {field}" },
            {32, $"Invalid {field} format, must be in {format} format only" },
            {33, $"Error, {field} not found double check {obj} id"  },
            {34, $"An error occured while storing {field}" },
            {35, $"There was an error while creating {field}" },
            {36, $"Error, {field} was not added" },
            {37, $"Error, {field} was not updated" },
            {38, $"Warning, any data entered is not saved. Do still you wish to close the application?" },
            {39, $"Do you wish to close the entire application?" },
            
        };

        public static string GetLengthErrorMsg(int eCode, string input, string num)
        {
            field = input;
            number = num;
            return ErrorsDict[eCode];
        }
        public static string GetInputErrorMsg(int eCode, string input)
        {
            field = input;
            return ErrorsDict[eCode];
        }
        public static string GetFormatErrorMsg(int eCode, string input, string formt)
        {
            field = input;
            format = formt;
            return ErrorsDict[eCode];
        }
        public static string GetGeneralErrorMsg(int ecode, string input, string idType)
        {
            field = input;
            idType = obj;
            return ErrorsDict[ecode];
        }
        public static string GetErrorMsg(int ecode) => ErrorsDict[ecode];
    }
}
