namespace qlsinhvien.Exceptions;

public class HttpException : Exception
{
    public int MaLoi { get; }

    public HttpException(int MaLoi, string message) : base(message)
    {
        this.MaLoi = MaLoi;
    }
}