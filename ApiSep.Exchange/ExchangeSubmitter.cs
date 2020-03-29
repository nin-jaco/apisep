using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using ApiSep.Exchange.ApiClasses.RequestObjects;
using ApiSep.Exchange.ApiClasses.ResponseObjects;
using ApiSep.Library.BaseClasses;
using ApiSep.Library.Enums;
using ApiSep.Library.Extensions;
using ApiSep.Library.Handlers;
using ApiSep.Library.Interfaces;
using Microsoft.Exchange.WebServices.Data;
using Task = Microsoft.Exchange.WebServices.Data.Task;

namespace ApiSep.Exchange
{
    public class ExchangeSubmitter : ApiBase, IMailClient<SendEwsEmailRequest, SendEwsEmailResponse, GetEwsAppointmentsBetweenTwoDatesRequest, GetEwsAppointmentsBetweenTwoDatesResponse, GetEwsAppointmentsForADayRequest, GetEwsAppointmentsForADayResponse, CreateEwsAppointmentRequest, CreateEwsAppointmentResponse>
    {
        private ExchangeService ExchangeService { get; set; }
        public string LoginName { get; set; }
        public string Password { get; set; }
        public string Domain { get; set; }
        public string ExchangeServiceUrl { get; set; }

        public string Subject { get; set; }
        public string Body { get; set; }
        public List<string> ToRecipients { get; set; }
        public List<string> CcRecipients { get; set; }
        public List<string> BccRecipients { get; set; }
        public bool HasAttachment { get; set; }
        public List<string> Attachments { get; set; }
        public string FileName { get; set; }
        public bool ShouldSend { get; set; }
        public bool SendReadReceipt { get; set; }

        public ExchangeService CreateExchangeService()
        {
            var service =
                new ExchangeService(ExchangeVersion.Exchange2010_SP2)
                {
                    Url = new Uri(ExchangeServiceUrl),
                    Credentials = Domain.NotNullOrWhitespace()
                        ? new WebCredentials(LoginName, Password, Domain)
                        : new WebCredentials(LoginName, Password)
                };
            //accept all certificates
            System.Net.ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };
            return service;

            //if the host is unknown
            //var service = new ExchangeService(ExchangeVersion.Exchange2010_SP2);
            //service.AutodiscoverUrl(LoginName);
            //service.Credentials = !string.IsNullOrWhiteSpace(Domain)
            //    ? new WebCredentials(LoginName, Password, Domain)
            //    : new WebCredentials(LoginName, Password);
            //return service;
        }

        public CreateEwsAppointmentResponse CreateAppointment(CreateEwsAppointmentRequest request)
        {
            var response = new CreateEwsAppointmentResponse
            {
                IsSuccess = false
            };

            try
            {
                LoginName = request.LoginName;
                Password = request.Password;
                Domain = request.Domain;
                ExchangeServiceUrl = request.ExchangeServiceUrl;
                ExchangeService = CreateExchangeService();

                Subject = request.Subject;
                Body = request.Body;
                

                //Set the ImpersonatedUserId property of the ExchangeService object to identify the impersonated user (target account).  
                //This example uses the us
                //er's SMTP email address. 
                //ExchangeService.ImpersonatedUserId = new ImpersonatedUserId(ConnectingIdType.SmtpAddress, mailBox);
                //create a new appointment object 
                Appointment appointment = new Appointment(ExchangeService);
                //set appointment properties 
                appointment.Subject = request.Subject;
                appointment.Body = request.Body;
                //In MSDN it says that if you dont specify the timezone, it will use the UTC timezone 
                //but in reality it is not working that way. 
                //so explicity setting the EST timezone 
                appointment.StartTimeZone = TimeZoneInfo.FindSystemTimeZoneById("South Africa Standard Time");
                appointment.Start = request.StartTimeUtc.ToLocalTime();
                appointment.EndTimeZone = TimeZoneInfo.FindSystemTimeZoneById("South Africa Standard Time");
                appointment.End = request.EndTimeUtc.ToLocalTime();
                appointment.Location = request.Location;
                appointment.ReminderDueBy = request.Reminder;
                //add required participants 
                appointment.RequiredAttendees.Add(request.Recipients);
                //send meeting request to all participants and save a copy in user's sentitems 
                appointment.Save(SendInvitationsMode.SendToAllAndSaveCopy);
                //Set it back to null so that any actions that will be taken using the exchange service 
                //applies to impersonating account (i.e.account used in network credentials) 
                ExchangeService.ImpersonatedUserId = null;
                //return the unique identifier that is created
                response.UniqueId = appointment.Id.UniqueId;
                response.IsSuccess = true;
                return response;
            }
            catch (Exception ex)
            {
                ErrorHandler.LogException(ex);
                response.IsSuccess = false;
                response.LocalErrorCode = (int)ErrorsEnum.ExceptionEncountered;
                response.FriendlyErrorMessage = ErrorsEnum.ExceptionEncountered.FriendlyErrorMessage();
                
                return response;
            }
        }

