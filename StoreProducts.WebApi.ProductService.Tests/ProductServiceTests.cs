using Microsoft.AspNetCore.Authentication.OAuth.Claims;
using Microsoft.AspNetCore.Mvc.Formatters.Xml;
using StoreProducts.WebAPI.DTOs;
using StoreProducts.WebAPI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreProducts.WebApi.ProductService.Tests
{
    public class ProductServiceTests
    {
        private readonly ProductRepositoryFakeData repository;
        public ProductServiceTests()
        {
            repository = new ProductRepositoryFakeData();
        }
        [Fact]
        public void GetProductNotNull()
        {
            //Arrange

            //Act
            var product = repository.GetByid(1);
            //Assert
            Assert.NotNull(product);
        }
        [Fact]
        public void GetProductIsNull()
        {
            //Arrange

            //Act
            var product = repository.GetByid(31242);
            //Assert
            Assert.Null(product);
        }
        [Fact]
        public void AddProductSuccess()
        {
            //Arrange
            var product = new Product() {Name = "Product 3213123", VendorCode = "Product4VendorCode", Price = 444, CreatedAt = DateTime.Parse("03.11.2024 20:53"), UpdatedAt = null };
            //Act
            repository.Add(product);
            var lastProduct = repository.GetProducts().Last();
            //Assert
            Assert.Equal(product.Name, lastProduct.Name);
        }
        [Fact]
        public void UpdateProductSuccess()
        {
            //Arrange
            var product = new Product() {Id=1, Name = "Product 3213123", VendorCode = "Product4VendorCode", Price = 444, CreatedAt = DateTime.Parse("03.11.2024 20:53"), UpdatedAt = null };
            //Act
            repository.Update(product);
            //Assert
            var expectedProduct = repository.GetByid(product.Id);
            Assert.Equal(expectedProduct.Name, product.Name);
        }
        [Fact]
        public void UpdateNotExistProduct()
        {
            //Arrange
            var product = new Product() { Id = 421421, Name = "Product 3213123", VendorCode = "Product4VendorCode", Price = 444, CreatedAt = DateTime.Parse("03.11.2024 20:53"), UpdatedAt = null };
            //Act
            repository.Update(product);
            //Assert
            var expectedProduct = repository.GetByid(product.Id);
            Assert.NotEqual(expectedProduct.Name, product.Name);
        }
        [Fact]
        public void DeleteProductSuccess()
        {
            //Arrange
            var productId = 1;
            var countBefore = repository.GetProducts().Count();
            //Act
            repository.Delete(productId);
            //Assert
            var expectedCount = repository.GetProducts().Count();
            Assert.Equal(expectedCount, countBefore-1);
        }
        [Fact]
        public void DeleteNotExistsProduct()
        {
            var productId = 1412412;
            var countBefore = repository.GetProducts().Count();
            //Act
            repository.Delete(productId);
            //Assert
            var expectedCount = repository.GetProducts().Count();
            Assert.Equal(expectedCount, countBefore);
        }
    }
}
