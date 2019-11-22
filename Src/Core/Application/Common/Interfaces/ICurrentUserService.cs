namespace Neptune.Core.Application.Common.Interfaces
{
    /// <summary>
    /// Interface for current user service
    /// </summary>
    public interface ICurrentUserService
    {
        /// <summary>
        /// Gets current user id
        /// </summary>
        string UserId { get; }
        /// <summary>
        /// Gets current is authenticated
        /// </summary>
        bool IsAuthenticated { get; }
    }
}