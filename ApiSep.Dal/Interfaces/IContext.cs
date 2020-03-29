using System;
using System.Data.Entity;
using Audit.EntityFramework;

namespace ApiSep.DAL.Interfaces
{
    public interface IContext<T> : IDisposable where T : class
    {
        AuditDbContext DbContext { get; set; }
        IDbSet<T> DbSet { get; set; }
    }
}
