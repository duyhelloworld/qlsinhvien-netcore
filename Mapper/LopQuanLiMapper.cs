using qlsinhvien.Dto;
using qlsinhvien.Entities;

namespace qlsinhvien.Mapper
{
    public class LopQuanLiMapper
    {
        public static LopQuanLi ToEntity(LopQuanLiDto lopQuanLiDto) {
            return new LopQuanLi() {
                MaLopQuanLi = lopQuanLiDto.MaLopQuanLi,
                TenLopQuanLi = lopQuanLiDto.TenLopQuanLi,
                MaKhoa = lopQuanLiDto.Khoa == null ? lopQuanLiDto.MaKhoa : lopQuanLiDto.Khoa.MaKhoa,
                MaGiangVien = lopQuanLiDto.GiangVien == null ? lopQuanLiDto.MaGiangVien : lopQuanLiDto.GiangVien.Value.MaGiangVien,
                Khoa = lopQuanLiDto.Khoa,
                GiangVien = new GiangVien() {
                    MaGiangVien = lopQuanLiDto.MaGiangVien,
                    HoTen = lopQuanLiDto.GiangVien?.TenGiangVien,
                    Email = lopQuanLiDto.GiangVien?.Email,
                    SoDienThoai = lopQuanLiDto.GiangVien?.SoDienThoai,
                }
            };
        }

        public static LopQuanLiDto ToDto(LopQuanLi lopQuanLi)
        {
            return new LopQuanLiDto()
            {
                MaLopQuanLi = lopQuanLi.MaLopQuanLi,
                TenLopQuanLi = lopQuanLi.TenLopQuanLi,
                Khoa = lopQuanLi.Khoa,
                MaKhoa = lopQuanLi.Khoa == null ? lopQuanLi.MaKhoa : lopQuanLi.Khoa.MaKhoa,
                MaGiangVien = lopQuanLi.GiangVien == null ? lopQuanLi.MaGiangVien : lopQuanLi.GiangVien.MaGiangVien,
                GiangVien = lopQuanLi.GiangVien == null ? null : new GiangVienContact {
                    MaGiangVien = lopQuanLi.GiangVien.MaGiangVien,
                    TenGiangVien = lopQuanLi.GiangVien.HoTen,
                    Email = lopQuanLi.GiangVien.Email,
                    SoDienThoai = lopQuanLi.GiangVien.SoDienThoai,
                }
            };
        }
    }
}