using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using qlsinhvien.Context;
using qlsinhvien.Entities;

namespace qlsinhvien.Controllers
{
    [ApiController]
    [Route("/[controller]")]
    public class SinhVienController : ControllerBase
    {
        private readonly AppQLSVContext appContext;

        public SinhVienController(AppQLSVContext appContext) {
            this.appContext = appContext;
        }

        [HttpGet]
        public ActionResult<ICollection<SinhVien>> GetAll(){
            return appContext.SinhViens.ToList();
        }

        [HttpGet("{id}")]
        public ActionResult<SinhVien> GetById(int id)
        {
            var sinhVien = appContext.SinhViens.Find(id);
            return sinhVien == null ? NotFound() : Ok(sinhVien);
        }

        [HttpGet("search")]
        public ActionResult<ICollection<SinhVien>> GetByName([FromQuery] string hoTen)
        {
            var student = from sinhVien in appContext.SinhViens
                            where sinhVien.HoTen.Contains(hoTen)
                            select sinhVien;
            return student == null ? NotFound() : Ok(student);
        }

        [HttpGet("search")]
        public ActionResult<ICollection<SinhVien>> GetByEmail([FromQuery] string email)
        {
            var student = from sinhVien in appContext.SinhViens
                          where sinhVien.Email.StartsWith(email)
                          select sinhVien;
            return student == null ? NotFound() : Ok(student);
        }

        [HttpGet("search")]
        public ActionResult<ICollection<SinhVien>> GetByNumberPhone([FromQuery] string email)
        {
            var student = from sinhVien in appContext.SinhViens
                          where sinhVien.Email.StartsWith(email)
                          select sinhVien;
            return student == null ? NotFound() : Ok(student);
        }

        [HttpPost]
        public ActionResult AddSinhVien([FromBody] SinhVien sinhVien)
        {
            if (sinhVien.MaSinhVien != 0 
                    || sinhVien.MaLopQuanLi == 0)
                return BadRequest("Chứa tham số không hợp lệ");

            var LopQuanLi = appContext.LopQuanLis.Find(sinhVien.MaLopQuanLi);
            if (LopQuanLi == null)
            {
                return NotFound("Giá trị mã lớp quản lí không hợp lệ");
            } 

            appContext.SinhViens.Add(sinhVien);
            appContext.SaveChanges();
            return Ok(new {
                maSoSinhVien = sinhVien.MaSinhVien,
                hoTen = sinhVien.HoTen,
                maLopQuanLi = sinhVien.MaLopQuanLi,
                giangVien = LopQuanLi.GiangVien.HoTen,
                khoa = LopQuanLi.Khoa
            });
        }

        [HttpPut("maSinhVien")]
        public ActionResult<SinhVien> UpdateSinhVien(int maSinhVien, [FromBody] SinhVien sinhVien)
        {
            if (maSinhVien != sinhVien.MaSinhVien)
            {
                return BadRequest();
            }
            var inDb = appContext.SinhViens.Find(maSinhVien);
            if (inDb == null)
            {
                return NotFound();
            }
            inDb = sinhVien;
            appContext.SaveChanges();
            Console.WriteLine("Updated");
            return sinhVien;
        }
    }
}