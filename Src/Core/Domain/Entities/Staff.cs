using System.Collections.Generic;
using Neptune.Core.Domain.Common;

namespace Neptune.Core.Domain.Entities
{
    /// <summary>
    /// Represents staff in dota model
    /// </summary>
    public class Staff : AuditableEntity
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