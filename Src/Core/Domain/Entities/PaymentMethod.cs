using System.Collections.Generic;

namespace Neptune.Core.Domain.Entities
{
    /// <summary>
    /// Represents payment method in data model
    /// </summary>
    public class PaymentMethod
    {
        public string PaymentMethodCode { get; set; }
        public string PaymentMethodName { get; set; }
        public string PaymentMethodDescription { get; set; }

        public ICollection<Payment> Payments { get; private set; }

        public PaymentMethod() 
        {
            Payments = new HashSet<Payment>();
        }
    }
}