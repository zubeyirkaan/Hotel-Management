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
    
    public partial class TblProductGroup
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TblProductGroup()
        {
            this.TblProduct1 = new HashSet<TblProduct>();
        }
    
        public int ProductGroupID { get; set; }
        public string ProductGroupName { get; set; }
        public Nullable<int> Status { get; set; }
    
        public virtual TblStatu TblStatu { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TblProduct> TblProduct1 { get; set; }
    }
}
