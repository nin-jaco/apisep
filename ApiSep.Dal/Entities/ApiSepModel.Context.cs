﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ApiSep.Dal.Entities
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class ApiSepEntities : DbContext
    {
        public ApiSepEntities()
            : base("name=ApiSepEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<AuditEvent> AuditEvents { get; set; }
        public virtual DbSet<CustomAuditEvent> CustomAuditEvents { get; set; }
        public virtual DbSet<EntityAuditEvent> EntityAuditEvents { get; set; }
        public virtual DbSet<User> Users { get; set; }
    }
}
