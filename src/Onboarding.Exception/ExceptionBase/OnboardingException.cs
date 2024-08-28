namespace Onboarding.Exception.ExceptionBase;
public abstract class OnboardingException : System.Exception
{
    protected OnboardingException() { }
    protected OnboardingException(string message) : base(message) { }
    public abstract int StatusCode { get; }
    public abstract List<string> GetErros();
}
