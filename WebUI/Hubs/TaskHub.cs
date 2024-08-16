using Microsoft.AspNetCore.SignalR;

namespace WebUI.Hubs
{
    public class TaskHub : Hub
    {
        // Method to send task updates to clients
        public async Task SendTaskUpdate(string userId, string message)
        {
            await Clients.User(userId).SendAsync("ReceiveTaskUpdate", message);
        }
    }
}
