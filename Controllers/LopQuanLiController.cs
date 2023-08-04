using Microsoft.AspNetCore.Mvc;
using qlsinhvien.Context;
using qlsinhvien.Dto;
using qlsinhvien.Entities;
using qlsinhvien.Mapper;

namespace qlsinhvien.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LopQuanLiController : ControllerBase
    {
        private readonly ApplicationContext lopQuanLiDbContext;

        public LopQuanLiController(ApplicationContext lopQuanLiDbContext)
        {
            this.lopQuanLiDbContext = lopQuanLiDbContext;
        }

        [HttpGet]
        public ActionResult<IEnumerable<LopQuanLiDto>> GetAll()
        {
            var ketQua = 
                        // Lấy sĩ số
                        from l in lopQuanLiDbContext.LopQuanLis
                        join s in lopQuanLiDbContext.SinhViens
                            on l.MaLopQuanLi equals s.MaLopQuanLi
                        group s by s.MaLopQuanLi into sv
                        let siSo = sv.Count()
                        // Lấy tên khoa, tên giảng viên
                        from lopQuanLi in lopQuanLiDbContext.LopQuanLis
                        join giangVien in lopQuanLiDbContext.GiangViens
                            on lopQuanLi.MaGiangVien equals giangVien.MaGiangVien
                        join khoa in lopQuanLiDbContext.Khoas
                            on lopQuanLi.MaKhoa equals khoa.MaKhoa
                         select LopQuanLiMapper.ToDto(new LopQuanLi() {
                            MaLopQuanLi = lopQuanLi.MaLopQuanLi,
                            TenLopQuanLi = lopQuanLi.TenLopQuanLi,
                            GiangVien = giangVien,
                            Khoa = khoa,
                            MaGiangVien = giangVien.MaGiangVien,
                            MaKhoa = khoa.MaKhoa,
                            SiSo = siSo
                        });
            return ketQua == null ? NotFound() : Ok(ketQua);
        }
        
        [HttpGet("{MaLopQuanLi}")]
        public ActionResult<LopQuanLiDto> GetById(int MaLopQuanLi)
        {
            var ketQua = lopQuanLiDbContext.LopQuanLis
                .FirstOrDefault(l => l.MaLopQuanLi == MaLopQuanLi);
            Console.WriteLine($"Searched : {ketQua.GiangVien} {ketQua.Khoa}");
            return ketQua == null ? NotFound() : Ok(LopQuanLiMapper.ToDto(ketQua));
        }
    }
}