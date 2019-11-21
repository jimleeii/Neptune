using System.Collections.Generic;

namespace Neptune.Core.Domain.Entities
{
    public class Staff
    {
        public int StaffId { get; set; }
        public string StaffDetails { get; set; }

        public ICollection<Transaction> Transactions { get; private set; }

        public Staff()
        {
            Transactions = new HashSet<Transaction>();
        }
    }
}