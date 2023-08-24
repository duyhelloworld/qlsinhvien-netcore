namespace qlsinhvien.SecurityConfig.Model;

public class ResponseLoginModel
{
    public bool IsSuccess { get; set; }

    public string Message { get; set; } = "";

    public object Data { get; set; } = null!;
}