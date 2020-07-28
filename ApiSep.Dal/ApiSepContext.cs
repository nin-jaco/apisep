using ApiSep.DAL.Interfaces;
using System.Data.Entity;

namespace ApiSep.Dal
{

    public partial class ApiSepContext : DbContext, IApiSepContext
    {
        public ApiSepContext()
            : base("name=ApiSepContext")
        {
        }

        public virtual DbSet<User> Users { get; set; }
        public void MarkAsModified(User item)
        {
            Entry(item).State = EntityState.Modified;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .Property(e => e.Username)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Firstname)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Lastname)
                .IsUnicode(false);
        }

    }
}
