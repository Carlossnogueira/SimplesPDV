namespace SimplesPDV.Communication.Response;

public class ResponseErrorJson
{
    public List<String> ErrorMessages  { get; set; }
    
    public ResponseErrorJson(string errorMessage)
    {
        ErrorMessages= [errorMessage];
    }
    
    public ResponseErrorJson(List<string> errorMessage)
    {
        ErrorMessages = errorMessage;
    }
}