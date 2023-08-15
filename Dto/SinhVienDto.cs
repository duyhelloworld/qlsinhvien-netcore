using System.Text.Json.Serialization;

namespace qlsinhvien.Dto;
public class SinhVienDto : ConNguoiDto {
    public int MaSinhVien { get; set;}

    public DateTime NgayVaoTruong { get; set; }

    [JsonRequired]
    public int MaLopQuanLi { get; set; }
}         