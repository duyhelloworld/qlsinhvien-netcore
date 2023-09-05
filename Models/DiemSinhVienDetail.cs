
namespace qlsinhvien.Entities
{
    public class DiemSinhVienModel
    {
        public int MaLopQuanLi { get; set; }
        public int MaLopMonHoc { get; set; }
        public int MaSinhVien { get; set; }
        public string HoTen { get; set; } = null!;
        public int MaMonHoc { get; set; }
        public string TenMonHoc { get; set; } = null!;
        public float DiemChuyenCan { get; set; }
        public float DiemGiuaKi { get; set; }
        public float DiemCuoiKi { get; set; }
    }
}
