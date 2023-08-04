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
        private readonly AppQLSVContext appContext;
        // private readonly HttpClient httpClient;

        public MonHocController(AppQLSVContext appContext)
        // , IHttpClientFactory httpClientFactory)
        {
            this.appContext = appContext;
            // httpClient = httpClientFactory.CreateClient();
            // httpClient.BaseAddress = new Uri("http://localhost:5277");
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
        // [HttpGet("{name}")]
        public ActionResult<MonHoc> GetByName(string name)
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
            // Tìm môn học trong cơ sở dữ liệu dựa vào id
            var existingMonHoc = appContext.MonHocs.Find(id);
            if (existingMonHoc == null)
            {
                return NotFound(); // Trả về 404 Not Found nếu không tìm thấy môn học với id tương ứng
            }

            // Cập nhật thông tin môn học với dữ liệu mới từ monHoc
            existingMonHoc.TenMonHoc = monHoc.TenMonHoc;
            existingMonHoc.SoTinChi = monHoc.SoTinChi;
            existingMonHoc.BatBuoc = monHoc.BatBuoc;
            existingMonHoc.MonTienQuyet = monHoc.MonTienQuyet;
            existingMonHoc.MoTa = monHoc.MoTa;

            appContext.MonHocs.Update(existingMonHoc); // Cập nhật môn học trong cơ sở dữ liệu
            appContext.SaveChanges(); // Lưu các thay đổi vào cơ sở dữ liệu

            return Ok(existingMonHoc); // Trả về môn học sau khi cập nhật thành công
        }
    }

}