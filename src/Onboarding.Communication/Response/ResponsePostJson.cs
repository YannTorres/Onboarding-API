namespace Onboarding.Communication.Response;

public class ResponsePostJson
{
    public long Id { get; set; }
    public string Title { get; set; }
    public string? Content { get; set; }
    public DateTime CreatedAt { get; set; }
}
