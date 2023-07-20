using ShopApp.Data.Abstract;
using ShopApp.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace ShopApp.Data.Concrete.EfCore
{
    public class EfCoreCategoryRepository : EfCoreGenericRepository<Category>, ICategoryRepository
    {
        public EfCoreCategoryRepository(ShopContext context) : base(context)
        {

        }
        private ShopContext ShopContext
        {
            get { return context as ShopContext; }
        }
        public void DeleteFromCategory(int productId, int categoryId)
        {
            var cmd = $"Delete from ProductCategory where ProductId=@p0 and CategoryId=@p1";
            ShopContext.Database.ExecuteSqlRaw(cmd, productId, categoryId);
        }

        public Category GetByIdWithProducts(int CategororyId)
        {
            return ShopContext.Categories.Where(i => i.CategoryId == CategororyId).Include(i => i.ProductCategories).ThenInclude(i => i.Product).FirstOrDefault();
        }

      
    }
}
