namespace SimplesPDV.Exception.Validation;

public class ErrorOnValidationException :  SimplesPdvException
{
    public List<string> Errors { get; set; }

    public ErrorOnValidationException(List<string> errorMessages)
    {
        Errors = errorMessages;
    }
}