﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MyProject.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class DBJ_DBEntities : DbContext
    {
        public DBJ_DBEntities()
            : base("name=DBJ_DBEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<CauseTable> CauseTables { get; set; }
        public virtual DbSet<Medical_history> Medical_history { get; set; }
        public virtual DbSet<MuscleTable> MuscleTables { get; set; }
        public virtual DbSet<Profile> Profiles { get; set; }
        public virtual DbSet<SuggestTable> SuggestTables { get; set; }
    }
}