        public SendEwsEmailResponse SendEmail(SendEwsEmailRequest request)
        {
            LoginName = request.LoginName;
            Password = request.Password;
            Domain = request.Domain;
            ExchangeServiceUrl = request.ExchangeServiceUrl;
            ExchangeService = CreateExchangeService();

            var response = new SendEwsEmailResponse
            {
                IsSuccess = true,
                BccRecipients = request.BccRecipients,
                Body = request.Body,
                CcRecipients = request.CcRecipients,
                Attachments = request.Attachments,
                Subject = request.Subject,
                ToRecipients = request.ToRecipients,
                ShouldSend = request.ShouldSend
            };
            try
            {
                LoginName = request.LoginName;
                Password = request.Password;
                Domain = request.Domain;
                ExchangeServiceUrl = request.ExchangeServiceUrl;
                ExchangeService = CreateExchangeService();

                var message = new EmailMessage(ExchangeService)
                {
                    Subject = request.Subject,
                    Body = request.Body,
                };

                request.ToRecipients.ForEach(p => message.ToRecipients.Add(p));
                request.BccRecipients.ForEach(p => message.BccRecipients.Add(p));
                request.CcRecipients.ForEach(p => message.CcRecipients.Add(p));

                //-->[read receipts]
                if (request.SendReadReceipt)
                {
                    message.IsReadReceiptRequested = true;
                }

                if (request.HasAttachment)
                {
                    foreach (var attachment in request.Attachments)
                    {
                        //todo:addFilenames
                        message.Attachments.AddFileAttachment(attachment);
                    }
                }

                if (request.ShouldSend)
                {
                    message.Save();
                    message.SendAndSaveCopy();
                }
                else
                {
                    message.Save(WellKnownFolderName.Drafts);
                }

                return response;
            }
            catch (Exception ex)
            {
                ErrorHandler.LogException(ex);
                response.IsSuccess = false;
                response.LocalErrorCode = (int)ErrorsEnum.ExceptionEncountered;
                response.FriendlyErrorMessage = ErrorsEnum.ExceptionEncountered.FriendlyErrorMessage();
                return response;
            }
            
        }

        public GetEwsAppointmentsBetweenTwoDatesResponse GetAppointmentsForPeriod(GetEwsAppointmentsBetweenTwoDatesRequest request)
        {
            var response = new GetEwsAppointmentsBetweenTwoDatesResponse { IsSuccess = false };
            try
            {
                LoginName = request.LoginName;
                Password = request.Password;
                Domain = request.Domain;
                ExchangeServiceUrl = request.ExchangeServiceUrl;
                ExchangeService = CreateExchangeService();

                var startDate = new DateTime(request.StartDate.Year, request.StartDate.Month, request.StartDate.Day, 0, 0, 0);
                var endDate = new DateTime(request.EndDate.Year, request.EndDate.Month, request.EndDate.Day, 23, 59, 59);

                var calendar = CalendarFolder.Bind(ExchangeService, WellKnownFolderName.Calendar, new PropertySet());

                response.AppointmentList = calendar.FindAppointments(new CalendarView(startDate, endDate)
                {
                    PropertySet = new PropertySet(ItemSchema.Subject)
                }).ToList();
                response.IsSuccess = true;
                return response;
            }
            catch (Exception ex)
            {
                ErrorHandler.LogException(ex);
                response.IsSuccess = false;
                response.LocalErrorCode = (int)ErrorsEnum.ExceptionEncountered;
                response.FriendlyErrorMessage = ErrorsEnum.ExceptionEncountered.FriendlyErrorMessage();
                return response;
            }
        }


