using System.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using qlsinhvien.Context;
using qlsinhvien.Dto;
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
            return Ok(sinhVienDbContext.SinhViens.ToList());
        }

        [HttpGet("{id}")]
        public ActionResult<SinhVien> GetById(int id)
        {
            var sinhVien = sinhVienDbContext.SinhViens.Find(id);
            return sinhVien == null ? NotFound() : Ok(sinhVien);
        }

        [HttpGet("hoten")]
        public ActionResult<IEnumerable<SinhVien>> GetByName([FromQuery] string hoTen)
        {
            var ketQua = from sinhVien in sinhVienDbContext.SinhViens
                            where sinhVien.HoTen.Contains(hoTen)
                            select sinhVien;
            return ketQua == null ? NotFound() : Ok(ketQua);
        }

        [HttpGet("email")]
        public ActionResult<IEnumerable<SinhVien>> GetByEmail([FromQuery] string email)
        {
            var ketQua = from sinhVien in sinhVienDbContext.SinhViens
                          where sinhVien.Email.Contains(email)
                          select sinhVien;
            return ketQua == null ? NotFound() : Ok(ketQua);
        }

        [HttpGet("sodienthoai")]
        public ActionResult<IEnumerable<SinhVien>> GetByNumberPhone([FromQuery] string soDienThoai)
        {
            var ketQua = from sinhVien in sinhVienDbContext.SinhViens
                          where sinhVien.SoDienThoai.StartsWith(soDienThoai)
                          select sinhVien;
            return ketQua == null ? NotFound() : Ok(ketQua);
        }

        [HttpPost]
        public ActionResult AddSinhVien([FromBody] SinhVienDto sinhVienDto)
        {
            if (sinhVienDto.MaSinhVien != 0 
                    || sinhVienDto.MaLopQuanLi <= 0)
                return BadRequest("Chứa tham số không hợp lệ");

            var lopQuanLi = sinhVienDbContext.LopQuanLis.Find(sinhVienDto.MaLopQuanLi);
            if (lopQuanLi == null)
                return BadRequest("Lớp quản lí không hợp lệ");
                
            var sinhVien = new SinhVien() {
                HoTen = sinhVienDto.HoTen,
                GioiTinh = sinhVienDto.GioiTinh,
                NgaySinh = sinhVienDto.NgaySinh,
                QueQuan = sinhVienDto.QueQuan,
                DiaChiThuongTru = sinhVienDto.DiaChiThuongTru,
                NgayVaoTruong = sinhVienDto.NgayVaoTruong,
                SoDienThoai = sinhVienDto.SoDienThoai,
                Email = sinhVienDto.Email,
                LopQuanLi = lopQuanLi
            };
            try
            {
                sinhVienDbContext.SinhViens.Add(sinhVien);
                sinhVienDbContext.SaveChanges();
                return CreatedAtAction(
                        nameof(GetById),
                        new { maSoSinhVien = sinhVien.MaSinhVien},
                        sinhVien); 
            }
            catch (DbUpdateException ex)
            {
                var errmsg = ex.InnerException.Message;
                if (errmsg.Contains("Email"))
                {
                    return BadRequest("Email này đã được sử dụng");
                } else if (errmsg.Contains("SoDienThoai")) {
                    return BadRequest("Số điện thoại này đã được sử dụng");
                }
                throw;
            }           
        }

        [HttpPut("{maSinhVien}")]
        public ActionResult<SinhVien> UpdateSinhVien(int maSinhVien,  [FromBody] SinhVienDto sinhVienDto)
        {
            if (maSinhVien <= 0)
            {
                return BadRequest("Tham số không hợp lệ");
            }
            sinhVienDto.MaSinhVien = maSinhVien;
            var lopQuanLi = sinhVienDbContext.LopQuanLis.Find(sinhVienDto.MaLopQuanLi);
            if (lopQuanLi == null)
                return BadRequest("Lớp quản lí không hợp lệ");

            var inDb = sinhVienDbContext.SinhViens.Find(maSinhVien);
            if (inDb == null)
            {
                return NotFound("Không tồn tại sinh viên mã số " + maSinhVien);
            }
            // Cách 1 : bỏ kết nối của inDb, tạo 1 sinhVien mới với dữ liệu của dto (như [post])
            // sinhVienDbContext.Entry(inDb).State = EntityState.Detached;
            // sinhVienDbContext.Entry(sinhVien).State = EntityState.Modified;

            // Cách 2 :  
            inDb.HoTen = sinhVienDto.HoTen;
            inDb.GioiTinh = sinhVienDto.GioiTinh;
            inDb.NgaySinh = sinhVienDto.NgaySinh;
            inDb.QueQuan = sinhVienDto.QueQuan;
            inDb.DiaChiThuongTru = sinhVienDto.DiaChiThuongTru;
            inDb.NgayVaoTruong = sinhVienDto.NgayVaoTruong;
            inDb.SoDienThoai = sinhVienDto.SoDienThoai;
            inDb.Email = sinhVienDto.Email;
            inDb.LopQuanLi = lopQuanLi;
            sinhVienDbContext.SaveChanges();
            return inDb;
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