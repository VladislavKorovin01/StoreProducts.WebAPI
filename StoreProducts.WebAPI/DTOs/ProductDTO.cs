namespace StoreProducts.WebAPI.DTOs
{
    public class ProductDTO
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string? VendorCode { get; set; }
        public decimal Price { get; set; }
        public long Count { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
