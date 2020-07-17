using Microsoft.EntityFrameworkCore;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
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

        [Test]
        public void ShouldGetAllProducts()
        {
            // Arrange
            var data = new List<Product>
            {
                new Product()
                {
                    Id = 1,
                    Name = "Rubiks Cube 3X3",
                    Company = "Hasbro Gaming.",
                    Description = "The Rubik's 3X3 Cube has many combinations, but only one solution.",
                    AgeRestriction = 12,
                    Price = 149
                },
                new Product()
                {
                    Id = 2,
                    Name = "Jenga",
                    Company = "Hasbro Gaming.",
                    Description = "Take the challenge and pull all the blocks from the tower",
                    AgeRestriction = 6,
                    Price = 269
                },
                new Product()
                {
                    Id = 3,
                    Name = "Ghost of Tsushima",
                    Company = "Sucker Punch Productions",
                    Description = "Action-adventure stealth game played from a third-person perspective.",
                    AgeRestriction = 15,
                    Price = 1599
                }
            }.AsQueryable();

            var mockProductSet = new Mock<DbSet<Product>>();
            mockProductSet.As<IQueryable<Product>>().Setup(m => m.Provider).Returns(data.Provider);
            mockProductSet.As<IQueryable<Product>>().Setup(m => m.Expression).Returns(data.Expression);
            mockProductSet.As<IQueryable<Product>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockProductSet.As<IQueryable<Product>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            var mockContext = new Mock<ToysAndGamesContext>();
            mockContext.Setup(c => c.Products).Returns(mockProductSet.Object);

            var productRepository = new ProductRepository(mockContext.Object);

            // Act

            var products = productRepository.GetProducts().ToArray();

            //Assert
            Assert.AreEqual(3, products.Count());
            Assert.AreEqual("Rubiks Cube 3X3", products[0].Name);
            Assert.AreEqual("Jenga", products[1].Name);
            Assert.AreEqual("Ghost of Tsushima", products[2].Name);
        }
    }
}
