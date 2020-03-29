using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApiSep.DAL.Interfaces;
using Audit.EntityFramework;

namespace ApiSep.DAL
{
    public class Context<T> : IContext<T> where T : class
    {
        public Context()
        {
            DbContext = new ApiSepEntities();
            DbSet = DbContext.Set<T>();
        }

        public Context(AuditDbContext db)
        {
            DbContext = db;
            DbSet = DbContext.Set<T>();
        }

        public AuditDbContext DbContext { get; set; }

        public IDbSet<T> DbSet { get; set; }

        public void Dispose()
        {
            DbContext.Dispose();
        }
    }
}
