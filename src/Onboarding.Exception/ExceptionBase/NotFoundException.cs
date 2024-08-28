
namespace Onboarding.Exception.ExceptionBase;
public class NotFoundException : OnboardingException
{
    public NotFoundException(string errorMessages) : base(errorMessages) { }
    public override int StatusCode => 404;
    public override List<string> GetErros()
    {
        return [Message];
    }
}
