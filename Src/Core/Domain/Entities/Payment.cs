using System;

namespace Neptune.Core.Domain.Entities
{
    public class Payment
    {
        public int PaymentId { get; set; }
        public double PaymentAmount { get; set; }
        public string OtherDetails { get; set; }

        // Foreign keys
        public Guid PaymentMethodCode { get; set; }
        public PaymentMethod PaymentMethod { get; set; }
        public int TransactionId { get; set; }
        public Transaction Transaction { get; set; }
    }
}