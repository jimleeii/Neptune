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
    /// <summary>
    /// POS data context to access database
    /// Must implement from Application layer interface
    /// </summary>
    public class PosDbContext : DbContext, IPosDbContext
    {
        #region Variables

        /// <summary>
        /// Current user service
        /// </summary>
        private readonly ICurrentUserService _currentUserService;
        /// <summary>
        /// System time stamp
        /// </summary>
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

        /// <summary>
        /// Saves changes made to data context
        /// Checks AuitableEntity object and assign current user and system time stamp
        /// </summary>
        /// <param name="cancellationToken">Task cancellation token</param>
        /// <returns></returns>
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

        /// <summary>
        /// Called by the framework when data context is first created to build the model and its mappings in memory
        /// https://docs.microsoft.com/en-us/dotnet/api/system.data.entity.dbcontext.onmodelcreating?view=entity-framework-6.2.0
        /// </summary>
        /// <param name="modelBuilder">Model builder</param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(PosDbContext).Assembly);
        }

        #endregion

        #region Constructors

        /// <summary>
        /// Creates instant of this class
        /// </summary>
        /// <param name="options">Db context options</param>
        public PosDbContext(DbContextOptions<PosDbContext> options)
            : base(options)
        {
        }

        /// <summary>
        /// Creates instant of this class
        /// </summary>
        /// <param name="options">Db context options</param>
        /// <param name="currentUserService">Current user service</param>
        /// <param name="dateTime">System data time</param>
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