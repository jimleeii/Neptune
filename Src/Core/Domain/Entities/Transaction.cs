using System;
using System.Collections.Generic;

namespace Neptune.Core.Domain.Entities
{
    public class Transaction
    {
        public int TransactionId { get; set; }
        public DateTime TransactionDateTime { get; set; }
        public double TransactionWholesalePrice { get; set; }
        public double TransactionRetailPrice { get; set; }
        public string OtherDetails { get; set; }

        // Foreign keys
        public Customer Customer { get; set; }
        public SalesOutlet SalesOutlet { get; set; }
        public Staff Staff { get; set; }

        public ICollection<Payment> Payments { get; private set; }
        public ICollection<ProductInTransaction> ProductInTransactions { get; private set; }

        public Transaction()
        {
            Payments = new HashSet<Payment>();
            ProductInTransactions = new HashSet<ProductInTransaction>();
        }
    }
}