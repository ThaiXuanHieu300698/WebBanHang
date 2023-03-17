using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebBanHang.Web.Areas.Admin.Controllers
{
    [RouteArea("Admin")]
    [RoutePrefix("quan-tri")]
    [Route("action = Index")]
    public class HomeController : Controller
    {
        // GET: Admin/Home
        [Route("trang-chu")]
        public ActionResult Index()
        {
            if(Session["UserId"] == null || Session["UserId"].ToString() == null)
            {
                return Redirect("/Account/Index");
            }
            else if(Session["UserId"].ToString() == "1")
            {
                return View();
            }
            else
            {
                return Redirect("/Home/Index");
            }
        }
    }
}