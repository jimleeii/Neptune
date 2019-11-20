using System;

namespace Neptune.Core.Domain.Entities
{
    public class PaymentMethod
    {
        public Guid PaymentMethodCode { get; set; }
        public string PaymentMethodName { get; set; }
        public string PaymentMethodDescription { get; set; }
    }
}