using Onboarding.Communication.Enums;

namespace Onboarding.Communication.Requests;
public class RequestTaskJson
{
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public Priority Priority { get; set; }
    public Status Status { get; set; }
}
