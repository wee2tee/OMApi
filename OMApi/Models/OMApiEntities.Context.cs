﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace OMApi.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class OMApiEntities : DbContext
    {
        public OMApiEntities()
            : base("name=OMApiEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Arship> Arship { get; set; }
        public virtual DbSet<Artrn> Artrn { get; set; }
        public virtual DbSet<AspNetRoles> AspNetRoles { get; set; }
        public virtual DbSet<AspNetUserClaims> AspNetUserClaims { get; set; }
        public virtual DbSet<AspNetUserLogins> AspNetUserLogins { get; set; }
        public virtual DbSet<AspNetUserRoles> AspNetUserRoles { get; set; }
        public virtual DbSet<AspNetUsers> AspNetUsers { get; set; }
        public virtual DbSet<Cart> Cart { get; set; }
        public virtual DbSet<Dlvprofile> Dlvprofile { get; set; }
        public virtual DbSet<InternalUsers> InternalUsers { get; set; }
        public virtual DbSet<Istab> Istab { get; set; }
        public virtual DbSet<Msg> Msg { get; set; }
        public virtual DbSet<Oeso> Oeso { get; set; }
        public virtual DbSet<Oesoit> Oesoit { get; set; }
        public virtual DbSet<Popr> Popr { get; set; }
        public virtual DbSet<Poprit> Poprit { get; set; }
        public virtual DbSet<Stcrd> Stcrd { get; set; }
        public virtual DbSet<Stmas> Stmas { get; set; }
        public virtual DbSet<Stpri> Stpri { get; set; }
    }
}
