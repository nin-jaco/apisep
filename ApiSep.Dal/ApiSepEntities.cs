using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApiSep.Dal.Entities;
using Audit.Core;
using Audit.EntityFramework;
using Newtonsoft.Json.Linq;
using AuditEvent = ApiSep.Dal.Entities.AuditEvent;

namespace ApiSep.DAL
{
    ///this has been hidden for simplicity but is the overload of the context class to build the audit message 
    /*public partial class ApiSepEntities : AuditDbContext
    {

        public override void OnScopeCreated(AuditScope auditScope)
        {
            Database.BeginTransaction();
        }

        public override void OnScopeSaving(AuditScope auditScope)
        {
            try
            {
                var auditJsonString = auditScope.Event.ToJson();
                dynamic data = JObject.Parse(auditJsonString);
                var auditEvent = new AuditEvent();
                auditEvent.Browser = data.Browser;
                auditEvent.IdDealer = data.IdDealer;
                auditEvent.IdChangedBy = data.IdChangedBy;
                auditEvent.Username = data.Username;
                auditEvent.BrowserVersion = data.BrowserVersion;
                auditEvent.CrudResult = data.EntityFrameworkEvent.Result;
                auditEvent.UserAgent = data.UserAgent;
                auditEvent.IpAddress = data.IpAddress;
                auditEvent.DealerName = data.DealerName;
                auditEvent.Environment = $@"Username: {data.Environment.UserName}, Machine Name: {data.Environment.MachineName}, DomainName: {data.Environment.DomainName}, CallingMethodName: {data.Environment.CallingMethodName}, AssemblyName: {data.Environment.AssemblyName}, Culture: {data.Environment.Culture}";
                auditEvent.Duration = data.Duration;
                auditEvent.EndDate = data.EndDate == null ? data.StartDate : data.EndDate;
                auditEvent.EventType = data.EventType;
                auditEvent.IsSuccess = data.EntityFrameworkEvent.Success;
                auditEvent.StartDate = data.StartDate;
                auditEvent.DatabaseName = data.EntityFrameworkEvent.Database;
                //todo: prepare for batch inserts
                auditEvent.CrudAction = data.EntityFrameworkEvent.Entries[0].Action;
                auditEvent.PrimaryKey = data.EntityFrameworkEvent.Entries[0].PrimaryKey.ID;
                auditEvent.IsValid = data.EntityFrameworkEvent.Entries[0].Valid;
                auditEvent.ValidationResults = data.EntityFrameworkEvent.Entries[0].ValidationResults.ToString();
                auditEvent.TableName = data.EntityFrameworkEvent.Entries[0].Table;
                auditEvent.ObjectAfterChanges = data.EntityFrameworkEvent.Entries[0].ColumnValues.ToString();
                auditEvent.EntityAuditEvents = new List<EntityAuditEvent>();
                //auditEvent.CustomAuditEvent = ,

                if (data.EntityFrameworkEvent.Entries[0].Changes != null)
                {
                    foreach (var change in data.EntityFrameworkEvent.Entries[0].Changes)
                    {
                        auditEvent.EntityAuditEvents.Add(new EntityAuditEvent
                        {
                            //Id = ,
                            ColumnName = change.ColumnName,
                            NewValue = change.NewValue,
                            OriginalValue = change.OriginalValue
                        });
                    }
                }

                if (DbContext.Database.CurrentTransaction != null)
                {
                    DbContext.Database.CurrentTransaction?.Commit();

                    DbContext.Set<AuditEvent>().Add(auditEvent);
                    this.DbContext.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                //ErrorHandler.LogException(ex);
            }
        }
    }*/
}
