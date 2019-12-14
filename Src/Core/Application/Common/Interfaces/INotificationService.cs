using System.Threading.Tasks;
using Neptune.Core.Application.Notifications;

namespace Neptune.Core.Application.Common.Interfaces
{
    public interface INotificationService
    {
        Task SendAsync(MessageDto message);
    }
}