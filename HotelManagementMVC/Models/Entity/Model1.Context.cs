﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace HotelManagementMVC.Models.Entity
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
    
        public virtual DbSet<TblAbout> TblAbouts { get; set; }
        public virtual DbSet<TblContact> TblContacts { get; set; }
        public virtual DbSet<TblMessage> TblMessages { get; set; }
        public virtual DbSet<TblNewRegistry> TblNewRegistries { get; set; }
        public virtual DbSet<TblGuest> TblGuests { get; set; }
        public virtual DbSet<TblReservation> TblReservations { get; set; }
        public virtual DbSet<TblMessage2> TblMessage2 { get; set; }
        public virtual DbSet<TblRoom> TblRooms { get; set; }
    }
}
