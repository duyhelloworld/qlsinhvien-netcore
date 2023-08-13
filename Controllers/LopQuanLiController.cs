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

        [HttpGet("all")]
        public ActionResult GetAll() {
            return Ok(lopQuanLiDbContext.LopQuanLis.ToList());
        }

        [HttpGet]
        public ActionResult GetByName([FromQuery] string TenLopQuanLi)
        {
            var ketQua = from lql in lopQuanLiDbContext.LopQuanLis
                where lql.TenLopQuanLi.Contains(TenLopQuanLi)
                select lql;
            return ketQua.Count() == 0 ? NotFound() : Ok(ketQua);
        }

        [HttpGet("{MaLopQuanLi}")]
        public ActionResult<LopQuanLi> GetById(int MaLopQuanLi)
        {
            var ketQua = lopQuanLiDbContext.LopQuanLis
                .Find(MaLopQuanLi);
            return ketQua == null ? NotFound() : Ok(ketQua);
        }

        [HttpPost]
        public ActionResult AddLopQL([FromBody] LopQuanLi LopQuanLi)
        {
            if (LopQuanLi.MaLopQuanLi != 0)
            {
                return BadRequest();
            }
            // try
            // {
                lopQuanLiDbContext.LopQuanLis.Add(LopQuanLi);
                lopQuanLiDbContext.SaveChanges();
                return Created(nameof(GetById), LopQuanLi);
            // }
            // catch (DbUpdateException e)
            // {
            //     Console.WriteLine(e.Message);
            //     return BadRequest();
            // }
        }

        [HttpGet("info")]
        public ActionResult GetBasicInfo()
        {
            // Lấy khoa, giảng viên
            var joinedResult = lopQuanLiDbContext.LopQuanLis
                                .Include(l => l.Khoa)
                                .Include(l => l.GiangVien)
                                .ToList();
            // Lấy sĩ số
            var groupByResult = from l in joinedResult
                                join s in lopQuanLiDbContext.SinhViens
                                    on l.MaLopQuanLi equals s.MaLopQuanLi
                                group l by l.MaLopQuanLi into grouped
                                let lql = grouped.First()
                                select new LopQuanLi()
                                {
                                    MaLopQuanLi = lql.MaLopQuanLi,
                                    TenLopQuanLi = lql.TenLopQuanLi,
                                    GiangVien = lql.GiangVien,
                                    Khoa = lql.Khoa,
                                    MaKhoa = lql.Khoa.MaKhoa,
                                    MaGiangVien = lql.GiangVien.MaGiangVien,
                                    SiSo = grouped.Count()
                                };
            return groupByResult == null ? NotFound() : Ok(groupByResult);
        }
    }
}
