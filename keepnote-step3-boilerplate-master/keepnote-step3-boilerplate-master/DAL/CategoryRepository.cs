using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Entities;
using Microsoft.EntityFrameworkCore;

namespace DAL
{
    //Repository class is used to implement all Data access operations
    public class CategoryRepository : ICategoryRepository
    {
        private readonly KeepDbContext dbContext;
        public CategoryRepository(KeepDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        /*
	    * This method should be used to save a new category.
	    */
        public Category CreateCategory(Category category)
        {
            dbContext.Categories.Add(category);
            dbContext.SaveChanges();
            return category;

        }
        /* This method should be used to delete an existing category. */
        public bool DeleteCategory(int categoryId)
        {
            var p = dbContext.Categories.Where(x => x.CategoryId == categoryId).FirstOrDefault();
            dbContext.Categories.Remove(p);
            var y = dbContext.SaveChanges();
            return (y == 1);
        }
        //* This method should be used to get all category by userId.
        public List<Category> GetAllCategoriesByUserId(string userId)
        {
            return dbContext.Categories.Where(x => x.CategoryCreatedBy == userId).ToList();
        }

        /*
	     * This method should be used to get a category by categoryId.
	     */
        public Category GetCategoryById(int categoryId)
        {
            var p = dbContext.Categories.Where(x => x.CategoryId == categoryId).FirstOrDefault();
            return p;
        }

        /*
	    * This method should be used to update a existing category.
	    */
        public bool UpdateCategory(Category category)
        {
            var p = dbContext.Categories.Where(x => x.CategoryId == category.CategoryId).FirstOrDefault();
            if (p != null)
            {
                p.CategoryId = category.CategoryId;
                p.CategoryCreationDate = category.CategoryCreationDate;
                p.CategoryCreatedBy = category.CategoryCreatedBy;
                p.CategoryName = category.CategoryName;
                p.CategoryDescription = category.CategoryDescription;
                dbContext.Entry<Category>(p).State = EntityState.Modified;
                dbContext.SaveChanges();
                return true;
            }
            return false;

        }
    }
}
