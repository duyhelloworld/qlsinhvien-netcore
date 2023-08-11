using System.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using qlsinhvien.Context;
using qlsinhvien.Entities;

namespace qlsinhvien.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SinhVienController : ControllerBase
    {
        private readonly ApplicationContext sinhVienDbContext;

        public SinhVienController(ApplicationContext sinhVienDbContext) {
            this.sinhVienDbContext = sinhVienDbContext;
        }

        [HttpGet]
        public ActionResult<IEnumerable<SinhVien>> GetAll(){
            var SinhViens =  sinhVienDbContext.SinhViens
                        .ToHashSet();
            return Ok(SinhViens);
        }

        [HttpGet("{id}")]
        public ActionResult<SinhVien> GetById(int id)
        {
            var sinhVien = sinhVienDbContext.SinhViens.Find(id);
            return sinhVien == null ? NotFound() : Ok(sinhVien);
        }

        [HttpGet("search")]
        public ActionResult<IEnumerable<SinhVien>> GetByName([FromQuery] string hoTen)
        {
            var ketQua = from sinhVien in sinhVienDbContext.SinhViens
                            where sinhVien.HoTen.Contains(hoTen)
                            select sinhVien;
            return ketQua == null ? NotFound() : Ok(ketQua);
        }

        [HttpGet("search")]
        public ActionResult<IEnumerable<SinhVien>> GetByEmail([FromQuery] string email)
        {
            var ketQua = from sinhVien in sinhVienDbContext.SinhViens
                          where sinhVien.Email.StartsWith(email)
                          select sinhVien;
            return ketQua == null ? NotFound() : Ok(ketQua);
        }

        [HttpGet("search")]
        public ActionResult<IEnumerable<SinhVien>> GetByNumberPhone([FromQuery] string soDienThoai)
        {
            var ketQua = from sinhVien in sinhVienDbContext.SinhViens
                          where sinhVien.SoDienThoai.StartsWith(soDienThoai)
                          select sinhVien;
            return ketQua == null ? NotFound() : Ok(ketQua);
        }

        [HttpPost]
        public ActionResult AddSinhVien([FromBody] SinhVien sinhVien)
        {
            if (sinhVien.MaSinhVien != 0 
                    || sinhVien.MaLopQuanLi == 0)
                return BadRequest("Chứa tham số không hợp lệ");
            
            try
            {
                var lopQuanLi = sinhVienDbContext.LopQuanLis.Find(sinhVien.MaLopQuanLi);
                if (lopQuanLi == null)
                    return BadRequest("Lớp quản lí không hợp lệ");

                sinhVienDbContext.SinhViens.Add(sinhVien);
                sinhVienDbContext.SaveChanges();

                return CreatedAtAction(
                        nameof(GetById),
                        new { maSoSinhVien = sinhVien.MaSinhVien},
                        sinhVien);
            }
            catch (HttpRequestException)
            {
                return BadRequest();
            }
        }

        [HttpPut("{maSinhVien}")]
        public ActionResult<SinhVien> UpdateSinhVien(int maSinhVien,  [FromBody] SinhVien sinhVien)
        {
            if (maSinhVien == 0)
            {
                return BadRequest("Tham số không hợp lệ");
            }
            // Bỏ qua giá trị sinhVien.MaSinhVien
            sinhVien.MaSinhVien = maSinhVien;
            
            var inDb = sinhVienDbContext.SinhViens
                .Include(s => s.LopQuanLi)
                .FirstOrDefault(s => s.MaSinhVien == maSinhVien);
            if (inDb == null)
            {
                return NotFound("Không tồn tại sinh viên mã số " + maSinhVien);
            }
            try
            {
                // Cách update 1 : bỏ kết nối của inDb
                sinhVienDbContext.Entry(inDb).State = EntityState.Detached;
                sinhVienDbContext.Entry(sinhVien).State = EntityState.Modified;
                sinhVienDbContext.SaveChanges();
            }
            catch (DbUpdateException)
            {
                // Vi phạm khoá chính khoá phụ
                return BadRequest("Vi phạm điều kiện tham số. Chi tiết tại blabla.com"); 
            }
            return sinhVien;
        }

        [HttpDelete("{maSinhVien}")]
        public ActionResult RemoveSinhVien(int maSinhVien)
        {
            var inDb = sinhVienDbContext.SinhViens
                .Include(s => s.LopQuanLi)
                .FirstOrDefault(s => s.MaSinhVien == maSinhVien);
            if (inDb == null)
            {
                return NotFound("Không tồn tại sinh viên mã số " + maSinhVien);
            }

            sinhVienDbContext.SinhViens.Remove(inDb);
            var diems = from dsv in sinhVienDbContext.DiemSinhViens
                        where dsv.MaSinhVien == maSinhVien
                        select dsv;
            sinhVienDbContext.DiemSinhViens.RemoveRange(diems);
            sinhVienDbContext.SaveChanges();
            return NoContent();
        }
    }
}