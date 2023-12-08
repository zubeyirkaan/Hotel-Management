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
    
    public partial class TblGuest
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TblGuest()
        {
            this.TblReservation = new HashSet<TblReservation>();
        }
    
        public int GuestID { get; set; }
        public string NameSurname { get; set; }
        public string TC { get; set; }
        public string Mail { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string Statement { get; set; }
        public string IDPhoto1 { get; set; }
        public string IDPhoto2 { get; set; }
        public Nullable<int> Country { get; set; }
        public Nullable<int> Status { get; set; }
        public Nullable<int> sehir { get; set; }
        public Nullable<int> ilce { get; set; }
    
        public virtual TblStatu TblStatu { get; set; }
        public virtual ilceler ilceler { get; set; }
        public virtual iller iller { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TblReservation> TblReservation { get; set; }
    }
}
