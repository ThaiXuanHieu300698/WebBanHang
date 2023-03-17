using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebBanHang.Data.DomainModels;
using WebBanHang.Data.Infrastructure;
using WebBanHang.Data.Repositoties;
using WebBanHang.Data.ViewModels;

namespace WebBanHang.Service
{
    public interface IProductService
    {
        void Add(Product product);
        void Update(Product product);
        void Delete(int id);
        IEnumerable<ProductViewModel> GetList();
        Product GetById(int id);
        Product GetByMetaTitle(string metatitle);
        IEnumerable<Product> GetAll();
        IEnumerable<Product> GetByCategoryId(int categoryId);
        IEnumerable<Product> GetMany(string searchString);
    }

    public class ProductService : IProductService
    {
        private readonly IProductRepository productRepository;
        private readonly IUnitOfWork unitOfWork;

        public ProductService(IProductRepository productRepository, IUnitOfWork unitOfWork)
        {
            this.productRepository = productRepository;
            this.unitOfWork = unitOfWork;
        }

        public void Add(Product product)
        {
            productRepository.Add(product);
            unitOfWork.Commit();
        }

        public void Delete(int id)
        {
            var product = productRepository.GetById(id);
            productRepository.Delete(product);
            unitOfWork.Commit();
        }

        public IEnumerable<Product> GetAll()
        {
            return productRepository.GetAll();
        }

        public IEnumerable<Product> GetByCategoryId(int categoryId)
        {
            return productRepository.GetByCategoryId(categoryId);
        }

        public Product GetById(int id)
        {
            return productRepository.GetById(id);
        }

        public Product GetByMetaTitle(string metatitle)
        {
            return productRepository.GetByMetaTitle(metatitle);
        }

        public IEnumerable<ProductViewModel> GetList()
        {
            return productRepository.GetList();
        }

        public IEnumerable<Product> GetMany(string searchString)
        {
            return productRepository.GetMany(p => p.ProductName.Contains(searchString));
        }

        public void Update(Product product)
        {
            Product productUpdated = productRepository.GetById(product.ProductId);

            productUpdated.ProductName = product.ProductName;
            productUpdated.ProductImage = product.ProductImage;
            productUpdated.CategoryId = product.CategoryId;
            productUpdated.SupplierId = product.SupplierId;
            productUpdated.OldPrice = product.OldPrice;

            productRepository.Update(productUpdated);
            unitOfWork.Commit();
        }
    }
}
