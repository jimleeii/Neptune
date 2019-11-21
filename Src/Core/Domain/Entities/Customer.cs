using System.Collections.Generic;

namespace Neptune.Core.Domain.Entities
{
    public class Customer
    {
        public int CustomerId { get; set; }
        public string CustomerDetails { get; set; }

        public ICollection<Transaction> Transactions { get; private set; }

        public Customer()
        {
            Transactions = new HashSet<Transaction>();
        }
    }
}