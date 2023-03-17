namespace WebBanHang.Data.DomainModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Product")]
    public partial class Product
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Product()
        {
            OrderDetails = new HashSet<OrderDetail>();
        }

        public int ProductId { get; set; }

        [StringLength(50)]
        [Display(Name ="Tên sản phẩm")]
        [Required(ErrorMessage ="Tên sản phẩm không được để trống")]
        public string ProductName { get; set; }
        [Display(Name = "Nhà cung cấp")]
        public int? SupplierId { get; set; }
        [Display(Name = "Danh mục")]
        public int? CategoryId { get; set; }

        public string MetaTitle { get; set; }

        [StringLength(100)]
        [Display(Name = "Hình ảnh")]
        public string ProductImage { get; set; }

        [StringLength(50)]
        public string Unit { get; set; }

        [Column(TypeName = "money")]
        [Display(Name ="Giá")]
        public decimal? NewPrice { get; set; }

        [Column(TypeName = "money")]
        [Display(Name = "Giá")]
        [Required(ErrorMessage = "Tên sản phẩm không được để trống")]
        public decimal? OldPrice { get; set; }

        public virtual Category Category { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }

        public virtual Supplier Supplier { get; set; }
    }
}
