using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebBanHang.Data.DomainModels;
using WebBanHang.Data.Infrastructure;

namespace WebBanHang.Data.Repositoties
{
    public interface ICategoryRepository : IRepository<Category>
    {
        Category GetByMetaTitle(string metatitle);
    }

    public class CategoryRepository : RepositoryBase<Category>, ICategoryRepository
    {
        public CategoryRepository(IDatabaseFactory databaseFactory) : base(databaseFactory)
        {

        }

        public Category GetByMetaTitle(string metatitle)
        {
            return Context.Categories.Where(c => c.MetaTitle.Equals(metatitle)).FirstOrDefault();
        }
    }
}
