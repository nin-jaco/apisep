using System;
using System.Runtime.Serialization;
using Microsoft.Exchange.WebServices.Data;

namespace ApiSep.Library.Models.other
{
    [Serializable]
    [DataContract(Namespace = "ApiSep.Library.Models.other", Name = "AppointmentItem")]
    [KnownType(typeof(AppointmentItem))]
    public class AppointmentItem
    {
        [DataMember]
        public string Id { get; set; }

        [DataMember]
        public string Subject { get; set; }
        [DataMember]
        public DateTime Start { get; set; }
        [DataMember]
        public DateTime End { get; set; }
        [DataMember]
        public string RecurrenceRule { get; set; }
        [DataMember]
        public string RecurrenceParentId { get; set; }
        [DataMember]
        public int? UserId { get; set; }
        [DataMember]
        public string Reminder { get; set; }

        public AppointmentItem()
        {
            Id = Guid.NewGuid().ToString();
        }

        public AppointmentItem(string subject, DateTime start, DateTime end,
            string recurrenceRule, string recurrenceParentId, string reminder, int? userId, string id)
        {
            Subject = subject;
            Start = start;
            End = end;
            RecurrenceRule = recurrenceRule;
            RecurrenceParentId = recurrenceParentId;
            Reminder = reminder;
            UserId = userId;
            Id = id;
        }

        public AppointmentItem(Appointment source)
        {
            Subject = source.Subject;
            Start = source.Start;
            End = source.End;
            Id = source.Id.ToString();

            //if (source.RecurrenceParentID != null)
            //{
            //    RecurrenceParentId = source.RecurrenceParentID.ToString();
            //}

            //if (!string.IsNullOrEmpty(Reminder))
            //{
            //    Reminder = source.Reminders[0].ToString();
            //}

            //var user = source.Resources..GetResourceByType("User");

            //if (user != null)
            //{
            //    UserId = (int?)user.Key;
            //}
            //else
            //{
            //    UserId = null;
            //}
        }



    }

}
