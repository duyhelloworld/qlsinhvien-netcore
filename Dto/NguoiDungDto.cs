using System.ComponentModel.DataAnnotations;
using qlsinhvien.Entities;
using qlsinhvien.Models;

namespace qlsinhvien.Dtos;

public class NguoiDungDto
{
    [StringLength(100)]
    public string TenNguoiDung { get; set; } = null!;
    // [Range(1, 5000)]
    // public int? MaSinhVien { get; set; }
    // [Range(1, 500)]
    // public int? MaGiangVien { get; set; }
    [Range(1, 5000)]
    public int MaSo { get; set; }
    public string? TenVaiTro { get; set; } = null!;
    public string? TenHienThi { get; set; } = null!;
    // public string? Email { get; set; } = null!;

    public static NguoiDungDto Convert(NguoiDung nd)
    {
        return new NguoiDungDto() 
        {
            TenNguoiDung = nd.TenNguoiDung,
            TenVaiTro = nd.TenVaiTro,
            TenHienThi = nd.TenHienThi,
            MaSo = nd.MaSinhVien ?? nd.MaGiangVien ?? 0
        };
    }
    public static NguoiDung Convert(NguoiDungDto nd)
    {
        var nguoiDung = new NguoiDung()
        {
            TenNguoiDung = nd.TenNguoiDung,
            TenVaiTro = nd.TenVaiTro,
            TenHienThi = nd.TenHienThi
        };
        switch (nd.TenVaiTro)
        {
            case "sinhvien":
                nguoiDung.MaSinhVien = nd.MaSo;
                return nguoiDung;
            case "giangvien":
            case "admin":
            case "superadmin":
                nguoiDung.MaGiangVien = nd.MaSo;
                return nguoiDung;
            default:
                return nguoiDung;
        }
    }
}