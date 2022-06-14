using TaskManagementSystem.Domain.Enums;

namespace TaskManagementSystem.Domain.Entities
{
    public class TaskDto
    {
        public string Name { get; set; }
        public string? Description { get; set; }
        public Status Status { get; set; }
        public int CreatorId { get; set; }
        public int? PerformerId { get; set; }
    }
}
