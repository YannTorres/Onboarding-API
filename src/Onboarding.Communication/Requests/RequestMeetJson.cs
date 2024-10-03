namespace Onboarding.Communication.Requests;
public class RequestMeetJson
{
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string Local { get; set; } = string.Empty;
    public DateTime Date { get; set; }
}
