using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebBanHang.Data.DomainModels;

namespace WebBanHang.Data.ViewModels
{
    [Serializable]
    public class CartViewModel
    {
        public Product Product { get; set; }
        public int Quantity { get; set; }
    }
}
