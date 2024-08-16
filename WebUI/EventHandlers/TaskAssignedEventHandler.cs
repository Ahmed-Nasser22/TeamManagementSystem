using Application.Events;
using Microsoft.AspNetCore.SignalR;
using WebUI.Hubs;

namespace WebUI.EventHandlers
{
    public class TaskAssignedEventHandler : IEventHandler<TaskAssignedEvent>
    {
        private readonly IHubContext<TaskHub> _hubContext;

        public TaskAssignedEventHandler(IHubContext<TaskHub> hubContext)
        {
            _hubContext = hubContext;
        }

        public async Task Handle(TaskAssignedEvent eventMessage)
        {
            await _hubContext.Clients.All.SendAsync("ReceiveTaskUpdate", new
            {
                title = eventMessage.TaskTitle,
                userId = eventMessage.UserId
            });
        }
    }
}
