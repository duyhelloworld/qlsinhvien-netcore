using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using qlsinhvien.Atributes;
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

        [HttpGet("tatca")]
        [PhanQuyen(EQuyen.XemTatCa_LopQuanLi)]
        public ActionResult GetAll() {
            var ketQua = lopQuanLiDbContext.LopQuanLis
                            .Include(l => l.Khoa)
                            .Include(l => l.GiangVien)
                            .Select(lql => new
                            {
                                lql.MaLopQuanLi,
                                lql.TenLopQuanLi,
                                GiangVien = new
                                {
                                    lql.GiangVien!.MaGiangVien,
                                    lql.GiangVien.HoTen,
                                    lql.GiangVien.SoDienThoai,
                                    lql.GiangVien.Email,
                                    lql.GiangVien.BoMon.TenBoMon
                                },
                                Khoa = new
                                {
                                    lql.Khoa.MaKhoa,
                                    lql.Khoa.TenKhoa
                                }
                            });
            return Ok(ketQua);
        }

        [HttpGet]
        public ActionResult GetByName([FromQuery] string tenLopQuanLi)
        {
            var ketQua = from lql in lopQuanLiDbContext.LopQuanLis
                // join khoa in lopQuanLiDbContext.Khoas
                    // on lql.MaKhoa equals khoa.MaKhoa
                join giangvien in lopQuanLiDbContext.GiangViens
                    on lql.GiangVien!.MaGiangVien equals giangvien.MaGiangVien
                where lql.TenLopQuanLi.Contains(tenLopQuanLi)
                select new {
                    lql.MaLopQuanLi,
                    lql.TenLopQuanLi,
                    GiangVien = new
                    {
                        lql.GiangVien!.MaGiangVien,
                        lql.GiangVien.HoTen,
                        lql.GiangVien.SoDienThoai,
                        lql.GiangVien.Email,
                        lql.GiangVien.BoMon.TenBoMon,
                    },
                    Khoa = new
                    {
                        lql.Khoa.MaKhoa,
                        lql.Khoa.TenKhoa
                    }
                };
            return ketQua.Count() == 0 ? NotFound() : Ok(ketQua);
        }

        [HttpGet("{malop}")]
        public ActionResult<LopQuanLi> GetById(int malop)
        {
            var ketQua = lopQuanLiDbContext.LopQuanLis
                .Find(malop);
            return ketQua == null ? NotFound() : Ok(
                                new {
                                    ketQua.MaLopQuanLi,
                                    ketQua.TenLopQuanLi,
                                    ketQua.GiangVien,
                                    Khoa = new
                                    {
                                        ketQua.Khoa.MaKhoa,
                                        ketQua.Khoa
                                    }});
        }

        [HttpGet("siso")]
        public ActionResult GetAllWithSiSo()
        {
            // Lấy khoa, giảng viên
            var joinedResult = lopQuanLiDbContext.LopQuanLis
                                .Include(l => l.Khoa)
                                .Include(l => l.GiangVien)
                                .ToList();
            // Lấy sĩ số
            var groupByResult = from l in joinedResult
                                join s in lopQuanLiDbContext.SinhViens
                                    on l.MaLopQuanLi equals s.LopQuanLi.MaLopQuanLi
                                group l by l.MaLopQuanLi into grouped
                                let lql = grouped.FirstOrDefault()
                                select new 
                                {
                                    lql.MaLopQuanLi,
                                    lql.TenLopQuanLi,
                                    lql.GiangVien,
                                    lql.Khoa,
                                    SiSo = grouped.Count()
                                };
            return groupByResult == null ? NotFound() : Ok(groupByResult);
        }

        [HttpPost]
        public ActionResult AddLopQL([FromBody] LopQuanLi lopQuanLi)
        {
            // Bắt buộc khi thêm phải có : tên lớp, mã khoa
            if (lopQuanLi.MaLopQuanLi != 0 || lopQuanLi.Khoa.MaKhoa == 0)
            {
                return BadRequest("Thiếu mã khoa; mã lql phải = 0");
            }
            var khoa = lopQuanLiDbContext.Khoas.Find(lopQuanLi.Khoa.MaKhoa);
            if (khoa == null)
            {
                return NotFound($"{nameof(Khoa)} {lopQuanLi.Khoa.MaKhoa}");
            }
            if (lopQuanLi.GiangVien!.MaGiangVien != 0)
            {
                var giangVien = lopQuanLiDbContext.GiangViens.Find(lopQuanLi.GiangVien.MaGiangVien);
                if (giangVien == null)
                {
                    return NotFound($"{nameof(GiangVien)} {lopQuanLi.GiangVien.MaGiangVien}");
                }
                // giảng viên khoa này phải chủ nhiệm lớp thuộc khoa đó
                // if (giangVien.BoMon. != lopQuanLi.Khoa.MaKhoa)
                // {
                    // return BadRequest("Not match");
                // }
            }
            lopQuanLiDbContext.LopQuanLis.Add(lopQuanLi);
            lopQuanLiDbContext.SaveChanges();
            return Created(nameof(GetById), lopQuanLi);
        }

        [HttpPut]
        public ActionResult UpdateLopQL([FromBody] LopQuanLi lopQuanLi) {
            if (lopQuanLi.MaLopQuanLi != 0) {
                return BadRequest();
            }
            var inDb = lopQuanLiDbContext.LopQuanLis.Find(lopQuanLi.MaLopQuanLi);
            if (inDb == null) {
                return NotFound();                
            }
            inDb.TenLopQuanLi = lopQuanLi.TenLopQuanLi;
            // inDb.MaKhoa = lopQuanLi.MaKhoa;
            // inDb.MaGiangVien = lopQuanLi.MaGiangVien;
            lopQuanLiDbContext.SaveChanges();
            return Ok(inDb);
        }

        [HttpDelete("{malop}")]
        public ActionResult RemoveLopQL(int malop) {
            var inDb = lopQuanLiDbContext.LopQuanLis.Find(malop);
            if (inDb == null) {
                return NotFound();
            }   
            lopQuanLiDbContext.LopQuanLis.Remove(inDb);
            lopQuanLiDbContext.SaveChanges();
            return Ok();
        }

        [HttpDelete]
        public ActionResult RemoveLopQLByRange([FromBody] List<int> malops)
        {
            var lopQuanLis = new List<LopQuanLi>();
            foreach (var malop in malops)
            {
                var inDb = lopQuanLiDbContext.LopQuanLis.Find(malop);
                if (inDb != null) {
                    lopQuanLis.Add(inDb);
                }
            }
            lopQuanLiDbContext.LopQuanLis.RemoveRange(lopQuanLis);
            lopQuanLiDbContext.SaveChanges();
            return Ok();
        }
    }
}
