using Entities.Models;
using Repositories.Contracts;
using Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class CategoryManager : ICategoryService
    {
        private readonly IRepositoryManager _repositoryManager;

        public CategoryManager(IRepositoryManager repositoryManager)
        {
            _repositoryManager = repositoryManager;
        }

        public IEnumerable<Category> GetAllCategories(bool trackChanges)
        {
            return _repositoryManager.Category.FindAll(trackChanges);
        }

        public Category? GetOneCategory(int id, bool trackChanges)
        {
            var category = _repositoryManager.Category.FindByCondition(x => x.CategoryId.Equals(id), trackChanges);
            if (category is null)
            {
                throw new Exception("Category not found!");
            }
            return category;
        }
    }
}
