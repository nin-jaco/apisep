using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using ApiSep.Library.Enums;
using ApiSep.Library.Extensions;

namespace ApiSep.Library.Models.other
{
    [DataContract]
    public class DateObject
    {
        [DataMember]
        public string Description { get; set; }
        [DataMember]
        public DateTime StartDate { get; set; }
        [DataMember]
        public DateTime EndDate { get; set; }

        public DateObject()
        {
        }

        public DateObject(DateGroupEnum dateGroupEnum)
        {
            Description = dateGroupEnum.Description();
            switch (dateGroupEnum)
            {
                case DateGroupEnum.LastMonth:
                    StartDate = new DateTime(DateTime.Today.AddMonths(-1).Year, DateTime.Today.AddMonths(-1).Month, 1);
                    EndDate = new DateTime(DateTime.Today.AddMonths(-1).Year, DateTime.Today.AddMonths(-1).Month, DateTime.DaysInMonth(DateTime.Today.AddMonths(-1).Year, DateTime.Today.AddMonths(-1).Month));
                    break;
                case DateGroupEnum.LastThreeMonths:
                    StartDate = new DateTime(DateTime.Today.AddMonths(-3).Year, DateTime.Today.AddMonths(-3).Month, 1);
                    EndDate = DateTime.Today;
                    break;
                case DateGroupEnum.LastSixMonths:
                    StartDate = new DateTime(DateTime.Today.AddMonths(-6).Year, DateTime.Today.AddMonths(-6).Month, 1);
                    EndDate = DateTime.Today;
                    break;
                case DateGroupEnum.ThisMonth:
                    StartDate = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
                    EndDate = DateTime.Today;
                    break;
                case DateGroupEnum.ThisWeek:
                    StartDate = DateTime.Today.AddDays(-(int)DateTime.Today.DayOfWeek + (int)DayOfWeek.Monday);
                    EndDate = DateTime.Today;
                    break;
                case DateGroupEnum.ThisYear:
                    StartDate = new DateTime(DateTime.Today.Year, 1, 1);
                    EndDate = DateTime.Today;
                    break;
                case DateGroupEnum.Today:
                    StartDate = DateTime.Today;
                    EndDate = DateTime.Today;
                    break;
                case DateGroupEnum.LastSevenDays:
                    StartDate = DateTime.Today.AddDays(-7);
                    EndDate = DateTime.Today;
                    break;
                case DateGroupEnum.LastThirtyDays:
                    StartDate = DateTime.Today.AddDays(-30);
                    EndDate = DateTime.Today;
                    break;
                default:
                    StartDate = DateTime.Today;
                    EndDate = DateTime.Today;
                    break;
            }//--/switch
        }//--/public DateObject

        public List<DateObject> GetDateObjects()
        {
            return (from DateGroupEnum dateObject in Enum.GetValues(typeof(DateGroupEnum)) select new DateObject(dateObject)).ToList();
        }
    }
}
