namespace Neptune.Core.Application.Common.Interfaces
{
    /// <summary>
    /// Interface for current user service
    /// </summary>
    public interface ICurrentUserService
    {
        string UserId { get; }
        bool IsAuthenticated { get; }
    }
}