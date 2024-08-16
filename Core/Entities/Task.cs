using Core.Enums;
namespace Core.Entities
{
    public class Task
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Title { get; set; }
        public string Description { get; set; }
        public Enums.TaskStatus Status { get; set; }
        public Guid UserId { get; set; }
        public User User { get; set; }

        public Guid ActivityId { get; set; }
        public Activity Activity { get; set; }
    }
}
