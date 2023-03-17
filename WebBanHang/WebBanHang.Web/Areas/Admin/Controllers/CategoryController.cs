using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebBanHang.Data.DomainModels;
using WebBanHang.Service;

namespace WebBanHang.Web.Areas.Admin.Controllers
{
    [RouteArea("Admin")]
    [RoutePrefix("quan-tri")]
    public class CategoryController : Controller
    {
        private readonly ICategoryService categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            this.categoryService = categoryService;
        }
        // GET: Admin/Category
        [Route("danh-muc")]
        public ActionResult Index()
        {
            return View(categoryService.GetAll());
        }

        public ActionResult CreateHandle(Category model)
        {
            if(ModelState.IsValid)
            {
                try
                {
                    categoryService.Add(model);
                    return RedirectToAction("Index");
                }
                catch (Exception)
                {
                    ModelState.AddModelError("", "Thêm thất bại");
                }
            }
            else
            {
                ModelState.AddModelError("", "Thêm thất bại");
            }
            return View("Index");
        }

        public ActionResult EditHandle(Category model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    categoryService.Update(model);
                    return RedirectToAction("Index");
                }
                catch (Exception)
                {
                    ModelState.AddModelError("", "Cập nhật thất bại");
                }
            }
            else
            {
                ModelState.AddModelError("", "Cập nhật thất bại");
            }
            return View("Index");
        }

        public ActionResult Delete(int id)
        {
            try
            {
                categoryService.Delete(id);
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                ModelState.AddModelError("", "Xóa thất bại");
            }

            return View("Index");
        }

        public ActionResult Search(string searchString)
        {
            var result = categoryService.GetMany(searchString);
            if(result.Count() < 1)
            {
                TempData["NotFoundMessage"] = "Không có sản phẩm nào được tìm thấy!";
            }

            return View("Index", result);
        }
    }
}