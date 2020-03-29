using System;
using System.Text;
using System.Text.RegularExpressions;

namespace ApiSep.Library.Utilities
{
    public class IdNumberUtility
    {
        private const int ValidLength = 13;
        private const int ControlDigitLocation = 12;
        private const int ControlDigitCheckValue = 10;
        private const int ControlDigitCheckExceptionValue = 9;
        private const string RegexIdPattern = "(?<Year>[0-9][0-9])(?<Month>([0][1-9])|([1][0-2]))(?<Day>([0-2][0-9])|([3][0-1]))(?<Gender>[0-9])(?<Series>[0-9]{3})(?<Citizenship>[0-9])(?<Uniform>[0-9])(?<Control>[0-9])";
        private const bool Valid = true;
        private const bool Invalid = false;

        public string IdNumber { get; set; }

        // constructor
        public IdNumberUtility(string idNumber)
        {
            IdNumber = idNumber;
        }

        public int GetAge()
        {
            if (IsValid())
            {
                DateTime birthDate =
                    DateTime.ParseExact(
                        IdNumber.Substring(0, 2) + "/" + IdNumber.Substring(2, 2) + "/" + IdNumber.Substring(4, 2),
                        "yy/MM/dd", System.Globalization.CultureInfo.InvariantCulture);
                int years = DateTime.Now.Year - birthDate.Year;

                if (years < 0)
                {
                    birthDate =
                        DateTime.ParseExact(
                            "19" + IdNumber.Substring(0, 2) + "/" + IdNumber.Substring(2, 2) + "/" +
                            IdNumber.Substring(4, 2), "yyyy/MM/dd", System.Globalization.CultureInfo.InvariantCulture);
                    years = DateTime.Now.Year - birthDate.Year;
                }

                if (DateTime.Now.Month < birthDate.Month ||
                    (DateTime.Now.Month == birthDate.Month &&
                    DateTime.Now.Day < birthDate.Day))
                    years--;

                return years;
            }
            else
            {
                throw new Exception("Invalid ID");
            }
        }

        // SA citizen check
        public bool IsSaCitizen()
        {
            if (IsValid())
            {
                return int.Parse(IdNumber.Substring(10, 1)) == 0;
            }
            else
            {
                throw new Exception("Invalid ID");
            }
        }

        // gender check
        public bool IsFemale()
        {
            if (IsValid())
            {
                return int.Parse(IdNumber.Substring(6, 1)) < 5;
            }
            else
            {
                throw new Exception("Invalid ID");
            }
        }

        // get date of birth
        public string GetDateOfBirth()
        {
            if (IsValid())
            {
                DateTime date =
                    DateTime.ParseExact(
                        IdNumber.Substring(0, 2) + "/" + IdNumber.Substring(2, 2) + "/" + IdNumber.Substring(4, 2),
                        "yy/MM/dd", System.Globalization.CultureInfo.InvariantCulture);

                int years = DateTime.Now.Year - date.Year;

                if (years < 0)
                {
                    date =
                        DateTime.ParseExact(
                            "19" + IdNumber.Substring(0, 2) + "/" + IdNumber.Substring(2, 2) + "/" +
                            IdNumber.Substring(4, 2), "yyyy/MM/dd", System.Globalization.CultureInfo.InvariantCulture);
                }

                return date.ToShortDateString();
            }
            throw new Exception("Invalid ID");
        }

        public DateTime GetDateOfBirthAsDateTime()
        {
            if (IsValid())
            {
                DateTime date =
                    DateTime.ParseExact(
                        IdNumber.Substring(0, 2) + "/" + IdNumber.Substring(2, 2) + "/" + IdNumber.Substring(4, 2),
                        "yy/MM/dd", System.Globalization.CultureInfo.InvariantCulture);

                int years = DateTime.Now.Year - date.Year;

                if (years < 0)
                {
                    date =
                        DateTime.ParseExact(
                            "19" + IdNumber.Substring(0, 2) + "/" + IdNumber.Substring(2, 2) + "/" +
                            IdNumber.Substring(4, 2), "yyyy/MM/dd", System.Globalization.CultureInfo.InvariantCulture);
                }

                return date;
            }
            else
            {
                throw new Exception("Invalid ID");
            }
        }



