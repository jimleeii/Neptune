using System.Collections.Generic;
using Neptune.Core.Domain.Common;

namespace Neptune.Core.Domain.Entities
{
    public class SalesOutlet : AuditableEntity
    {
        public int SalesOutletId { get; set; }
        public string SalesOutletDetails { get; set; }

        public ICollection<Transaction> Transactions { get; private set; }

        public SalesOutlet()
        {
            Transactions = new HashSet<Transaction>();
        }
    }
}