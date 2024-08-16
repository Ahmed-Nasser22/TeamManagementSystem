using Application.Events;
using Microsoft.AspNetCore.SignalR;
using WebUI.Hubs;

namespace WebUI.EventHandlers
{
    public class TaskStatusUpdatedEventHandler : IEventHandler<TaskStatusUpdatedEvent>
    {
        private readonly IHubContext<TaskHub> _hubContext;

        public TaskStatusUpdatedEventHandler(IHubContext<TaskHub> hubContext)
        {
            _hubContext = hubContext;
        }

        public async Task Handle(TaskStatusUpdatedEvent eventMessage)
        {
            await _hubContext.Clients.User(eventMessage.UserId.ToString())
                .SendAsync("ReceiveTaskUpdate", $"Task updated: {eventMessage.TaskTitle} is now {eventMessage.NewStatus}");
        }
    }
}
