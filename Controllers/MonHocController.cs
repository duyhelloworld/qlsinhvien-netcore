using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using qlsinhvien.Context;
using qlsinhvien.Entities;

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
        [HttpGet("name={name}")]
        public ActionResult<MonHoc> GetByName([FromQuery] string name)
        {
            var monHoc = appContext.MonHocs.Find(name);
            return monHoc == null ? NotFound() : Ok(monHoc);
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