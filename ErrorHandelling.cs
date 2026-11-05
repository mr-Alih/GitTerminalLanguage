namespace ErrorHandelling;

public static class ErrorHandler
{
    public static void Load_Error(string ErrorType)
    {
        Console.WriteLine($"Error {ErrorType}");
    }
}