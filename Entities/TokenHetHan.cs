using System.ComponentModel.DataAnnotations;

namespace qlsinhvien.Entities;

public class TokenHetHan
{
    [Key]
    public string MaToken { get; set; } = null!;
    public DateTime NgayHetHan { get; set; }  
}