using System;

namespace Neptune.Core.Domain.Entities
{
    public class Payment
    {
        public int PaymentId { get; set; }
        public double PaymentAmount { get; set; }
        public string OtherDetails { get; set; }

        public Guid PaymentMethodCode { get; set; }
        public int TransactionId { get; set; }
    }
}