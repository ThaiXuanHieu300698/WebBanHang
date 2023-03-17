using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebBanHang.Data.DomainModels;
using WebBanHang.Data.Infrastructure;
using WebBanHang.Data.ViewModels;

namespace WebBanHang.Data.Repositoties
{
    public interface IProductRepository : IRepository<Product>
    {
        IEnumerable<ProductViewModel> GetList();
        IEnumerable<Product> GetByCategoryId(int categoryId);
        Product GetByMetaTitle(string metatitle);
    }

    public class ProductRepository : RepositoryBase<Product>, IProductRepository
    {
        public ProductRepository(IDatabaseFactory databaseFactory) : base(databaseFactory)
        {

        }

        public IEnumerable<Product> GetByCategoryId(int categoryId)
        {
            return Context.Products.Where(p => p.CategoryId == categoryId).ToList();
        }

        public Product GetByMetaTitle(string metatitle)
        {
            return Context.Products.Where(p => p.MetaTitle.Equals(metatitle)).FirstOrDefault();
        }

        public IEnumerable<ProductViewModel> GetList()
        {
            var query = from p in Context.Products
                        join c in Context.Categories
                        on p.CategoryId equals c.CategoryId
                        join s in Context.Suppliers
                        on p.SupplierId equals s.SupplierId
                        select new ProductViewModel()
                        {
                            ProductId = p.ProductId,
                            ProductName = p.ProductName,
                            ProductImage = p.ProductImage,
                            CategoryName = c.CategoryName,
                            SupplierName = s.SupplierName,
                            OldPrice = p.OldPrice
                        };
            return query.ToList();
        }
    }
}
