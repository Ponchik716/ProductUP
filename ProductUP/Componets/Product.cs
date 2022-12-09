//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ProductUP.Componets
{
    using System;
    using System.Collections.Generic;
    
    public partial class Product
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Product()
        {
            this.ProductCountry = new HashSet<ProductCountry>();
            this.ProductOrder = new HashSet<ProductOrder>();
            this.ProductSupplier = new HashSet<ProductSupplier>();
            this.PostProd = new HashSet<PostProd>();
        }
    
        public int Id { get; set; }
        public string Name { get; set; }
        public string Discription { get; set; }
        public byte[] Photo { get; set; }
        public Nullable<System.DateTime> DateAdd { get; set; }
        public Nullable<int> UnitId { get; set; }
        public Nullable<int> Count { get; set; }
        public Nullable<decimal> Cost { get; set; }
    
        public virtual Unit Unit { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ProductCountry> ProductCountry { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ProductOrder> ProductOrder { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ProductSupplier> ProductSupplier { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PostProd> PostProd { get; set; }
    }
}