        public GetEwsAppointmentsForADayResponse GetAppointmentsForADay(GetEwsAppointmentsForADayRequest request)
        {
            var response = new GetEwsAppointmentsForADayResponse{IsSuccess = false};
            try
            {
                LoginName = request.LoginName;
                Password = request.Password;
                Domain = request.Domain;
                ExchangeServiceUrl = request.ExchangeServiceUrl;
                ExchangeService = CreateExchangeService();

                var date = request.Day;
                // Initialize values for the start and end times, and the number of appointments to retrieve.
                DateTime startDate = new DateTime(date.Year, date.Month, date.Day, 0, 0, 0);
                DateTime endDate = new DateTime(date.Year, date.Month, date.Day, 23, 59, 59);
                const int numAppts = 5;

                // Initialize the calendar folder object with only the folder ID. 
                CalendarFolder calendar = CalendarFolder.Bind(ExchangeService, WellKnownFolderName.Calendar, new PropertySet());

                // Set the start and end time and number of appointments to retrieve.
                CalendarView cView = new CalendarView(startDate, endDate, numAppts)
                {
                    PropertySet = new PropertySet(ItemSchema.Subject)
                };

                // Limit the properties returned to the appointment's subject, start time, and end time.

                // Retrieve a collection of appointments by using the calendar view.
                FindItemsResults<Appointment> appointments = calendar.FindAppointments(cView);

                var appointmentStrings = new List<string>();

                //todo: return collection of object
                foreach (Appointment a in appointments)
                {
                    appointmentStrings.Add($@"Subject: {a.Subject} Start: {a.Start} End: {a.End}");
                }

                response.IsSuccess = true;
                response.AppointmentList = appointmentStrings;
                return response;
            }
            catch (Exception ex)
            {
                ErrorHandler.LogException(ex);
                response.IsSuccess = false;
                response.LocalErrorCode = (int)ErrorsEnum.ExceptionEncountered;
                response.FriendlyErrorMessage = ErrorsEnum.ExceptionEncountered.FriendlyErrorMessage();
                return response;
            }
        }

        private static bool RedirectionUrlValidationCallback(string redirectionUrl)
        {
            // The default for the validation callback is to reject the URL.
            bool result = false;

            Uri redirectionUri = new Uri(redirectionUrl);

            // Validate the contents of the redirection URL. In this simple validation
            // callback, the redirection URL is considered valid if it is using HTTPS
            // to encrypt the authentication credentials. 
            if (redirectionUri.Scheme == "https")
            {
                result = true;
            }
            return result;
        }

        //private static bool ValidateRemoteCertificate(object sender, X509Certificate cert, X509Chain chain,
        //    SslPolicyErrors errors)
        //{
        //    bool result = false;
        //    if(cert.Subject.ToUpper().Contains())
        //}

        #region Tasks

        /*public Task GetAllTasks()
        {
            var tasks = ExchangeService.
        }
        */

        public bool CreateTask()
        {
            try
            {
                var task = new Task(ExchangeService)
                {
                    Subject = "Test",
                    Body = new MessageBody("Body text"),
                    StartDate = DateTime.Today,
                    DueDate = DateTime.Today.AddDays(3),
                    IsReminderSet = true,
                    ReminderDueBy = DateTime.Today.AddDays(2),
                    Recurrence = new Recurrence.WeeklyPattern
                    {
                        Interval = 1,
                        NumberOfOccurrences = 1
                    },

                };

                task.Save(WellKnownFolderName.Tasks);
                return true;
            }
            catch (ServiceRequestException ex)
            {
                return false;
            }
            catch (WebException ex)
            {
                return false;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool UpdateTask()
        {
            try
            {
                //todo: this is probably not right
                var task = new Task(ExchangeService)
                {
                    Subject = "Test",
                    Body = new MessageBody("Body text"),
                    StartDate = DateTime.Today,
                    DueDate = DateTime.Today.AddDays(3),
                    IsReminderSet = true,
                    ReminderDueBy = DateTime.Today.AddDays(2),
                    Recurrence = new Recurrence.WeeklyPattern
                    {
                        Interval = 1,
                        NumberOfOccurrences = 1
                    },

                };

                task.Update(ConflictResolutionMode.AutoResolve);
                return true;
            }
            catch (ServiceRequestException ex)
            {
                return false;
            }
            catch (WebException ex)
            {
                return false;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        #endregion

        public ExchangeSubmitter(string virtualDirectory) : base(virtualDirectory)
        {
        }
    }
}
