﻿using Core.Enums;

namespace Application.DTOs
{
    public class TaskDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public Core.Enums.TaskStatus Status { get; set; }
        public Guid UserId { get; set; }
        public Guid ActivityId { get; set; }
    }
}
