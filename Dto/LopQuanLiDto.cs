using System.Text.Json.Serialization;
using qlsinhvien.Entities;

namespace qlsinhvien.Dto
{
    public class LopQuanLiDto
    {
        public int MaLopQuanLi { get; set; }
        public string TenLopQuanLi { get; set; }
        public int? SiSo { get; set; }
        public int MaKhoa  {get; set;}
        public int MaGiangVien {get; set;}

        public Khoa? Khoa { get; set; }
        public GiangVienContact? GiangVien { get; set; }
    }
}