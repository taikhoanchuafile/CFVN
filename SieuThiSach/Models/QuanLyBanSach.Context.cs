﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SieuThiSach.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class QLBansachEntities : DbContext
    {
        public QLBansachEntities()
            : base("name=QLBansachEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<CHUDE> CHUDEs { get; set; }
        public virtual DbSet<CTDATHANG> CTDATHANGs { get; set; }
        public virtual DbSet<DONDATHANG> DONDATHANGs { get; set; }
        public virtual DbSet<KHACHHANG> KHACHHANGs { get; set; }
        public virtual DbSet<NHAXUATBAN> NHAXUATBANs { get; set; }
        public virtual DbSet<QUANGCAO> QUANGCAOs { get; set; }
        public virtual DbSet<QUANTRIADMIN> QUANTRIADMINs { get; set; }
        public virtual DbSet<SACH> SACHes { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<TACGIA> TACGIAs { get; set; }
        public virtual DbSet<THAMGIA> THAMGIAs { get; set; }
    }
}