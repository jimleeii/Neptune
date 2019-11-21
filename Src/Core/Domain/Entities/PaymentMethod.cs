using System.Collections.Generic;

namespace Neptune.Core.Domain.Entities
{
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