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
    
    public partial class TblRoom
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TblRoom()
        {
            this.TblReservation = new HashSet<TblReservation>();
        }
    
        public int RoomID { get; set; }
        public string RoomNo { get; set; }
        public string Floor { get; set; }
        public string Capacity { get; set; }
        public string Statement { get; set; }
        public string Phone { get; set; }
        public Nullable<int> Status { get; set; }
    
        public virtual TblStatu TblStatu { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TblReservation> TblReservation { get; set; }
    }
}
