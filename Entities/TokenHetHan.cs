using System.ComponentModel.DataAnnotations;

namespace qlsinhvien.Entities;

public class TokenHetHan
{
    [Key]
    public int MaToken { get; set; }
    public DateTime NgayHetHan { get; set; }   
}