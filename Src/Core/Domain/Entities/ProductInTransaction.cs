namespace Neptune.Core.Domain.Entities
{
    public class ProductInTransaction
    {
        public int ProductId { get; set; }
        public int TransactionId { get; set; }
        public int Quantity { get; set; }
    }
}