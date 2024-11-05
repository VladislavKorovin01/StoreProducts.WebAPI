namespace StoreProducts.WebAPI.Entities
{
    public class Product : BaseEntity
    {
        public string Name { get; set; }
        public string? VendorCode { get; set; }
        public decimal Price { get; set; }
        public long Count { get; set; }
    }
}
