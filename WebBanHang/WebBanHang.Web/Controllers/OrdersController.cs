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
    public class OrdersController : Controller
    {
        private readonly IProductService productService;
        private readonly ICategoryService categoryService;
        private readonly IOrdersService ordersService;
        private readonly IOrderDetailService orderDetailService;
        private readonly IUserService userService;

        public OrdersController(IProductService productService, ICategoryService categoryService, IOrdersService ordersService, IOrderDetailService orderDetailService, IUserService userService)
        {
            this.productService = productService;
            this.categoryService = categoryService;
            this.ordersService = ordersService;
            this.orderDetailService = orderDetailService;
            this.userService = userService;
        }
        // GET: Orders
        public ActionResult Index(string fullname, string phone, string address)
        {
            if (Session["UserId"] == null || Session["UserId"].ToString() == null)
            {
                return Redirect("/dang-nhap");
            }
            decimal Amount = 0;
            ViewBag.Categories = categoryService.GetAll();
            ViewBag.Products = productService.GetAll();
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

            Order order = new Order();
            order.UserId = Convert.ToInt32(Session["UserId"]);
            order.OrderDate = DateTime.Now;

            var id = ordersService.Insert(order);

            foreach(var item in list)
            {
                var orderDetail = new OrderDetail();
                orderDetail.OrderId = id;
                orderDetail.ProductId = item.Product.ProductId;
                orderDetail.Quantity = item.Quantity;

                Amount += Convert.ToDecimal(item.Quantity * item.Product.NewPrice);

                orderDetailService.Add(orderDetail);
            }
            ViewBag.Amount = Amount;
            ViewBag.OrderDetail = list;
            var userUpdate = userService.GetById(Convert.ToInt32(ordersService.GetById(id).UserId));
            userUpdate.PhoneNumber = phone;
            userUpdate.Address = address;
            userService.Update(userUpdate);
            var user = userService.GetById(Convert.ToInt32(ordersService.GetById(id).UserId));
            return View(user);
        }
    }
}