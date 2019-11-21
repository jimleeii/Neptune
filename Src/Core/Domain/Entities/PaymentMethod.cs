using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Neptune.Core.Domain.Entities
{
    public class PaymentMethod
    {
        [Key]
        public Guid PaymentMethodCode { get; set; }
        public string PaymentMethodName { get; set; }
        public string PaymentMethodDescription { get; set; }

        public ICollection<Payment> Payments { get; private set; }

        public PaymentMethod() 
        {
            Payments = new HashSet<Payment>();
        }
    }
}