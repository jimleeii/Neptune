using System;

namespace Neptune.Core.Domain.Common
{
    /// <summary>
    /// Represents a single element of the Audit Universe
    /// The collection of things in the business that might be audited
    /// </summary>
    public class AuditableEntity
    {
        public string CreatedBy { get; set; }

        public DateTime Created { get; set; }

        public string LastModifiedBy { get; set; }

        public DateTime? LastModified { get; set; }
    }
}