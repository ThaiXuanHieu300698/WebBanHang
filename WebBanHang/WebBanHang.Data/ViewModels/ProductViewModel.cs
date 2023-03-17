using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebBanHang.Data.ViewModels
{
    public class ProductViewModel
    {
        public int ProductId { get; set; }

        [Display(Name = "Tên sản phẩm")]
        public string ProductName { get; set; }

        [StringLength(50)]
        [Display(Name = "Tên danh mục")]
        public string CategoryName { get; set; }

        [StringLength(50)]
        [Display(Name = "Nhà cung cấp")]
        public string SupplierName { get; set; }

        [Display(Name = "Hình ảnh")]
        public string ProductImage { get; set; }

        [Display(Name = "Đơn giá")]
        public string Unit { get; set; }

        public decimal? NewPrice { get; set; }
        
        public decimal? OldPrice { get; set; }
    }
}
