namespace Onboarding.Domain.Entities;
public class Meet
{
    public long Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string Local { get; set; } = string.Empty;
    public DateTime Date { get; set; }
}
