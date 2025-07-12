using BusinessObjects.Models;
using DataAccess;
using DataAccess.Repositories;
using System.Collections.Generic;

namespace BusinessLogic.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _repository;

        public ProductService()
        {
            _repository = RepositoryFactory.Instance.CreateProductRepository();
        }

        public IEnumerable<Product> GetAllProducts()
        {
            return _repository.GetAll();
        }

        public Product? GetProductById(int id)
        {
            return _repository.GetById(id);
        }

        public IEnumerable<Product> GetProductsByCategory(int categoryId)
        {
            return _repository.GetProductsByCategory(categoryId);
        }

        public IEnumerable<Product> GetProductsInStock()
        {
            return _repository.GetProductsInStock();
        }

        public void AddProduct(Product product)
        {
            _repository.Add(product);
            _repository.SaveChanges();
        }

        public void UpdateProduct(Product product)
        {
            _repository.Update(product);
            _repository.SaveChanges();
        }

        public void DeleteProduct(int id)
        {
            _repository.Remove(id);
            _repository.SaveChanges();
        }
    }
}