using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Covid_Vaccine_Tracker.Business_Objects
{
    public static class IdGenerator
    {
        // this class generates random codes for the ids
        // patientID, PPRL, VaxEventID, ProviderID, and CDCID
        private static Random randomNumber = new Random();

        public static string GenerateRandomLetter(int stringLength, int minLetter, int maxLetter)
        {
            var letterSequence = new StringBuilder();
            char randomChar = new char();
          
            for (int letter = 0; letter < stringLength; letter++)
            {
                // randomNumber.Next('A','Z')
                randomChar = (char)randomNumber.Next(minLetter, maxLetter);
                letterSequence.Append(randomChar);
            }
            
            return letterSequence.ToString();
        }
        public static string GenerateRandomNumber(int stringLength, int min, int max)
        {
            var numberSequence = new StringBuilder();
            
            for(int digit = 0; digit < stringLength; digit++)
            {
                numberSequence.Append(randomNumber.Next(min, max));
            }

            return numberSequence.ToString();
        }
        // Note when passing in minLetter & maxLetter need to be passed in as char 'a'-'z' or 'A'-'Z'
        // Then chagned to ascii value. Can be any letter range
        public static string GenerateId( int minNumber, int maxNumber, int minLetter, int maxLetter)
        {
            var id = new StringBuilder();
            // returns a 7 digit string of number 0 -9
            id.Append(GenerateRandomNumber(7, minNumber, maxNumber));
            // returns a 3 digit string of random characters A-Z
            id.Append(GenerateRandomLetter(3, minLetter, maxLetter));

            // since id is a StringBuilder obj convert to string to return
            return id.ToString();
        }
        public static string GenerateId(int stringLength, int NumberOFletters, int minNumber, int maxNumber, int minLetter, int maxLetter)
        {
            var id = new StringBuilder();
            // Determine how many numbers are in id after letters are subtracted
            int numberOfnumbers = stringLength - NumberOFletters;
            // Create number portion of id the length of numberOfnumbers
            id.Append(GenerateRandomNumber(numberOfnumbers, minNumber, maxNumber));
            // Now create letter portion of id the length of NumberOFletters
            // minLetter & maxLetter are passed in as 'a'-'z' or 'A'-'Z' then changed into asci value
            // can be any letter range
            id.Append(GenerateRandomLetter(NumberOFletters, minLetter, maxLetter));

            // since id is a StringBuilder obj convert to string to return
            return id.ToString();
        }


    }
}
