using StoreProducts.WebAPI.DTOs;

namespace StoreProducts.WebAPI.Services.Interfaces
{
    public interface IProductService
    {
        public void Add(ProductDTO product);
        public ProductDTO GetById(long id);
        public IEnumerable<ProductDTO> GetProducts();
        public void Update(ProductDTO product);
        public void Delete(long id);
    }
}
