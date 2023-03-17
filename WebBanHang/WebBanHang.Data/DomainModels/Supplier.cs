namespace WebBanHang.Data.DomainModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Supplier")]
    public partial class Supplier
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Supplier()
        {
            Products = new HashSet<Product>();
        }

        public int SupplierId { get; set; }

        [StringLength(50)]
        [Display(Name ="Nhà cung cấp")]
        [Required(ErrorMessage ="Nhà cung cấp không được để trống")]
        public string SupplierName { get; set; }

        [StringLength(10)]
        [Display(Name ="Số điện thoại")]
        [Required(ErrorMessage = "Số điện thoại không được để trống")]
        public string PhoneNumber { get; set; }

        [StringLength(50)]
        [Display(Name ="Email")]
        public string Email { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Product> Products { get; set; }
    }
}
