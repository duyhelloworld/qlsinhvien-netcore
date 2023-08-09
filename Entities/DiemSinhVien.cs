using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;

namespace qlsinhvien.Entities
{
    [Table("DiemSinhVien")]
    [PrimaryKey(nameof(MaLopMonHoc), nameof(MaSinhVien))]
    public class DiemSinhVien
    {
        public int MaLopMonHoc { get; set; }
        [ForeignKey("MaLopMonHoc")]
        [DeleteBehavior(DeleteBehavior.NoAction)]
        public LopMonHoc LopMonHoc { get; set; }

        public int MaSinhVien { get; set; }
        [ForeignKey("MaSinhVien")]
        [DeleteBehavior(DeleteBehavior.NoAction)]
        public SinhVien SinhVien { get; set; }

        public float DiemChuyenCan { get; set; }
        public float DiemGiuaKi { get; set; }
        [NotMapped]
        public float DiemQuaTrinh
        {
            get { return 0.8f * DiemGiuaKi + 0.2f * DiemChuyenCan; }
        }

        public float DiemCuoiKi { get; set; }
        [NotMapped]
        public float DiemTongKet
        {
            get { return 0.7f * DiemCuoiKi + 0.3f * DiemQuaTrinh; }
        }
        [NotMapped]
        public float DiemHe4
        {
            get
            {
                if (DiemTongKet >= 8.5f)
                    return 4.0f;
                else if (DiemTongKet >= 8.0f)
                    return 3.5f;
                else if (DiemTongKet >= 7.0f)
                    return 3.0f;
                else if (DiemTongKet >= 6.5f)
                    return 2.5f;
                else if (DiemTongKet >= 5.5f)
                    return 2.0f;
                else if (DiemTongKet >= 5.0f)
                    return 1.5f;
                else if (DiemTongKet >= 4.0f)
                    return 1.0f;
                else
                    return 0.0f;
            }
        }
        public string DiemChu
        {
           get
            {
                if (DiemHe4 >= 4.0f)
                    return "A";
                else if (DiemHe4 >= 3.5f)
                    return "B+";
                else if (DiemHe4 >= 3.0f)
                    return "B";
                else if (DiemHe4 >= 2.5f)
                    return "C+";
                else if (DiemHe4 >= 2.0f)
                    return "C";
                else if (DiemHe4 >= 1.5f)
                    return "D+";
                else if (DiemHe4 >= 1.0f)
                    return "D";
                else
                    return "F";
            } 
        }

        public int HocKi { get; set; }

        [MaxLength]
        public string GhiChu { get; set; }
    }
}
