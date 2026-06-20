namespace Workspace_booking.Common;

public class Result
{
    public bool IsSuccess { get; }
    public string Message { get; }
    
    public Result(bool isSuccess, string message)
    {
        this.IsSuccess = isSuccess;
        this.Message = message;
    }
    
    
    
}