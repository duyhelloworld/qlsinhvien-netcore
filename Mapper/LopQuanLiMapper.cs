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
                MaKhoa = lopQuanLiDto.MaKhoa,
                MaGiangVien = lopQuanLiDto.MaGiangVien
            };
        }

        public static LopQuanLiDto ToDto(LopQuanLi lopQuanLi)
        {
            return new LopQuanLiDto()
            {
                MaLopQuanLi = lopQuanLi.MaLopQuanLi,
                TenLopQuanLi = lopQuanLi.TenLopQuanLi,
                MaKhoa = lopQuanLi.MaKhoa,
                MaGiangVien = lopQuanLi.MaGiangVien
            };
        }
    }
}