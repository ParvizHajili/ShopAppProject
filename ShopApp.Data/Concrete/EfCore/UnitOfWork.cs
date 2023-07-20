using ShopApp.Data.Abstract;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ShopApp.Data.Concrete.EfCore
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ShopContext _context;
        public UnitOfWork(ShopContext context)
        {
            _context = context;
        }
        private EfCoreProductRepository _productRepository;
        private EfCoreCategoryRepository _categoryRepository;
        private EfCoreCartRepository _cartRepository;
        private EfCoreOrderRepository _orderRepository;


        public IProductRepository Products => _productRepository ?? new EfCoreProductRepository(_context);

        public ICategoryRepository Categories => _categoryRepository ?? new EfCoreCategoryRepository(_context);

        public ICartRepository Carts => _cartRepository ?? new EfCoreCartRepository(_context);

        public IOrderRepository Orders => _orderRepository ?? new EfCoreOrderRepository(_context);

        public void Dispose()
        {
            _context.Dispose();
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public async Task<int> SaveAsync()
        {
           return await _context.SaveChangesAsync();
        }
    }
}