        // check whether ID number is valid
        public bool IsValid()
        {
            // assume that the id number is invalid
            var isValidPattern = false;
            var isValidLength = false;
            var isValidControlDigit = false;

            // check length
            if (IdNumber.Length == ValidLength)
            {
                isValidLength = true;
            }

            // match regex pattern, only if length is valid
            if (isValidLength)
            {
                var idPattern = new Regex(RegexIdPattern);

                if (idPattern.IsMatch(IdNumber))
                {
                    //00 will slip through the regex and checksum
                    if (IdNumber.Substring(2, 2) != "00" && IdNumber.Substring(4, 2) != "00")
                    {
                        isValidPattern = true;
                    }
                }
            }

            // check control digit, only if previous validations passed
            if (isValidLength && isValidPattern)
            {
                int a = 0;
                int b = 0;
                int c = 0;
                int cDigit = -1;
                int tmp = 0;
                var even = new StringBuilder();
                string evenResult = null;

                // sum odd digits
                for (var i = 0; i < ValidLength - 1; i = i + 2)
                {
                    a = a + int.Parse(IdNumber[i].ToString());
                }

                // build a string containing even digits
                for (var i = 1; i < ValidLength - 1; i = i + 2)
                {
                    even.Append(IdNumber[i]);
                }
                // multipy by 2
                tmp = int.Parse(even.ToString()) * 2;
                // convert to string again
                evenResult = tmp.ToString();
                // sum the digits in evenResult
                foreach (var t in evenResult)
                {
                    b = b + int.Parse(t.ToString());
                }

                c = a + b;

                cDigit = ControlDigitCheckValue - int.Parse(c.ToString()[1].ToString());
                if (cDigit == int.Parse(IdNumber[ControlDigitLocation].ToString()))
                {
                    isValidControlDigit = true;
                }
                else
                {
                    if (cDigit > ControlDigitCheckExceptionValue)
                    {
                        if (0 == int.Parse(IdNumber[ControlDigitLocation].ToString()))
                        {
                            isValidControlDigit = true;
                        }
                    }
                }
            }

            // final check
            return isValidLength && isValidPattern && isValidControlDigit;
        }

        public bool IsValidSaId()
        {
            //remove any spaces
            IdNumber = IdNumber.Trim();

            //check length is correct
            if (IdNumber.Length != 13)
            {
                return false;
            }

            //check that only numbers have been entered
            double tempDouble = 0;
            if (!double.TryParse(IdNumber, System.Globalization.NumberStyles.None, System.Globalization.NumberFormatInfo.CurrentInfo, out tempDouble))
            {
                return false;
            }

            //get date portion of ID number and Check it
            string sDate = IdNumber.Substring(0, 6);
            int iYY = int.Parse(sDate.Substring(0, 2));
            int iMM = int.Parse(sDate.Substring(2, 2));
            int iDD = int.Parse(sDate.Substring(4, 2));

            //Do the check of date components
            if (iMM < 1 || iMM > 12)
            {
                return false;
            }

            //adds a base year to the number to create a valid DateTime object
            if (iYY <= 10)
            {
                iYY = 2000 + iYY;
            }
            else
            {
                iYY = 1900 + iYY;
            }

            //check the number of days in the selected month
            DateTime dtTemp = new DateTime(iYY, iMM, 1);
            dtTemp = dtTemp.AddMonths(1);
            dtTemp = dtTemp.AddDays(-1);

            int iMaxDays = dtTemp.Day;

            if (iDD < 1 || iDD > iMaxDays)
            {
                return false;
            }

            //check that 3rd last number is not greater than 1
            if (int.Parse(IdNumber.Substring(10, 1)) > 1)
            {
                return false;
            }

            //calculate the check digit of the ID number
            //add all odd digits
            //for each even digit, multiply each by 2 and add the digits of the result together
            //e.g. 9 * 2 = 18; 1 + 8 = 9

            int iOdd = 0;
            int iEven = 0;
            string sTemp = null;

            for (int iLoop = 0; iLoop < 12; iLoop++)
            {
                if ((iLoop + 1) % 2 == 0)
                {
                    //even digits
                    sTemp = "" + (int.Parse(IdNumber.Substring(iLoop, 1)) * 2);
                    if (sTemp.Length < 2)
                        sTemp = "0" + sTemp;

                    iEven += int.Parse(sTemp.Substring(0, 1)) + int.Parse(sTemp.Substring(1, 1));
                }
                else
                {
                    //Odd digits
                    iOdd += int.Parse(IdNumber.Substring(iLoop, 1));
                }
            }

            //add even and odd
            int iTotal = iOdd + iEven;

            //we need to subtract the last 1 digit of the total from 10
            sTemp = iTotal.ToString();
            if (sTemp.Length < 2)
                sTemp = "0" + sTemp;

            int iTemp = 10 - int.Parse(sTemp.Substring(1, 1));

            //make sure we are only dealing with a single digit
            if (iTemp == 10)
                iTemp = 0;

            //make sure this is the same as the last digit of the ID number
            if (int.Parse(IdNumber.Substring(12, 1)) != iTemp)
            {
                return false;
            }

            //if we got here, everything is correct
            return true;
        }
    }
}
