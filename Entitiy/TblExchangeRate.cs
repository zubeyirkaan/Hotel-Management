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
    
    public partial class TblExchangeRate
    {
        public int RateID { get; set; }
        public string RateName { get; set; }
        public string Symbol { get; set; }
        public Nullable<decimal> Value { get; set; }
        public Nullable<System.DateTime> Date { get; set; }
        public Nullable<int> Status { get; set; }
    
        public virtual TblStatu TblStatu { get; set; }
    }
}
