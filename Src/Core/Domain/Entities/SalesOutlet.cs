using System.Collections.Generic;

namespace Neptune.Core.Domain.Entities
{
    public class SalesOutlet
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