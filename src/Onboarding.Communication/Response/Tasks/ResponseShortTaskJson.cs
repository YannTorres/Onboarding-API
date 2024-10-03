using Onboarding.Communication.Enums;

namespace Onboarding.Communication.Response.Tasks;
public class ResponseShortTaskJson
{
    public long Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; }
    public Priority Priority { get; set; }
    public Status Status { get; set; }
}
