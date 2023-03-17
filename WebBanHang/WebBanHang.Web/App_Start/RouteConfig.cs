using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace WebBanHang.Web
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.MapMvcAttributeRoutes();
            AreaRegistration.RegisterAllAreas();
            routes.MapRoute(
                name: "Product",
                url: "san-pham/{metatitle}",
                defaults: new { controller = "Product", action = "ProductDetail", id = UrlParameter.Optional },
                namespaces: new string[] { "WebBanHang.Web.Controllers" }
            );

            routes.MapRoute(
                name: "Orders",
                url: "hoa-don",
                defaults: new { controller = "Orders", action = "Index", id = UrlParameter.Optional },
                namespaces: new string[] { "WebBanHang.Web.Controllers" }
            );

            routes.MapRoute(
                name: "Cart",
                url: "gio-hang",
                defaults: new { controller = "Cart", action = "Index", id = UrlParameter.Optional },
                namespaces: new string[] { "WebBanHang.Web.Controllers" }
            );

            routes.MapRoute(
                name: "Login",
                url: "dang-nhap",
                defaults: new { controller = "Account", action = "Index", id = UrlParameter.Optional },
                namespaces: new string[] { "WebBanHang.Web.Controllers" }
            );

            routes.MapRoute(
                name: "Logout",
                url: "dang-xuat",
                defaults: new { controller = "Account", action = "Logout", id = UrlParameter.Optional },
                namespaces: new string[] { "WebBanHang.Web.Controllers" }
            );

            routes.MapRoute(
                name: "Category",
                url: "danh-muc/{metatitle}",
                defaults: new { controller = "Home", action = "Category", id = UrlParameter.Optional },
                namespaces: new string[] { "WebBanHang.Web.Controllers" }
            );

            routes.MapRoute(
                name: "Home",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                namespaces: new string[] { "WebBanHang.Web.Controllers" }
            );
        }
    }
}
