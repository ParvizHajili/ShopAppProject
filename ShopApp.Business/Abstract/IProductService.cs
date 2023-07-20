using ShopApp.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ShopApp.Business.Abstract
{
   public interface IProductService:IValidator<Product>
    {
        Task<Product> GetByID(int id);
        Product GetByIdWithCategories(int id);
        Product GetProductDetails(string url);
        List<Product> GetHomePageProducts();
        List<Product> GetSearchResult(string searchString);
        List<Product> GetProductsByCategory(string name, int page, int pageSize);
        Task<List<Product>> GetAll();
        bool Create(Product entity);
        Task<Product> CreateAsync(Product entity);
        Task UpdateAsync(Product entityToUpdate,Product entity);
        bool Update(Product entity, int[] categoryIds);
        void Delete(Product entity);
        Task DeleteAsync(Product entity);
        int GetCountByCategory(string category);
    }
}
