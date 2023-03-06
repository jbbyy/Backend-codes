using System;
using System.Collections.Generic;
using System.Text;
using DAL;
using Entities;
using Exceptions;

namespace Service
{
    /*
    * Service classes are used here to implement additional business logic/validation
    * */
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository categoryRepository;
        /*
        Use constructor Injection to inject all required dependencies.
            */

        public CategoryService(ICategoryRepository categoryRepository)
        {

            this.categoryRepository = categoryRepository;
        }

        /*
	    * This method should be used to save a new category.
	    */
        public Category CreateCategory(Category category)
        {
            return categoryRepository.CreateCategory(category);
        }

        /* This method should be used to delete an existing category. */
        public bool DeleteCategory(int categoryId)
        {
            var x = categoryRepository.DeleteCategory(categoryId);
            if (x == false)
            {
                throw new CategoryNotFoundException($"Category with id: {categoryId} does not exist");
            }
            return x;
        }

        /*
	     * This method should be used to get all category by userId.
	     */
        public List<Category> GetAllCategoriesByUserId(string userId)
        {
            return (categoryRepository.GetAllCategoriesByUserId(userId));
        }

        /*
	     * This method should be used to get a category by categoryId.
	     */
        public Category GetCategoryById(int categoryId)
        {
            var x= categoryRepository.GetCategoryById(categoryId);
            if (x == null)
            {
                throw new CategoryNotFoundException($"Category with id: {categoryId} does not exist");
            }
            return x;
        }

        /*
	    * This method should be used to update a existing category.
	    */
        public bool UpdateCategory(int categoryId, Category category)
        {
            var x = (categoryRepository.UpdateCategory(category));
            if (x == false)
            {
                throw new CategoryNotFoundException($"Category with id: {categoryId} does not exist");
            }
            return x;
        }
    }
}
