using System;
using System.Data.Entity;
using ApiSep.Dal;

namespace ApiSep.DAL.Interfaces
{
    public interface IApiSepContext : IDisposable
    {
        DbSet<User> Users { get; set; }
        int SaveChanges();
        void MarkAsModified(User item);
    }
}
