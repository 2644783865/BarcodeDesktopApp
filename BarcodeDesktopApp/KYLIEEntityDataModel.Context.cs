﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BarcodeDesktopApp
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class KYLIEEntities : DbContext
    {
        public KYLIEEntities()
            : base("name=KYLIEEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Assembly> Assemblies { get; set; }
        public virtual DbSet<Contract> Contracts { get; set; }
        public virtual DbSet<Dispatch> Dispatches { get; set; }
        public virtual DbSet<GalvDelivery> GalvDeliveries { get; set; }
        public virtual DbSet<SCAN_AssemblyScans> SCAN_AssemblyScans { get; set; }
        public virtual DbSet<SCAN_ScanType> SCAN_ScanType { get; set; }
    }
}
