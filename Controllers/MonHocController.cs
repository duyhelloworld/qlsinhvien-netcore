using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using qlsinhvien.Context;
using qlsinhvien.Entities;
using qlsinhvien.Controllers;

namespace qlsinhvien.Controllers
{
    [ApiController]
    [Route("/[controller]")]
    public class MonHocController : ControllerBase
    {
        private readonly ApplicationContext appContext;

        public MonHocController(ApplicationContext appContext)
        {
            this.appContext = appContext;
        }

        [HttpGet]
        public ActionResult<ICollection<MonHoc>> GetAll()
        {
            return appContext.MonHocs.ToList();
        }

        [HttpGet("{id}")]
        public ActionResult<MonHoc> GetById(int id)
        {
            var monHoc = appContext.MonHocs.Find(id);
            return monHoc == null ? NotFound() : Ok(monHoc);
        }
        [HttpGet]
        public ActionResult<MonHoc> GetByName([FromQuery] string name)
        {
            var monHoc = appContext.MonHocs.Find(name);
            return monHoc == null ? NotFound() : Ok(monHoc);
        }
        // [HttpGet("{khoa}")]
        public ActionResult<MonHoc> GetByKhoa(string khoa)
        {
            var monHoc = from mh in appContext.MonHocs
                         join kmh in appContext.KhoaMonHocs on mh.MaMonHoc equals kmh.MaMonHoc
                         join k in appContext.Khoas on kmh.MaKhoa equals k.MaKhoa
                         where k.TenKhoa.Contains(khoa)
                         select new
                         {
                             mh.MaMonHoc,
                             mh.TenMonHoc,
                             mh.SoTinChi,
                             mh.BatBuoc,
                             mh.MonTienQuyet,
                             k.TenKhoa,
                             mh.MoTa
                         };
            return monHoc == null ? NotFound() : Ok(monHoc);
        }
        [HttpPost]
        public ActionResult AddMonHoc([FromBody] KhoaMonHoc khoaMonHoc)
        {
            MonHoc monHoc = khoaMonHoc.MonHoc;
            Khoa khoa = khoaMonHoc.Khoa;

            var khoaId = appContext.Khoas.Find(khoa);
            var monHocId = appContext.MonHocs.Find(monHoc.MaMonHoc);
            if (khoaId != null)
            {
                appContext.KhoaMonHocs.Add(khoaMonHoc);
                appContext.SaveChanges();
                // return Ok(new
                // {
                //     maMonHoc = khoaMonHoc.MaMonHoc,
                //     maKhoa = khoaMonHoc.MaKhoa
                // });
                if (monHocId == null)
                {
                    appContext.MonHocs.Add(monHoc);
                    appContext.SaveChanges();
                    return Ok(new
                    {
                        maMonHoc = monHoc.MaMonHoc,
                        tenMonHoc = monHoc.TenMonHoc,
                        soTinChi = monHoc.SoTinChi,
                        batBuoc = monHoc.BatBuoc,
                        monTienQuyet = monHoc.MonTienQuyet,
                        // khoa = Khoa.Khoa,
                        moTa = monHoc.MoTa
                    });
                }
                else
                {
                    return BadRequest("Môn học đã tồn tại trong cơ sở dữ liệu.");
                }
            }
            else
            {
                return BadRequest("Khoa không hợp lệ.");
            }
        }
        [HttpPut("{id}")]
        public ActionResult UpdateMonHoc(int id, [FromBody] MonHoc monHoc)
        {
            var mon = appContext.MonHocs.Find(id);
            if (mon == null)
            {
                return NotFound();
            }

            mon.TenMonHoc = monHoc.TenMonHoc;
            mon.SoTinChi = monHoc.SoTinChi;
            mon.BatBuoc = monHoc.BatBuoc;
            mon.MonTienQuyet = monHoc.MonTienQuyet;
            mon.MoTa = monHoc.MoTa;

            appContext.MonHocs.Update(mon);
            appContext.SaveChanges();

            return Ok(mon);
        }
        [HttpDelete("{id}")]
        public ActionResult DeleteMonHoc(int id)
        {
            var monHoc = appContext.MonHocs.Find(id);
            if (monHoc == null)
            {
                return NotFound();
            }
            appContext.MonHocs.Remove(monHoc);
            appContext.SaveChanges();

            return Ok(new
            {
                message = "Xóa môn học thành công.",
                maMonHoc = monHoc.MaMonHoc,
                tenMonHoc = monHoc.TenMonHoc,
                soTinChi = monHoc.SoTinChi,
                batBuoc = monHoc.BatBuoc,
                monTienQuyet = monHoc.MonTienQuyet,
                moTa = monHoc.MoTa
            });
        }
    }
}