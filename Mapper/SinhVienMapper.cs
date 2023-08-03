using qlsinhvien.Dto;
using qlsinhvien.Entities;

namespace qlsinhvien.Mapper
{
    public class SinhVienMapper
    {
        public static SinhVien ToEntity(SinhVienDto sinhVienDto) {
            return new SinhVien() {
                MaSinhVien = sinhVienDto.MaSinhVien,
                HoTen = sinhVienDto.HoTen,
                NgaySinh = sinhVienDto.NgaySinh,
                GioiTinh = sinhVienDto.GioiTinh,
                QueQuan = sinhVienDto.QueQuan,
                DiaChiThuongTru = sinhVienDto.DiaChiThuongTru,
                Email = sinhVienDto.Email,
                NgayVaoTruong = sinhVienDto.NgayVaoTruong,
                SoDienThoai = sinhVienDto.SoDienThoai,
                MaLopQuanLi = sinhVienDto.MaLopQuanLi,
            };
        }

        public static SinhVienDto ToDto(SinhVien sinhVien)
        {
            return new SinhVienDto()
            {
                MaSinhVien = sinhVien.MaSinhVien,
                HoTen = sinhVien.HoTen,
                NgaySinh = sinhVien.NgaySinh,
                GioiTinh = sinhVien.GioiTinh,
                QueQuan = sinhVien.QueQuan,
                DiaChiThuongTru = sinhVien.DiaChiThuongTru,
                Email = sinhVien.Email,
                NgayVaoTruong = sinhVien.NgayVaoTruong,
                SoDienThoai = sinhVien.SoDienThoai,
                MaLopQuanLi = sinhVien.MaLopQuanLi
            };
        }
    }
}