using Microsoft.AspNetCore.Mvc;
using qlsinhvien.Atributes;
using qlsinhvien.Dto;
using qlsinhvien.Entities;
using qlsinhvien.Services;

namespace qlsinhvien.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SinhVienController : ControllerBase
    {
        private readonly ISinhVienService _service;

        public SinhVienController(ISinhVienService service) {
            _service = service;
        }

        [HttpGet("tatca")]
        [PhanQuyen(EQuyen.XemTatCa_SinhVien)]
        public async Task<IEnumerable<SinhVien>> GetAll()
        {
            return await _service.GetAll();
        }

        [HttpGet]
        [PhanQuyen(EQuyen.XemBanThan_SinhVien)]
        public async Task<ActionResult<SinhVien>> GetSelf()
        {
            var phanQuyen = (HttpContext.Items["PhanQuyen"] as PhanQuyen)!;
            var kq = await _service.GetById(phanQuyen.MaNguoiDung);
            return kq == null ? NotFound() : Ok(kq);
        }

        [HttpGet("{maSoSinhVien}")]
        [PhanQuyen(TenQuyen: EQuyen.XemTheoMa_SinhVien)]
        public async Task<ActionResult<SinhVien>> GetById(int maSoSinhVien)
        {
            var kq = await _service.GetById(maSoSinhVien);
            return kq == null ? NotFound() : Ok(kq);
        }

        [HttpGet("lopquanli/{malopquanli:int:min(1)}")]
        public async Task<IEnumerable<SinhVien>> GetByLopQuanLi(int malopquanli)
        {
            return await _service.GetByLopQuanLi(malopquanli);
        }

        [HttpGet("lopmonhoc/{malopmonhoc:int:min(1)}")]
        public async Task<IEnumerable<SinhVien>> GetByLopMonHoc(int malopmonhoc)
        {
            return await _service.GetByLopMonHoc(malopmonhoc);
        }

        [HttpGet("hoten")]
        public async Task<IEnumerable<SinhVien>> GetByName([FromQuery] string hoTen)
        {
            return await _service.GetByHoTen(hoTen);
        }

        [HttpPost]
        public async Task<SinhVien> AddSinhVien([FromBody] SinhVienDto sinhVienDto)
        {
            return await _service.AddNew(sinhVienDto);
        }

        [HttpPut("{maSoSinhVien:int:min(1)}")]
        public async Task<SinhVien> Update(int maSinhVien,  [FromBody] SinhVienDto sinhVienDto)
        {
            return await _service.UpdateProfile(maSinhVien, sinhVienDto);
        }

        [HttpDelete("{maSinhVien}")]
        public async Task RemoveSinhVien(int maSinhVien)
        {
            await _service.Remove(maSinhVien);
        }
    }
}