﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace HotelManagementAutomation.Entitiy
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class DbHotelEntities : DbContext
    {
        public DbHotelEntities()
            : base("name=DbHotelEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<TblCashRegister> TblCashRegisters { get; set; }
        public virtual DbSet<TblCountry> TblCountries { get; set; }
        public virtual DbSet<TblDepartment> TblDepartments { get; set; }
        public virtual DbSet<TblExchangeRate> TblExchangeRates { get; set; }
        public virtual DbSet<TblGuest> TblGuests { get; set; }
        public virtual DbSet<TblMission> TblMissions { get; set; }
        public virtual DbSet<TblPhone> TblPhones { get; set; }
        public virtual DbSet<TblProduct> TblProducts { get; set; }
        public virtual DbSet<TblProductGroup> TblProductGroups { get; set; }
        public virtual DbSet<TblRoom> TblRooms { get; set; }
        public virtual DbSet<TblStaff> TblStaffs { get; set; }
        public virtual DbSet<TblStatu> TblStatus { get; set; }
        public virtual DbSet<TblStockUnit> TblStockUnits { get; set; }
        public virtual DbSet<ilceler> ilceler { get; set; }
        public virtual DbSet<iller> iller { get; set; }
        public virtual DbSet<TblProductProcess> TblProductProcess { get; set; }
        public virtual DbSet<TblReservation> TblReservation { get; set; }
        public virtual DbSet<TblNewRegistry> TblNewRegistry { get; set; }
        public virtual DbSet<TblPreReservation> TblPreReservation { get; set; }
        public virtual DbSet<TblMessage2> TblMessage2 { get; set; }
        public virtual DbSet<TblAbout> TblAbout { get; set; }
        public virtual DbSet<TblContact> TblContact { get; set; }
        public virtual DbSet<TblMessage> TblMessage { get; set; }
    }
}
