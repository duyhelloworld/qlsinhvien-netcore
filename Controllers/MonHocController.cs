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
        private readonly MonHocDbContext monHocDbConText;
        private readonly HttpClient httpClient;

        public MonHocController(MonHocDbContext monHocDbConText)
        {
            this.monHocDbConText = monHocDbConText;
            httpClient = 
        }

        [HttpGet]
        public ActionResult<ICollection<MonHoc>> GetAll()
        {
            return monHocDbConText.MonHocs.ToList();
        }

        [HttpGet("{id}")]
        public ActionResult<MonHoc> GetById(int id)
        {
            var monHoc = monHocDbConText.MonHocs.Find(id);
            return monHoc == null ? NotFound() : Ok(monHoc);
        }
        [HttpGet("{ten mon}")]
        public ActionResult<MonHoc> GetByName(string name)
        {
            var monHoc = monHocDbConText.MonHocs.Find(name);
            return monHoc == null ? NotFound() : Ok(monHoc);
        }
        [HttpGet("{khoa}")]
        public ActionResult<MonHoc> GetByKhoa(string khoa)
        {
            var monHoc = from mh in monHocDbConText.MonHocs
                         join kmh in khoaDbContext.KhoaMonHocs on mh.MaMonHoc equals kmh.MaMonHoc
                         join k in khoaDbContext.Khoas on kmh.MaKhoa equals k.MaKhoa
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

            var khoaId = monHocDbConText.Khoas.Find(khoa);
            var monHocId = monHocDbConText.MonHocs.Find(monHoc.MaMonHoc);
            if (khoaId != null)
            {
                monHocDbConText.KhoaMonHocs.Add(khoaMonHoc);
                monHocDbConText.SaveChanges();
                // return Ok(new
                // {
                //     maMonHoc = khoaMonHoc.MaMonHoc,
                //     maKhoa = khoaMonHoc.MaKhoa
                // });
                if (monHocId == null)
                {
                    monHocDbConText.MonHocs.Add(monHoc);
                    monHocDbConText.SaveChanges();
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
    }
    // [HttpPut]
    // public ActionResult UpdateMonHoc([FromBody] MonHoc monHoc, )
}