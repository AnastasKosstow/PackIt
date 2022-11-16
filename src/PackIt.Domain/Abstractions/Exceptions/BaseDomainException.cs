namespace PackIt.Domain.Abstractions.Exceptions;

public abstract class BaseDomainException : Exception
{
    private string message;

    public string ErrorMessage
    {
        get => this.message ?? base.Message;
        set => this.message = value;
    }
}