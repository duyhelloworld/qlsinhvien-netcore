using System.Text.Json.Serialization;

namespace qlsinhvien.Dto;
public class SinhVienDto {
    [JsonRequired]
    public int MaSinhVien { get; set;}

    [JsonPropertyName("hoten")]
    public string HoTen { get; set; }

    public bool GioiTinh { get; set; }

    [JsonConverter(typeof(DateTime))]
    public DateTime NgaySinh { get; set; }

    public string DiaChiThuongTru { get; set; }

    public string QueQuan { get; set; }

    [JsonRequired]
    public string Email { get; set; }

    [JsonRequired]
    public string SoDienThoai { get; set; }
}         