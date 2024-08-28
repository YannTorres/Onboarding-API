using Onboarding.Domain.Enums;

namespace Onboarding.Domain.Entities;
public class Task
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; }
    public Priority Priority { get; set; }
    public Status Status { get; set; }

}
