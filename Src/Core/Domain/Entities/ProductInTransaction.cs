using System.ComponentModel.DataAnnotations;

namespace Neptune.Core.Domain.Entities
{
    public class ProductInTransaction
    {
        [Key]
        public int ProductId { get; set; }
        [Key]
        public int TransactionId { get; set; }
        public int Quantity { get; set; }
    }
}