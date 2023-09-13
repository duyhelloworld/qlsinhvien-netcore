using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace qlsinhvien.Entities;

[Table("TokenHetHan")]
public class TokenHetHan
{
    [Key]
    public string MaToken { get; set; } = null!;
    public DateTime HetHanKhi { get; set; } = DateTime.Now;
}