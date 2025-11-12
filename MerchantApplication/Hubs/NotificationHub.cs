using MerchantCore.Entities;
using Microsoft.AspNetCore.SignalR;
using System.Collections.Concurrent;

namespace MerchantApplication.Hubs
{
    public class NotificationHub : Hub
    {
        // Store connected users: UserId -> ConnectionId
        private static readonly ConcurrentDictionary<string, string> ConnectedUsers = new();

        //// Client calls this after connecting to register itself
        //public Task RegisterUser(string userId)
        //{
        //    ConnectedUsers[userId] = Context.ConnectionId;
        //    return Task.CompletedTask;
        //}

        // Request user list from client
        public Task RequestUserList()
        {
            var userList = ConnectedUsers.Keys.ToList();
            return Clients.Caller.SendAsync("UpdateUserList", userList);
        }

        // Notify all clients when a new user registers
        public async Task RegisterUser(string userId)
        {
            ConnectedUsers[userId] = Context.ConnectionId;

            // Send updated list to all clients
            await Clients.All.SendAsync("UpdateUserList", ConnectedUsers.Keys.ToList());
        }

        // Send notification to specific user
        //public async Task SendNotificationToUser(string userId, Notification notification)
        //{
        //    if (ConnectedUsers.TryGetValue(userId, out var connectionId))
        //    {
        //        await Clients.Client(connectionId).SendAsync("ReceiveNotification", notification);
        //    }
        //}

        // Send to a specific user
        public async Task SendMessageToUser(string senderUserId, string receiverUserId, string message)
        {
            if (receiverUserId.ToLower() == "all")
            {
                await Clients.All.SendAsync("ReceiveNotification", new
                {
                    fromUserId = senderUserId,
                    message = message
                });
            }
            else if (ConnectedUsers.TryGetValue(receiverUserId, out var connectionId))
            {
                await Clients.Client(connectionId).SendAsync("ReceiveNotification", new
                {
                    fromUserId = senderUserId,
                    message = message
                });
            }
        }


        // Send notification to all connected users
        public async Task NotifyAllAsync(Notification notification)
        {
            await Clients.All.SendAsync("ReceiveNotification", notification);
        }

        // Remove disconnected users
        public override Task OnDisconnectedAsync(Exception? exception)
        {
            var user = ConnectedUsers.FirstOrDefault(x => x.Value == Context.ConnectionId);
            if (user.Key != null)
            {
                ConnectedUsers.TryRemove(user.Key, out _);
            }
            return base.OnDisconnectedAsync(exception);
        }
        // Send message to all other users
        public async Task SendMessageToOthers(string senderUserId, string message)
        {
            foreach (var user in ConnectedUsers)
            {
                if (user.Key != senderUserId) // Skip the sender
                {
                    await Clients.Client(user.Value).SendAsync("ReceiveNotification", new
                    {
                        fromUserId = senderUserId,
                        message = message
                    });
                }
            }
        }
    }
}
