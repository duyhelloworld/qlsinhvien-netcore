using System.ComponentModel.DataAnnotations;
using qlsinhvien.Dtos;

namespace qlsinhvien.Entities;

public class NguoiDungDtoDangKi : NguoiDungDto
{
    // [RegularExpression("[A-Z]")]
    public string MatKhau { get; set; } = null!;
}