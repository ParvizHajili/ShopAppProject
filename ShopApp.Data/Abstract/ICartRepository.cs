using ShopApp.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShopApp.Data.Abstract
{
   public interface ICartRepository:IRepository<Cart>
    {
       Cart GetByUserID(string UserId);
        void DeleteFromCart(int cartId, int productId);
        void ClearCart(int cartId);
    }
}
