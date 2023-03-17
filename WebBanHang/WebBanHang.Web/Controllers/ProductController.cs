using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebBanHang.Common;
using WebBanHang.Data.DomainModels;
using WebBanHang.Data.ViewModels;
using WebBanHang.Service;

namespace WebBanHang.Web.Controllers
{
    public class ProductController : Controller
    {

        private readonly IProductService productService;
        private readonly ICategoryService categoryService;

        public ProductController(IProductService productService, ICategoryService categoryService)
        {
            this.productService = productService;
            this.categoryService = categoryService;
        }

        // GET: Product
        public ActionResult SearchProduct(string productName)
        {
            return View();
        }

        public ActionResult ProductDetail(string metatitle)
        {
            var product = productService.GetByMetaTitle(metatitle);
            Category category = categoryService.GetById(Convert.ToInt32(product.CategoryId));
            ViewBag.CategoryName = category.CategoryName;
            ViewBag.MetaTitle = category.MetaTitle;
            ViewBag.Categories = categoryService.GetAll();
            var cart = Session[UserSession.yourCart];
            var list = new List<CartViewModel>();
            if (cart != null)
            {
                list = (List<CartViewModel>)cart;
                ViewBag.CountItem = list.Count;
            }
            else
            {
                ViewBag.CountItem = 0;
            }
            return View(product);
        }
    }
}