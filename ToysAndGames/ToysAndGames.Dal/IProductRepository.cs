using System;
using System.Collections.Generic;
using System.Text;
using ToysAndGames.Dal.Models;

namespace ToysAndGames.Dal
{
    public interface IProductRepository
    {
        IEnumerable<Product> GetProducts();

        Product GetProductById(int productId);

        void CreateProduct(Product product);

        void DeleteProduct(int productId);

        void UpdateProduct(Product product);

        void Save();

    }
}
