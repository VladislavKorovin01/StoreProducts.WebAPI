using Dapper;
using Microsoft.Data.SqlClient;
using StoreProducts.WebAPI.Entities;
using StoreProducts.WebAPI.Repositories.Interfaces;
using System.Threading.Tasks.Dataflow;

namespace StoreProducts.WebAPI.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly string _connectionString;
        public ProductRepository(string ConnectionString)
        {
            _connectionString = ConnectionString;
        }

        public void Add(Product product)
        {
            using (var db = new SqlConnection(_connectionString))
            {
                db.Execute("INSERT INTO Products(Name,VendorCode,Price,Count,CreatedAt) VALUES(@Name,@VendorCode,@Price,@Count,@CreatedAt)", product);
            }
        }

        public void Delete(long id)
        {
            using (var db = new SqlConnection(_connectionString))
            {
                db.Execute("DELETE FROM Products WHERE Id=@Id;", new {id});
            }
        }

        public Product GetByid(long id)
        {
            using (var db = new SqlConnection(_connectionString))
            {
                return db.QueryFirstOrDefault<Product>("SELECT Id,Name,Price,VendorCode,Count,CreatedAt,UpdatedAt FROM Products WHERE Id=@id", new {id});
            }
        }

        public IEnumerable<Product> GetProducts()
        {
            using (
                var db = new SqlConnection(_connectionString))
            {
                return db.Query<Product>("SELECT Id,Name,Price,VendorCode,Count,CreatedAt,UpdatedAt FROM Products");
            }
        }

        public void Update(Product product)
        {
            using (var db = new SqlConnection(_connectionString))
            {   
                db.Execute("UPDATE Products SET Name=@Name, VendorCode=@VendorCode, Price=@Price, Count=@Count, UpdatedAt=@UpdatedAt WHERE Id=@id;", product);
            }
        }
    }
}
