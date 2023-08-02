using System.ComponentModel.DataAnnotations;

namespace qlsinhvien.Entities;

public class ConNguoi
{
    [Required]
    [StringLength(40)]
    public string HoTen { get; set; }

    public bool GioiTinh { get; set; }

    [DataType(DataType.Date)]
    public DateTime NgaySinh { get; set; }

    [StringLength(80)]
    public string DiaChiThuongTru { get; set; }

    [StringLength(80)]
    public string QueQuan { get; set; }

    [MaxLength(150)]
    public string Email { get; set; }

    [StringLength(10)]
    public string PhoneNumber { get; set; }
}