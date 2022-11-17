namespace PackIt.Domain.Abstractions;

public abstract class DomainException : Exception
{
    private string message;

    public string ErrorMessage
    {
        get => message ?? base.Message;
        set => message = value;
    }
}