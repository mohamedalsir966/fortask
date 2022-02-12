using fortask.Cacheding;
using fortask.Domin;
using fortask.Domin.Repositories;
using fortask.Domin.Servises;
using fortask.Domin.Servises.Communication;
using fortask.respons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;


namespace fortask.Services
{
    public class CatogryServices : IcategoryServices
    {
        private readonly ICategoryRepositories _CategoryRepositories;
        private readonly IUnitOfWork _unitOfWork;
        private readonly CacheService _cacheService;

        public CatogryServices(ICategoryRepositories categoryRepositories,IUnitOfWork unit, CacheService cacheService)
        {
            _CategoryRepositories = categoryRepositories;
            _unitOfWork = unit;
            _cacheService = cacheService;

        }

        public Task<Category> FindByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task <IList<Category>> ListAsync()
        {
            return  await _CategoryRepositories.ListAsync();
            //var Respons= await _CategoryRepositories.ListAsync();
            //await _cacheService.PutCacheValue(CachedEntity.MedicalRecordId, "1", Respons);
            //return Respons;
        }

        public async Task<IList<Category>> FindByIdAsync()
        {
            return await _CategoryRepositories.ListAsync();
        }

        public async Task<Category> SaveAsync(Category category)
        {
             await _CategoryRepositories.AddAsync1(category);
             await _unitOfWork.CompleteAsync();
            return category;
        }

       

        public async Task<SaveCategoryResponse1> UpdateAsync(int id, Category category)
        {
            var existingCategory = await _CategoryRepositories.FindByIdAsync(id);
            if(existingCategory==null)
            {
                return new SaveCategoryResponse1("Category not found.");

            }
            existingCategory.Name = category.Name;
            try
            {
                _CategoryRepositories.UpdateAsyncalsir(existingCategory);
                await _unitOfWork.CompleteAsync();

                return new SaveCategoryResponse1(existingCategory);
            }
            catch (Exception ex)
            {
                // return Exception("not fround");
               // Do some logging stuff
                 return new SaveCategoryResponse1($"An error occurred when updating the category: {ex.Message}");
            }
   
        }
        private Category Exception(string v)
        {
            throw new NotImplementedException();
        }

        public async Task<SaveCategoryResponse1> DeleteAsync(int id)
        {
            var existingCategory = await _CategoryRepositories.FindByIdAsync(id);
            if (existingCategory == null)
            {
                return new SaveCategoryResponse1("Category not found.");
            }
            try
            {
                _CategoryRepositories.Remove(existingCategory);
                await _unitOfWork.CompleteAsync();

                return new SaveCategoryResponse1(existingCategory);
            }
            catch (Exception ex)
            {
                // return Exception("not fround");
                // Do some logging stuff
                return new SaveCategoryResponse1($"An error occurred when updating the category: {ex.Message}");
            }

        }
    }
    


}

