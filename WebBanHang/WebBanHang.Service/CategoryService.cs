using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebBanHang.Data.DomainModels;
using WebBanHang.Data.Infrastructure;
using WebBanHang.Data.Repositoties;

namespace WebBanHang.Service
{
    public interface ICategoryService
    {
        void Add(Category category);
        void Update(Category category);
        void Delete(int id);
        IEnumerable<Category> GetAll();
        IEnumerable<Category> GetMany(string searchString);
        Category GetById(int id);
        Category GetByMetaTitle(string metatitle);
    }

    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository categoryRepository;
        private readonly IUnitOfWork unitOfWork;

        public CategoryService(ICategoryRepository categoryRepository, IUnitOfWork unitOfWork)
        {
            this.categoryRepository = categoryRepository;
            this.unitOfWork = unitOfWork;
        }

        public void Add(Category category)
        {
            categoryRepository.Add(category);
            unitOfWork.Commit();
        }

        public void Delete(int id)
        {
            var category = categoryRepository.GetById(id);
            categoryRepository.Delete(category);
            unitOfWork.Commit();
        }

        public IEnumerable<Category> GetAll()
        {
            return categoryRepository.GetAll();
        }

        public Category GetById(int id)
        {
            return categoryRepository.GetById(id);
        }

        public Category GetByMetaTitle(string metatitle)
        {
            return categoryRepository.GetByMetaTitle(metatitle);
        }

        public IEnumerable<Category> GetMany(string searchString)
        {
            return categoryRepository.GetMany(c => c.CategoryName.Contains(searchString));
        }

        public void Update(Category category)
        {
            Category categoryUpdated = categoryRepository.GetById(category.CategoryId);
            categoryUpdated.CategoryName = category.CategoryName;
            categoryUpdated.Description = category.Description;
            categoryRepository.Update(categoryUpdated);
            unitOfWork.Commit();
        }
    }
}
