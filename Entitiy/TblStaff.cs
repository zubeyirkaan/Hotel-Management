//------------------------------------------------------------------------------
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
    using System.Collections.Generic;
    
    public partial class TblStaff
    {
        public int StaffID { get; set; }
        public string NameSurname { get; set; }
        public string TC { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Mail { get; set; }
        public Nullable<System.DateTime> StartDateOfWork { get; set; }
        public Nullable<System.DateTime> TerminationDate { get; set; }
        public Nullable<int> Department { get; set; }
        public Nullable<int> Mission { get; set; }
        public string Statement { get; set; }
        public Nullable<int> Status { get; set; }
        public string IDFront { get; set; }
        public string IDBack { get; set; }
        public string Password { get; set; }
    
        public virtual TblDepartment TblDepartment { get; set; }
        public virtual TblMission TblMission { get; set; }
        public virtual TblStatu TblStatu { get; set; }
    }
}
