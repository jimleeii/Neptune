namespace Neptune.Core.Domain.Entities
{
    public class Product
    {
        public int ProductId { get; set; }
        public string ProductDetails { get; set; }
        public double ProductWholesalePrice { get; set; }
        public double ProductRetailPrice { get; set; }
    }
}