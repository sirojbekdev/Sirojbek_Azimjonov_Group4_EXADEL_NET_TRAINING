using System.Text.Json.Serialization;
using TaskManagementSystem.Domain.Enums;

namespace TaskManagementSystem.Domain.Entities
{
    public class TaskItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public Status Status { get; set; }
        public int CreatorId { get; set; }
        [JsonIgnore]
        public virtual User Creator { get; set; }
        public int? PerformerId { get; set; }
        [JsonIgnore]
        public virtual User Performer { get; set; }
    }
}