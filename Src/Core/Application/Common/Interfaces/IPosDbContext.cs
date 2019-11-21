using Microsoft.EntityFrameworkCore;
using Neptune.Core.Domain.Entities;

namespace Neptune.Core.Application.Common.Interfaces
{
    /// <summary>
    /// Interface POS database context
    /// It is implemented in persistence
    /// </summary>
    public interface IPosDbContext
    {
         DbSet<Customer> Customers { get; set; }
         DbSet<Payment> Payments { get; set; }
         DbSet<PaymentMethod> PaymentMethods { get; set; }
         DbSet<Product> Products { get; set; }
         DbSet<ProductInTransaction> ProductInTransactions { get; set; }
         DbSet<SalesOutlet> SalesOutlets { get; set; }
         DbSet<Staff> Staffs { get; set; }
         DbSet<Transaction> Transactions { get; set; }
    }
}