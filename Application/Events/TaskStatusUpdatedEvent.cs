namespace Application.Events
{
    public class TaskStatusUpdatedEvent
    {
        public int UserId { get; set; }
        public string TaskTitle { get; set; }
        public string NewStatus { get; set; }

        public TaskStatusUpdatedEvent(int userId, string taskTitle, string newStatus)
        {
            UserId = userId;
            TaskTitle = taskTitle;
            NewStatus = newStatus;
        }
    }
}
