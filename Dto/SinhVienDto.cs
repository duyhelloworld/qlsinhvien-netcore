using qlsinhvien.Entities;

namespace qlsinhvien.Dto;

public class SinhVienDto : ConNguoiDto {
    [MaxValue(1, EGioiHan.MaxSinhVien)]
    public int MaSinhVien { get; set;}

    public DateTime NgayVaoTruong { get; set; }

    [MaxValue(1, EGioiHan.MaxLopQuanLi)]
    public int MaLopQuanLi { get; set; }
}         