using Microsoft.EntityFrameworkCore;
using ShopApp.Data.Abstract;
using ShopApp.Entity;
using System.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShopApp.Data.Concrete.EfCore
{
    public class EfCoreCartRepository : EfCoreGenericRepository<Cart>, ICartRepository
    {
        public EfCoreCartRepository(ShopContext context) : base(context)
        {

        }
        private ShopContext ShopContext
        {
            get { return context as ShopContext; }
        }
        public void ClearCart(int cartId)
        {

            var cmd = @"Delete from CartItems where CartId=@p0";
            ShopContext.Database.ExecuteSqlRaw(cmd, cartId, cartId);
            
        }

        public void DeleteFromCart(int cartId, int productId)
        {
            var cmd = @"Delete from CartItems where CartId=@p0 and ProductId=@p1";
            ShopContext.Database.ExecuteSqlRaw(cmd,cartId,productId);
        }

        public Cart GetByUserID(string UserId)
        {

            return ShopContext.Carts.Include(i => i.CartItems).ThenInclude(i => i.Product).FirstOrDefault(i => i.UserId == UserId);
        }

        public override void Update(Cart entity)
        {
            ShopContext.Carts.Update(entity);
        }
    }
}
