using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ShopApp.Data.Abstract
{
    public interface IUnitOfWork : IDisposable
    {
        IProductRepository Products { get; }
        ICategoryRepository Categories { get; }
        ICartRepository Carts { get; }
        IOrderRepository Orders { get; }
        void Save();
        Task<int> SaveAsync();
    }
}
