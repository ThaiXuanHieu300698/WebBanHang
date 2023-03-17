using System;
using System.Web.Mvc;
using WebBanHang.Common;
using WebBanHang.Service;

namespace WebBanHang.Web.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account

        private readonly IUserService userService;
        private readonly IUserRoleService userRoleService;

        public AccountController(IUserService userService, IUserRoleService userRoleService)
        {
            this.userService = userService;
            this.userRoleService = userRoleService;
        }

        [AllowAnonymous]
        public ActionResult Index()
        {
            var url = Request.UrlReferrer;
            if(url == null)
            {
                ViewBag.ReturnUrl = "/";
                return View();
            }
            ViewBag.ReturnUrl = Request.UrlReferrer.ToString();
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Login(UserLoginModel model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                var user = userService.GetUser(model.Username, PasswordHashMD5.MD5Hash(model.Password));
                if (user == null)
                {
                    ModelState.AddModelError("", "Tên đăng nhập hoặc mật khẩu không tồn tại");
                    return View("Index");
                }
                else
                {
                    var userRoles = userRoleService.GetByUserId(user.UserId);
                    foreach (var userRole in userRoles)
                    {
                        if (userRole.UserRoleId == 1)
                        {
                            if (userRole.RoleId == 1)
                            {
                                Session["FullName"] = user.FirstName + " " + user.LastName;
                                Session["UserId"] = user.UserId;
                                Session["RoleId"] = userRole.RoleId;
                                return Redirect("/Admin/quan-tri/trang-chu");
                            }
                            else
                            {
                                Session["FullName"] = user.FirstName + " " + user.LastName;
                                Session["UserId"] = user.UserId;
                                Session["RoleId"] = userRole.RoleId;
                                return Redirect("/");
                            }
                        }
                        else
                        {
                            Session["FullName"] = user.FirstName + " " + user.LastName;
                            Session["UserId"] = user.UserId;
                            Session["RoleId"] = userRole.RoleId;
                            return Redirect(returnUrl);
                        }
                    }
                }

            }
            return View("Index");
        }

        public ActionResult Logout()
        {
            Session.Clear();
            return Redirect("/");
        }

        public ActionResult Signup()
        {
            return View();
        }

        public ActionResult ForgotPassword()
        {
            return View();
        }
        
    }
}