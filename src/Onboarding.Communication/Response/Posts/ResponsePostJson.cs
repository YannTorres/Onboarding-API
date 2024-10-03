namespace Onboarding.Communication.Response.Posts;

public class ResponsePostJson
{
    public long Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string? Content { get; set; }
    public DateTime CreatedAt { get; set; }
}
