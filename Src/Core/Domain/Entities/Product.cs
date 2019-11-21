using System.Collections.Generic;
using Neptune.Core.Domain.Common;

namespace Neptune.Core.Domain.Entities
{
    public class Product : AuditableEntity
    
    {
        public int ProductId { get; set; }
        public string ProductDetails { get; set; }
        public double ProductWholesalePrice { get; set; }
        public double ProductRetailPrice { get; set; }

        public ICollection<ProductInTransaction> ProductInTransactions { get; private set; }
        
        public Product()
        {
            ProductInTransactions = new HashSet<ProductInTransaction>();
        }
    }
}