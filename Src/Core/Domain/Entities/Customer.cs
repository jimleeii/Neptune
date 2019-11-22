using System.Collections.Generic;
using Neptune.Core.Domain.Common;

namespace Neptune.Core.Domain.Entities
{
    /// <summary>
    /// Represents customer in data model
    /// </summary>
    public class Customer : AuditableEntity
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