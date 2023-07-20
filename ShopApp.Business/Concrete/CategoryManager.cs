using ShopApp.Business.Abstract;
using ShopApp.Data.Abstract;
using ShopApp.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ShopApp.Business.Concrete
{
    public class CategoryManager : ICategoryService
    {
        private readonly IUnitOfWork _unitOfWork;
        public CategoryManager(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void Create(Category entity)
        {
            _unitOfWork.Categories.Create(entity);
            _unitOfWork.Save();
        }

        public async Task<Category> CreateAsync(Category entity)
        {
            await _unitOfWork.Categories.CreateAsync(entity);
            await _unitOfWork.SaveAsync();

            return entity;
        }

        public void Delete(Category entity)
        {
            _unitOfWork.Categories.Delete(entity);
            _unitOfWork.Save();
        }

        public void DeleteFromCategory(int productId, int categoryId)
        {
            _unitOfWork.Categories.DeleteFromCategory(productId, categoryId);
        }

        public async Task<List<Category>> GetAll()
        {
            return await _unitOfWork.Categories.GetAll();
        }

        public async Task<Category> GetById(int id)
        {
            return await _unitOfWork.Categories.GetByID(id);
        }

        public Category GetByIdWithProducts(int categoryId)
        {
            return _unitOfWork.Categories.GetByIdWithProducts(categoryId);
        }

        public void Update(Category entity)
        {
            _unitOfWork.Categories.Update(entity);
            _unitOfWork.Save();
        }
        public string ErrorMessage { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public bool Validation(Category entity)
        {
            throw new NotImplementedException();
        }
    }
}
