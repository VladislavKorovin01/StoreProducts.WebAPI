using Microsoft.AspNetCore.Mvc;
using StoreProducts.WebAPI.DTOs;
using StoreProducts.WebAPI.Entities;
using StoreProducts.WebAPI.Repositories.Interfaces;
using StoreProducts.WebAPI.Services.Interfaces;

namespace StoreProducts.WebAPI.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        public ProductService(IProductRepository ProductRepository)
        {
            _productRepository = ProductRepository;
        
        }
        public void Add(ProductDTO product)
        {
            var Product = new Product()
            {
                Name = product.Name,
                VendorCode = product.VendorCode,
                Price = product.Price,
                Count = product.Count,
                CreatedAt = DateTime.Now
            };
            _productRepository.Add(Product);
        }

        public void Delete(long id)
        {
            var product = _productRepository.GetByid(id);
            if (product == null)
            {
                throw new Exception("Product not found");
            }
            _productRepository.Delete(id);
        }

        public ProductDTO GetById(long id)
        {
            var product = _productRepository.GetByid(id);
            if (product == null)
            {
                throw new Exception("Product not found");
            }

            var ProductDTO = new ProductDTO
            {
                Id = product.Id,
                Name = product.Name,
                VendorCode = product.VendorCode,
                Price = product.Price,
                Count = product.Count,
                CreatedAt = product.CreatedAt,
                UpdatedAt = DateTime.Now
            };
            return ProductDTO;
        }

        public IEnumerable<ProductDTO> GetProducts()
        {

            return _productRepository.GetProducts().Select(p => new ProductDTO
                                                                    {
                                                                        Id = p.Id,
                                                                        Name = p.Name,
                                                                        VendorCode = p.VendorCode,
                                                                        Price = p.Price,
                                                                        Count = p.Count,
                                                                        CreatedAt = p.CreatedAt,
                                                                        UpdatedAt = p.UpdatedAt
                                                                    });
        }

        public void Update(ProductDTO product)
        {
            var existProduct = _productRepository.GetByid(product.Id);

            var updateProduct = new Product
            {
                Id = product.Id,
                Name = product.Name,
                VendorCode = product.VendorCode,
                Price = product.Price,
                Count = product.Count,
                CreatedAt = existProduct.CreatedAt,
                UpdatedAt = DateTime.Now
            };
            _productRepository.Update(updateProduct);
        }
    }
}
