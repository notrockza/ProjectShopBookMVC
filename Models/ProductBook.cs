//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Projent_NOTZA.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class ProductBook
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ProductBook()
        {
            this.OrderBook = new HashSet<OrderBook>();
        }
    
        public int Product_BookId { get; set; }
        public Nullable<int> Product_TypeId { get; set; }
        public Nullable<int> Product_PublisherId { get; set; }
        public string Product_Name { get; set; }
        public Nullable<int> Product_Price { get; set; }
        public Nullable<int> Product_Num { get; set; }
        public byte[] Product_Image { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OrderBook> OrderBook { get; set; }
        public virtual PublisherBook PublisherBook { get; set; }
        public virtual TypeBook TypeBook { get; set; }
    }
}