using qlsinhvien.Entities;

namespace qlsinhvien.Dto;
public class DiemSinhVienDto
{
    [MaxValue(1, EGioiHan.MaxSinhVien)]
    public int MaSinhVien { get; set; }

    [MaxValue(1, EGioiHan.MaxLopMonHoc)]
    public int MaLopMonHoc { get; set; }

    [MaxValue(1, EGioiHan.MaxDiem)]
    public float? DiemChuyenCan { get; set; }

    [MaxValue(1, EGioiHan.MaxDiem)]
    public float? DiemGiuaKi { get; set; }

    [MaxValue(1, EGioiHan.MaxDiem)]
    public float? DiemCuoiKi { get; set; }

    [MaxValue(1, EGioiHan.MaxHocKi)]
    public int HocKi { get; set; }

    public string? GhiChu { get; set; }

    public static DiemSinhVien Convert(DiemSinhVienDto diemSinhVienDto)
    {
        return new DiemSinhVien
        {
            MaSinhVien = diemSinhVienDto.MaSinhVien,
            MaLopMonHoc = diemSinhVienDto.MaLopMonHoc,
            DiemChuyenCan = diemSinhVienDto.DiemChuyenCan,
            DiemGiuaKi = diemSinhVienDto.DiemGiuaKi,
            DiemCuoiKi = diemSinhVienDto.DiemCuoiKi,
            HocKi = diemSinhVienDto.HocKi,
            GhiChu = diemSinhVienDto.GhiChu
        };
    }

    public static DiemSinhVienDto Convert(DiemSinhVien diemSinhVien)
    {
        return new DiemSinhVienDto
        {
            MaSinhVien = diemSinhVien.MaSinhVien,
            MaLopMonHoc = diemSinhVien.MaLopMonHoc,
            DiemChuyenCan = diemSinhVien.DiemChuyenCan,
            DiemGiuaKi = diemSinhVien.DiemGiuaKi,
            DiemCuoiKi = diemSinhVien.DiemCuoiKi,
            HocKi = diemSinhVien.HocKi,
            GhiChu = diemSinhVien.GhiChu
        };
    }
}