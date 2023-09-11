using System.ComponentModel.DataAnnotations;

namespace qlsinhvien.Exceptions;

public class ErrorResult
{
    public string ErrorId { get; set; } = null!;
    public int StatusCode { get; set; }
    public string? Reason  { get; set; }
    public IEnumerable<string>? Solutions { get; set;}
}