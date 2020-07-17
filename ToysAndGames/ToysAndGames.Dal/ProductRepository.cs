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

            if (product == null)
            {
                Console.WriteLine($"Failed attempt to delete product with id: {productId}");
            }
            else
            {
                _context.Products.Remove(product);
            }
        }

        public bool UpdateProduct(Product product)
        {
            bool canUpdate = false;

            if (!_context.Products.Any(prod => prod.Id == product.Id))
            {
                Console.WriteLine($"Product with Id: {product.Id} does not exist");
            }
            else
            {
                _context.Entry(product).State = EntityState.Modified;
                canUpdate = true;
            }

            

            return canUpdate;
        }

        public bool Save()
        {
            bool couldSave = false;

            try
            {
                _context.SaveChanges();
                couldSave = true;
            }
            catch (Exception ex)
            {
                // Log error on any available mechanism, in this case we use only console
                Console.WriteLine($"Error trying to save changes on DB", ex);
            }

            return couldSave;
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
