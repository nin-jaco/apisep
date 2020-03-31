using System;
using System.Data.Entity;
using ApiSep.Dal.Entities;
using Audit.EntityFramework;

namespace ApiSep.DAL.Interfaces
{
    public interface IContext<T> : IDisposable where T : class
    {
        ApiSepEntities DbContext { get; set; }
        IDbSet<T> DbSet { get; set; }
    }
}
