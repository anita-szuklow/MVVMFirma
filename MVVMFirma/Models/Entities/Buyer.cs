//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MVVMFirma.Models.Entities
{
    using System;
    using System.Collections.Generic;
    
    public partial class Buyer
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Buyer()
        {
            this.Sales = new HashSet<Sales>();
        }
    
        public int BuyerId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public Nullable<decimal> TotalAmountSpent { get; set; }
        public Nullable<decimal> Discount { get; set; }
        public Nullable<int> AddedByEmployeeId { get; set; }
        public Nullable<int> UpdatedByEmployeeId { get; set; }
        public Nullable<System.DateTime> UpdateDate { get; set; }
    
        public virtual Employee Employee { get; set; }
        public virtual Employee Employee1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Sales> Sales { get; set; }
    }
}
