using StoreProducts.WebAPI.Entities;

namespace StoreProducts.WebAPI.Repositories.Interfaces
{
    public interface IProductRepository
    {
        public void Add(Product product);
        public Product GetByid(long id);
        public IEnumerable<Product> GetProducts();
        public void Update(Product product);
        public void Delete(long id);
    }
}
