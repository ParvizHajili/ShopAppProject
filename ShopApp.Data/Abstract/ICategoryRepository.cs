using ShopApp.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShopApp.Data.Abstract
{
    public interface ICategoryRepository:IRepository<Category>
    {
        Category GetByIdWithProducts(int CategororyId);
        void DeleteFromCategory(int productId, int categoryId);

    }
}
