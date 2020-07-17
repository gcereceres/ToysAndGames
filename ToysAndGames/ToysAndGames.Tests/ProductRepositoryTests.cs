using Microsoft.EntityFrameworkCore;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using ToysAndGames.Dal;
using ToysAndGames.Dal.Models;

namespace ToysAndGames.Tests
{
    public class ProductRepositoryTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void ShouldAddProduct()
        {
            // Arrange
            var mockProductSet = new Mock<DbSet<Product>>();

            var mockContext = new Mock<ToysAndGamesContext>();
            mockContext.Setup(c => c.Products).Returns(mockProductSet.Object);

            var productRepository = new ProductRepository(mockContext.Object);

            var product = new Product()
            {
                Id = 1,
                Name = "Rubiks Cube 3X3",
                Company = "Hasbro Gaming.",
                Description = "The Rubik's 3X3 Cube has many combinations, but only one solution.",
                AgeRestriction = 12,
                Price = 149
            };

            // Act

            productRepository.CreateProduct(product);
            productRepository.Save();

            //Assert
            mockProductSet.Verify(m => m.Add(It.IsAny<Product>()), Times.Once());
            mockContext.Verify(m => m.SaveChanges(), Times.Once());
        }
    }
}
