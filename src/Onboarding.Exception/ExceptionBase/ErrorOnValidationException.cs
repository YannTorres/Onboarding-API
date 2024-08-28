
namespace Onboarding.Exception.ExceptionBase;
public class ErrorOnValidationException : OnboardingException
{
    private readonly List<string> _errors;
    public ErrorOnValidationException(List<string> errors) 
    {
        _errors = errors;
    }
    public override int StatusCode => 400;

    public override List<string> GetErros()
    {
        return _errors;
    }
}
