//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace LapTrinhWeb.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Product
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Product()
        {
            this.Orderdetails = new HashSet<Orderdetail>();
        }
    
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public Nullable<decimal> Price { get; set; }
        public Nullable<int> Quantity { get; set; }
        public string Detail { get; set; }
        public string Img { get; set; }
        public Nullable<int> BrandId { get; set; }
        public Nullable<int> TypeId { get; set; }
    
        public virtual Brand Brand { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Orderdetail> Orderdetails { get; set; }
        public virtual TypeP TypeP { get; set; }
    }
}
