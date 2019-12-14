using System.Threading.Tasks;
using Neptune.Core.Application.Common.Interfaces;
using Neptune.Core.Application.Notifications;

namespace Infrastructure
{
    public class NotificationService : INotificationService
    {
        public Task SendAsync(MessageDto message)
        {
            return Task.CompletedTask;
        }
    }
}