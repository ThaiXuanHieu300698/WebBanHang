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
    public class CartController : Controller
    {
        private readonly IProductService productService;
        private readonly ICategoryService categoryService;

        //private const string yourCart = "YourCart";

        public CartController(IProductService productService, ICategoryService categoryService)
        {
            this.productService = productService;
            this.categoryService = categoryService;
        }
        // GET: Cart
        public ActionResult Index()
        {
            decimal Amount = 0;
            var cart = Session[UserSession.yourCart];
            var list = new List<CartViewModel>();
            if (cart != null)
            {
                list = (List<CartViewModel>)cart;
                foreach(var item in list)
                {
                    Amount += Convert.ToDecimal(item.Quantity * item.Product.NewPrice);
                }

                ViewBag.CountItem = list.Count;
                ViewBag.Amount = Amount;
                ViewBag.Categories = categoryService.GetAll();
                return View(list);
            }
            else
            {
                ViewBag.CountItem = list.Count;
                TempData["NotFoundMessage"] = "Không có sản phẩm nào trong giỏ hàng của bạn.";
                ViewBag.Categories = categoryService.GetAll();
                return View(list);
            }
        }

        public ActionResult AddToCart(int id)
        {
            var product = productService.GetById(id);
            var cart = Session[UserSession.yourCart];
            if (cart != null)
            {
                var list = (List<CartViewModel>)cart;
                if (list.Exists(p => p.Product.ProductId == id))
                {
                    foreach (var item in list.Where(x => x.Product.ProductId == id))
                    {
                        item.Quantity += 1;
                    }
                }
                else
                {
                    var item = new CartViewModel();
                    item.Product = product;
                    item.Quantity = 1;
                    list.Add(item);
                }
                Session[UserSession.yourCart] = list;
                
            }
            else
            {
                var item = new CartViewModel();
                item.Product = product;
                item.Quantity = 1;
                var list = new List<CartViewModel>();
                list.Add(item);
                Session[UserSession.yourCart] = list;
            }
            return RedirectToAction("Index");
        }

        public JsonResult UpdateCart(int id, int quantity)
        {
            decimal Amount = 0;
            var product = productService.GetById(id);
            var cart = Session[UserSession.yourCart];
            if (cart != null)
            {
                var list = (List<CartViewModel>)cart;
                if (list.Exists(p => p.Product.ProductId == id))
                {
                    foreach (var item in list.Where(x => x.Product.ProductId == id))
                    {
                        item.Quantity = quantity;
                    }
                }
                foreach (var item in list)
                {
                    Amount += Convert.ToDecimal(item.Quantity * item.Product.NewPrice);
                }
                
                ViewBag.Amount = Amount;

                Session[UserSession.yourCart] = list;

            }
            return Json(new { status = true });
        }

        public ActionResult DeleteItem(int id)
        {
            decimal Amount = 0;
            var cart = Session[UserSession.yourCart];
            var list = (List<CartViewModel>)cart;
            var product = productService.GetById(id);
            if(list.Exists(p => p.Product.ProductId == id))
            {
                var item = list.Where(p => p.Product.ProductId == id).FirstOrDefault();
                list.Remove(item);
                
                foreach (var i in list)
                {
                    Amount += Convert.ToDecimal(i.Quantity * i.Product.NewPrice);
                }

                ViewBag.CountItem = list.Count;
                ViewBag.Amount = Amount;
                ViewBag.Categories = categoryService.GetAll();

                if (list.Count == 0)
                {
                    TempData["NotFoundMessage"] = "Không có sản phẩm nào trong giỏ hàng của bạn.";
                    list = null;
                }

                Session[UserSession.yourCart] = list;
                return RedirectToAction("Index");
            }
            
            return View();
        }
    }
}