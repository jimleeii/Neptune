using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Neptune.Core.Application.Common.Interfaces;
using Neptune.Core.Common;
using Neptune.Core.Domain.Common;
using Neptune.Core.Domain.Entities;

namespace Neptune.Persistence
{
    public class PosDbContext : DbContext, IPosDbContext
    {
        #region Variables

        private readonly ICurrentUserService _currentUserService;
        private readonly IDateTime _dateTime;

        #endregion
        
        #region Properties

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<PaymentMethod> PaymentMethods { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductInTransaction> ProductInTransactions { get; set; }
        public DbSet<SalesOutlet> SalesOutlets { get; set; }
        public DbSet<Staff> Staffs { get; set; }
        public DbSet<Transaction> Transactions { get; set; }

        #endregion

        #region Methods

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            foreach (var entry in ChangeTracker.Entries<AuditableEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedBy = _currentUserService.UserId;
                        entry.Entity.Created = _dateTime.Now;
                        break;
                    case EntityState.Modified:
                        entry.Entity.LastModifiedBy = _currentUserService.UserId;
                        entry.Entity.LastModified = _dateTime.Now;
                        break;
                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(PosDbContext).Assembly);
        }

        #endregion

        #region Constructors

        public PosDbContext(DbContextOptions<PosDbContext> options)
            : base(options)
        {
        }

        public PosDbContext(DbContextOptions<PosDbContext> options, ICurrentUserService currentUserService, IDateTime dateTime)
            : base(options)
        {
            if (currentUserService == null)
            {
                // TODO : Use a customized exception
                throw new ArgumentNullException(nameof(currentUserService));
            }

            if (dateTime == null)
            {
                // TODO : Use a customized exception
                throw new ArgumentNullException(nameof(dateTime));
            }

            _currentUserService = currentUserService;
            _dateTime = dateTime;
        }

        #endregion
    }
}