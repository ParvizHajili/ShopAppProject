using ShopApp.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ShopApp.Business.Abstract
{
   public interface ICategoryService:IValidator<Category>
    {
        Task<Category> GetById(int id);
        Category GetByIdWithProducts(int categoryId);
        void DeleteFromCategory(int productId, int categoryId);
        Task<List<Category>> GetAll();
        void Create(Category entity);
        Task<Category> CreateAsync(Category entity);

        void Update(Category entity);
        void Delete(Category entity);

    }
}
