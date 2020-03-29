
using System.Collections.Generic;

namespace ApiSep.Library.Interfaces
{
    public interface IMailClient<in TSendRx, out TSendRs, in TGetARx, out TGetARs, in TGetAdRx, out TGetAdRs, in TCreateARx, out TCreateARs>
    {
        #region Properties
        string Subject { get; set; }
        string Body { get; set; }
        List<string> ToRecipients { get; set; }
        List<string> CcRecipients { get; set; }
        List<string> BccRecipients { get; set; }
        bool HasAttachment { get; set; }
        List<string> Attachments { get; set; }
        bool ShouldSend { get; set; }
        bool SendReadReceipt { get; set; }

        #endregion

        #region Methods

        TSendRs SendEmail(TSendRx request);

        TGetARs GetAppointmentsForPeriod(TGetARx request);

        TGetAdRs GetAppointmentsForADay(TGetAdRx request);

        TCreateARs CreateAppointment(TCreateARx request);

        #endregion
    }
}
