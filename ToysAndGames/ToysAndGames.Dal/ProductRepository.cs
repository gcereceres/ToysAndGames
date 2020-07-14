using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ToysAndGames.Dal.Models;

namespace ToysAndGames.Dal
{
    public class ProductRepository : IProductRepository
    {
        private ToysAndGamesContext _context;
        public ProductRepository(ToysAndGamesContext context)
        {
            _context = context;

        }

        public IEnumerable<Product> GetProducts()
        {
            return _context.Products.ToList();
        }

        public Product GetProductById(int productId)
        {
            return _context.Products.FirstOrDefault(product => product.Id == productId);
        }
        public void CreateProduct(Product product)
        {
            _context.Products.Add(product);
        }

        public void DeleteProduct(int productId)
        {
            Product product = _context.Products.FirstOrDefault(prod => prod.Id == productId);
            _context.Products.Remove(product);
        }

        public void UpdateProduct(Product product)
        {
            _context.Entry(product).State = EntityState.Modified;
        }

        public void Save()
        {
            _context.SaveChanges();
        }

    }
}
