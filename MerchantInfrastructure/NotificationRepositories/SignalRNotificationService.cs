using MerchantApplication.Features.SignalR.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MerchantCore.Entities;
using Microsoft.AspNetCore.SignalR;
using MerchantApplication.Hubs;
namespace MerchantInfrastructure.NotificationRepositories
{
    public class SignalRNotificationService : INotificationService
    {
         //Hub, 
        private readonly IHubContext<NotificationHub> _hubContext;
        public SignalRNotificationService(IHubContext<NotificationHub> hubContext)
        {
            _hubContext = hubContext;
        }

        public Task NotifyAllAsync(Notification notification)
        {
            // You can send the whole DTO and client will receive it as JSON
            return _hubContext.Clients.All.SendAsync("ReceiveNotification", notification);
        }

        public Task NotifyUserAsync(string userId, Notification notification)
        {
            // If you track connection IDs or user identifiers, send to specific user
            return _hubContext.Clients.User(userId).SendAsync("ReceiveNotification", notification);
        }

    }
}
