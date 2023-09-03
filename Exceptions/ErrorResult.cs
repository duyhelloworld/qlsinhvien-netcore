using System.ComponentModel.DataAnnotations;

namespace qlsinhvien.Exceptions;

public class ErrorResult
{
    public string ErrorId { get; set; } = null!;
    public int StatusCode { get; set; }
    public string? ExceptionMessage  { get; set; }
    public IEnumerable<string>? Solution { get; set;}
    public string? Source { get; set; }
}