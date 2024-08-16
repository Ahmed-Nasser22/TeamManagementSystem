namespace Application.Events
{
    public class TaskAssignedEvent
    {
        public int UserId { get; set; }
        public string TaskTitle { get; set; }

        public TaskAssignedEvent(int userId, string taskTitle)
        {
            UserId = userId;
            TaskTitle = taskTitle;
        }
    }
}
