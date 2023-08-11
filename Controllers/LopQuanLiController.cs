using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using qlsinhvien.Context;
using qlsinhvien.Entities;

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
        public ActionResult<IEnumerable<LopQuanLi>> GetAll()
        {
            var ketQua = lopQuanLiDbContext.LopQuanLis
                        .ToHashSet();
            return ketQua == null ? NotFound() : Ok(ketQua);
        }

        [HttpGet("{MaLopQuanLi}")]
        public ActionResult<LopQuanLi> GetById(int MaLopQuanLi)
        {
            var ketQua = lopQuanLiDbContext.LopQuanLis
                .FirstOrDefault(l => l.MaLopQuanLi == MaLopQuanLi);
            return ketQua == null ? NotFound() : Ok(ketQua);
        }

        [HttpGet("s")]
        public ActionResult<IEnumerable<LopQuanLi>> GetByName([FromQuery] string tenlop)
        {
            var ketQua = from lql in lopQuanLiDbContext.LopQuanLis
                where lql.TenLopQuanLi.Contains(tenlop)
                select lql;
            return ketQua == null ? NotFound() : Ok(ketQua);
        }

        [HttpPost]
        public ActionResult AddLopQL([FromBody] LopQuanLi LopQuanLi)
        {
            if (LopQuanLi.MaLopQuanLi != 0)
            {
                return BadRequest();
            }
            try
            {
                lopQuanLiDbContext.LopQuanLis.Add(LopQuanLi);
                lopQuanLiDbContext.SaveChanges();
                return Created(nameof(GetById), LopQuanLi);
            }
            catch (DbUpdateException e)
            {
                Console.WriteLine(e.Message);
                return BadRequest("Lỗi");
            }
        }

        [HttpGet("info")]
        public ActionResult GetBasicInfo()
        {
            // Lấy tên khoa, tên giảng viên
            var joinedResult = from lopQuanLi in lopQuanLiDbContext.LopQuanLis
                        join giangVien in lopQuanLiDbContext.GiangViens
                            on lopQuanLi.MaGiangVien equals giangVien.MaGiangVien
                        join khoa in lopQuanLiDbContext.Khoas
                            on lopQuanLi.MaKhoa equals khoa.MaKhoa
                        select new {
                            lopQuanLi.MaLopQuanLi,
                            lopQuanLi.TenLopQuanLi,
                            giangVien,
                            khoa
                        };
            // Lấy sĩ số
            var groupByResult = from l in joinedResult
                                join s in lopQuanLiDbContext.SinhViens
                                    on l.MaLopQuanLi equals s.MaLopQuanLi
                                group l by l.MaLopQuanLi into grouped
                                select new LopQuanLi()
                                {
                                    MaLopQuanLi = grouped.First().MaLopQuanLi,
                                    TenLopQuanLi = grouped.First().TenLopQuanLi,
                                    GiangVien = grouped.First().giangVien,
                                    Khoa = grouped.First().khoa,
                                    SiSo = grouped.Count()
                                };
            return groupByResult == null ? NotFound() : Ok(groupByResult);
        }


    }
}
