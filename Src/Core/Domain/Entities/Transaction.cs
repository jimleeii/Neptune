using System;

namespace Neptune.Core.Domain.Entities
{
    public class Transaction
    {
        public int TransactionId { get; set; }
        public DateTime TransactionDateTime { get; set; }
        public double TransactionWholesalePrice { get; set; }
        public double TransactionRetailPrice { get; set; }
        public string OtherDetails { get; set; }

        public int CustomerId { get; set; }
        public int SalesOutletId { get; set; }
        public int StaffId { get; set; }
    }
}