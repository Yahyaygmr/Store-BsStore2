using Entities.Models;
using Entities.RequestParameters;
using Microsoft.EntityFrameworkCore;
using Repositories.Contracts;
using Repositories.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public sealed class ProductRepository : RepositoryBase<Product>, IProductRepository
    {
        public ProductRepository(RepositoryContext context) : base(context)
        {
        }

        public void CreateProduct(Product product)
        {
            Create(product);
        }

        public void DeleteOneProduct(Product product)
        {
            Delete(product);
        }

        public IQueryable<Product> GetAllProducts(bool trackChanges)
        {
            return FindAll(trackChanges);
        }

        public IQueryable<Product> GetAllProductsWithDetails(ProductRepuestParameters p)
        {
            return _context.Products.FilteredByCategoryId(p.CategoryId)
                .FilteredBySearchTerm(p.SearchTerm)
                .FilteredByPrice(p.MinPrice, p.MaxPrice, p.IsValidPrice);
        }

        public Product? GetOneProduct(int id, bool trackChanges)
        {
            return FindByCondition(x => x.ProductId.Equals(id), trackChanges);
        }

        public IQueryable<Product> GetShowCaseProducts(bool trackChanges)
        {
            return FindAll(trackChanges)
                .Where(p => p.ShowCase == true);
        }

        public void UpdateOneProduct(Product product)
        {
            Update(product);
        }
    }
}
