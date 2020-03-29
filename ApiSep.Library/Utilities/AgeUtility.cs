using System;

namespace ApiSep.Library.Utilities
{
    /**
     * Usage example:
     * ==============
     * DateTime bday = new DateTime(1987, 11, 27);
     * DateTime cday = DateTime.Today;
     * Age age = new Age(bday, cday);
     * Console.WriteLine("It's been {0} years, {1} months, and {2} days since your birthday", age.Year, age.Month, age.Day);
     */


    public class AgeUtility
    {
        public int Years;
        public int Months;
        public int Days;

        public AgeUtility(DateTime bday)
        {
            this.Count(bday);
        }

        public AgeUtility(DateTime bday, DateTime cday)
        {
            this.Count(bday, cday);
        }

        public AgeUtility Count(DateTime bday)
        {
            return this.Count(bday, DateTime.Today);
        }

        public AgeUtility Count(DateTime bday, DateTime cday)
        {
            if ((cday.Year - bday.Year) > 0 ||
                (((cday.Year - bday.Year) == 0) && ((bday.Month < cday.Month) ||
                                                    ((bday.Month == cday.Month) && (bday.Day <= cday.Day)))))
            {
                int DaysInBdayMonth = DateTime.DaysInMonth(bday.Year, bday.Month);
                int DaysRemain = cday.Day + (DaysInBdayMonth - bday.Day);

                if (cday.Month > bday.Month)
                {
                    this.Years = cday.Year - bday.Year;
                    this.Months = cday.Month - (bday.Month + 1) + Math.Abs(DaysRemain / DaysInBdayMonth);
                    this.Days = (DaysRemain % DaysInBdayMonth + DaysInBdayMonth) % DaysInBdayMonth;
                }
                else if (cday.Month == bday.Month)
                {
                    if (cday.Day >= bday.Day)
                    {
                        this.Years = cday.Year - bday.Year;
                        this.Months = 0;
                        this.Days = cday.Day - bday.Day;
                    }
                    else
                    {
                        this.Years = (cday.Year - 1) - bday.Year;
                        this.Months = 11;
                        this.Days = DateTime.DaysInMonth(bday.Year, bday.Month) - (bday.Day - cday.Day);
                    }
                }
                else
                {
                    this.Years = (cday.Year - 1) - bday.Year;
                    this.Months = cday.Month + (11 - bday.Month) + Math.Abs(DaysRemain / DaysInBdayMonth);
                    this.Days = (DaysRemain % DaysInBdayMonth + DaysInBdayMonth) % DaysInBdayMonth;
                }
            }
            else
            {
                throw new ArgumentException("Birthday date must be earlier than current date");
            }
            return this;
        }

        public string AgeString
        {
            get
            {
                string ageString;

                if (Years < 1 && Months < 1)
                {
                    ageString = $"{Days} Days";
                }
                /*else if (Years < 3)
                {
                    ageString = $"{Years * 12 + Months} Months {Days} Days";
                }*/
                else
                {
                    ageString = $"{Years} Years {Months} Months {Days} Days";
                }

                return ageString;
            }
        }

    }
}

