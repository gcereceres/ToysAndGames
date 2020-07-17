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

            if(product == null)
            {
                Console.WriteLine($"Failed attempt to delete product with id: {productId}");
            } else
            {
                _context.Products.Remove(product);
            }
        }

        public bool UpdateProduct(Product product)
        {
            bool canUpdate = false;
            Product esistingProduct = _context.Products.FirstOrDefault(prod => prod.Id == product.Id);

            if (esistingProduct == null)
            {
                Console.WriteLine($"Product with Id: {product.Id} does not exist");
            }
            else
            {
                _context.Products.Remove(product);
                canUpdate = true;
            }

            _context.Entry(product).State = EntityState.Modified;

            return canUpdate;
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

    }
}
