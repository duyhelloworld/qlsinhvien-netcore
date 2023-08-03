using Microsoft.AspNetCore.Mvc;
using qlsinhvien.Context;
using qlsinhvien.Dto;
using qlsinhvien.Entities;
using qlsinhvien.Mapper;

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
        public ActionResult<IEnumerable<SinhVienDto>> GetAll(){
            var sinhVienDtos =  from sinhVien in appContext.SinhViens.ToList()
                    select SinhVienMapper.ToDto(sinhVien);
            return Ok(sinhVienDtos);
        }

        [HttpGet("{id}")]
        public ActionResult<SinhVien> GetById(int id)
        {
            var sinhVien = appContext.SinhViens.Find(id);
            return sinhVien == null ? NotFound() : Ok(sinhVien);
        }

        [HttpGet("search")]
        public ActionResult<ICollection<SinhVienDto>> GetByName([FromQuery] string hoTen)
        {
            var ketQua = from sinhVien in appContext.SinhViens
                            where sinhVien.HoTen.Contains(hoTen)
                            select SinhVienMapper.ToDto(sinhVien);
            return ketQua == null ? NotFound() : Ok(ketQua);
        }

        [HttpGet("search")]
        public ActionResult<ICollection<SinhVien>> GetByEmail([FromQuery] string email)
        {
            var ketQua = from sinhVien in appContext.SinhViens
                          where sinhVien.Email.StartsWith(email)
                          select SinhVienMapper.ToDto(sinhVien);
            return ketQua == null ? NotFound() : Ok(ketQua);
        }

        [HttpGet("search")]
        public ActionResult<ICollection<SinhVienDto>> GetByNumberPhone([FromQuery] string email)
        {
            var ketQua = from sinhVien in appContext.SinhViens
                          where sinhVien.Email.StartsWith(email)
                          select SinhVienMapper.ToDto(sinhVien);
            return ketQua == null ? NotFound() : Ok(ketQua);
        }

        [HttpPost]
        public ActionResult AddSinhVien([FromBody] SinhVienDto sinhVienDto)
        {
            var sinhVien = SinhVienMapper.ToEntity(sinhVienDto);
            if (sinhVien.MaSinhVien != 0 
                    || sinhVien.MaLopQuanLi == 0)
                return BadRequest("Chứa tham số không hợp lệ");

            var LopQuanLi = appContext.LopQuanLis.Find(sinhVien.MaLopQuanLi);
            if (LopQuanLi == null)
            {
                return BadRequest("Giá trị mã lớp quản lí không hợp lệ");
            }

            appContext.SinhViens.Add(sinhVien);
            appContext.SaveChanges();
            return Ok(new {
                maSoSinhVien = sinhVien.MaSinhVien,
                hoTen = sinhVien.HoTen,
                maLopQuanLi = sinhVien.MaLopQuanLi,
                tenLopQuanLi = LopQuanLi.TenLopQuanLi,
                giaoVienChuNhiem = LopQuanLi.GiangVien?.HoTen,
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