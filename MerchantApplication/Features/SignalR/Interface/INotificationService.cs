using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MerchantCore.Entities;
namespace MerchantApplication.Features.SignalR.Interface
{
    public interface INotificationService
    {
        Task NotifyAllAsync(Notification notification);
        Task NotifyUserAsync(string userId, Notification notification); // optional
    }
}
