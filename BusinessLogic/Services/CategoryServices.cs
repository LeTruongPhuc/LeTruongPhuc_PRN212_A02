using BusinessObjects.Models;
using DataAccess;
using DataAccess.Repositories;
using System.Collections.Generic;

namespace BusinessLogic.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _repository;

        public CategoryService()
        {
            _repository = RepositoryFactory.Instance.CreateCategoryRepository();
        }

        public IEnumerable<Category> GetAllCategories()
        {
            return _repository.GetAll();
        }

        public Category? GetCategoryById(int id)
        {
            return _repository.GetById(id);
        }

        public void AddCategory(Category category)
        {
            _repository.Add(category);
            _repository.SaveChanges();
        }

        public void UpdateCategory(Category category)
        {
            _repository.Update(category);
            _repository.SaveChanges();
        }

        public void DeleteCategory(int id)
        {
            _repository.Remove(id);
            _repository.SaveChanges();
        }
    }
}