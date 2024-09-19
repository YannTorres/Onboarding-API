namespace Onboarding.Communication.Requests;
public class RequestPostJson
{
    public string Title { get; set; } = string.Empty;
    public string Content {  get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; }
}
