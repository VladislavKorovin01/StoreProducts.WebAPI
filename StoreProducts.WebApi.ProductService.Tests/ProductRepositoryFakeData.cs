using StoreProducts.WebAPI.DTOs;
using StoreProducts.WebAPI.Entities;
using StoreProducts.WebAPI.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreProducts.WebApi.ProductService.Tests
{
    public class ProductRepositoryFakeData : IProductRepository
    {
        private static int id;
        public List<Product> Products { get; set; }
        public ProductRepositoryFakeData()
        {
            Products = new List<Product>()
            {
                new Product(){Id=1, Name="Product 1", VendorCode="Product1VendorCode",Price=111,CreatedAt=DateTime.Parse("01.11.2024 10:50"), UpdatedAt=null},
                new Product(){Id=2, Name="Product 2", VendorCode="Product2VendorCode",Price=222,CreatedAt=DateTime.Parse("06.11.2024 19:50"), UpdatedAt=DateTime.Now},
                new Product(){Id=3, Name="Product 3", VendorCode="Product3VendorCode",Price=333,CreatedAt=DateTime.Parse("04.11.2024 4:39"), UpdatedAt=DateTime.Parse("06.11.2024 8:00")},
                new Product(){Id=4, Name="Product 4", VendorCode="Product4VendorCode",Price=444,CreatedAt=DateTime.Parse("03.11.2024 20:53"), UpdatedAt=null},
            };

            id = Products.Count + 1;
        }

        public void Add(Product product)
        {
            product.Id = id++;
            Products.Add(product);
        }

        public Product GetByid(long id)
        {
            return Products.FirstOrDefault(p=>p.Id == id);
        }

        public IEnumerable<Product> GetProducts()
        {
            return Products;
        }

        public void Update(Product product)
        {
            var findProduct = Products.FirstOrDefault(p=>p.Id == product.Id);
            if (findProduct != null)
            {
                var index = Products.IndexOf(findProduct);
                Products[index] = product;
            }
        }

        public void Delete(long id)
        {
            var Product = GetByid(id);
            if (Product != null)
            {
                Products.Remove(Product);
            }
        }
    }
}
