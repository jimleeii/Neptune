using System;

namespace Neptune.Core.Common
{
    /// <summary>
    /// Interface for date time
    /// </summary>
    public interface IDateTime
    {
        /// <summary>
        /// Gets current time stamp
        /// </summary>
        DateTime Now { get; }
    }
}