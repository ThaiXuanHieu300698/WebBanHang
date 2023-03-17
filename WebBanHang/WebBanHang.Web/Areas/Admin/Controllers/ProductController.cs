using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebBanHang.Data.DomainModels;
using WebBanHang.Data.ViewModels;
using WebBanHang.Service;

namespace WebBanHang.Web.Areas.Admin.Controllers
{
    [RouteArea("Admin")]
    [RoutePrefix("quan-tri")]
    public class ProductController : Controller
    {

        private readonly IProductService productService;
        private readonly ICategoryService categoryService;
        private readonly ISupplierService supplierService;

        public ProductController(IProductService productService, ICategoryService categoryService, ISupplierService supplierService)
        {
            this.productService = productService;
            this.categoryService = categoryService;
            this.supplierService = supplierService;
        }

        // GET: Admin/Product
        [Route("san-pham")]
        public ActionResult Index()
        {
            var dataTable = productService.GetList();
            return View(dataTable);
        }

        public void SetViewBag(int? categoryId = null, int? supplierId = null)
        {
            ViewBag.CategoryId = new SelectList(categoryService.GetAll(), "CategoryId", "CategoryName", categoryId);
            ViewBag.SupplierId = new SelectList(supplierService.GetAll(), "SupplierId", "SupplierName", supplierId);
        }

        [Route("tao-san-pham")]
        public ActionResult Create()
        {
            SetViewBag();
            return View();
        }

        [HttpPost]
        public ActionResult CreateHandle(Product model, HttpPostedFileBase file)
        {
            if (file == null)
            {
                ModelState.AddModelError("", "Thêm thất bại");
                return RedirectToAction("Create");
            }
            var fileName = Path.GetFileName(file.FileName);
            var path = Path.Combine(Server.MapPath("~/UploadImage"), fileName);
            model.ProductImage = fileName;
            file.SaveAs(path);

            if (ModelState.IsValid)
            {
                try
                {
                    productService.Add(model);
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
            SetViewBag(model.CategoryId, model.SupplierId);
            return View("Create");
        }

        [Route("sua-san-pham/{id}")]
        public ActionResult Edit(int id)
        {
            var product = productService.GetById(Convert.ToInt32(id));

            SetViewBag(product.CategoryId, product.SupplierId);
            return View(product);
        }


        public ActionResult EditHandle(Product model, HttpPostedFileBase file)
        {
            if (file == null)
            {
                var product = productService.GetById(model.ProductId);
                model.ProductImage = product.ProductImage;
            }
            else
            {
                var fileName = Path.GetFileName(file.FileName);
                var path = Path.Combine(Server.MapPath("~/UploadImage"), fileName);
                model.ProductImage = fileName;
                file.SaveAs(path);
            }

            if (ModelState.IsValid)
            {
                try
                {
                    productService.Update(model);
                    return RedirectToAction("Index");
                }
                catch (Exception)
                {

                    ModelState.AddModelError("", "Cập nhật không thành công");
                }
            }
            else
            {
                ModelState.AddModelError("", "Cập nhật không thành công");
            }
            SetViewBag(model.CategoryId, model.SupplierId);
            return View("Edit", model);
        }

        public ActionResult Delete(int id)
        {
            try
            {
                productService.Delete(id);
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                ModelState.AddModelError("", "Xóa thất bại");
            }
            return View("Index");
        }

        /// <summary>
        /// Search Product based on name and return
        /// </summary>
        /// <param name="searchString"></param>
        /// <returns></returns>
        public ActionResult Search(string searchString)
        {
            // This list store list of products found
            List<Product> searchResult = productService.GetMany(searchString).ToList();

            // this list return to View
            List<ProductViewModel> result = new List<ProductViewModel>();

            // Convert list product to list its ViewModel to show on View
            foreach (Product product in searchResult)
            {
                // Convert every single Product to ProductViewModel object
                ProductViewModel viewModel = new ProductViewModel();
                viewModel.ProductId = product.ProductId;
                viewModel.ProductName = product.ProductName;
                viewModel.CategoryName = categoryService.GetById((int)product.CategoryId).CategoryName;
                viewModel.SupplierName = supplierService.GetById((int)product.SupplierId).SupplierName;
                viewModel.OldPrice = product.OldPrice;
                viewModel.ProductImage = product.ProductImage;

                // Addinformation to return list
                result.Add(viewModel);
            }

            // In case cannot found any product, show message to inform to user 
            if (result.Count < 1)
            {
                TempData["NotFoundMessage"] = "Không có sản phẩm nào được tìm thấy!";
            }

            return View("Index", result);
        }
    }
}