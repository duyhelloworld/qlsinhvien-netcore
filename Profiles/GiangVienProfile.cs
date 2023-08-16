using System.Text.Json.Serialization;

namespace qlsinhvien.Profiles;

public class GiangVienProfile
{
    [JsonRequired]
    public int MaGiangVien { get; set; }

    
}