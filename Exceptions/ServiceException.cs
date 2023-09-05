namespace qlsinhvien.Exceptions;

public class ServiceException : Exception
{
    public int StatusCode { get; set; }
    public IEnumerable<string>? Solutions { get; set; }

    public ServiceException(int statusCode, string message) : base(message)
    {
        StatusCode = statusCode;
    }

    public ServiceException(int statusCode, string message, params string[] solutions) : base(message)
    {
        StatusCode = statusCode;
        Solutions = solutions;
    }
}