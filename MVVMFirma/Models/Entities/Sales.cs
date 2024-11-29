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
    
    public partial class Sales
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Sales()
        {
            this.Payment = new HashSet<Payment>();
            this.SalesItem = new HashSet<SalesItem>();
        }
    
        public int SalesId { get; set; }
        public Nullable<int> BuyerId { get; set; }
        public Nullable<decimal> TotalAmount { get; set; }
        public Nullable<decimal> Discount { get; set; }
        public Nullable<decimal> FinalAmount { get; set; }
        public Nullable<int> ShopId { get; set; }
    
        public virtual Buyer Buyer { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Payment> Payment { get; set; }
        public virtual Shop Shop { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SalesItem> SalesItem { get; set; }
    }
}
