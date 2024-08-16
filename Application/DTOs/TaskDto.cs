using Core.Enums;

namespace Application.DTOs
{
    public class TaskDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public Core.Enums.TaskStatus Status { get; set; }
        public int UserId { get; set; }
        public int ActivityId { get; set; }
    }
}
