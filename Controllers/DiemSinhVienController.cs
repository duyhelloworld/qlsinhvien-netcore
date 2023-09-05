using Microsoft.AspNetCore.Mvc;
using qlsinhvien.Dto;
using qlsinhvien.Entities;
using qlsinhvien.Services;

namespace qlsinhvien.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DiemSinhVienController : ControllerBase
    {
        private readonly IDiemSinhVienService _service;
        public DiemSinhVienController(IDiemSinhVienService service)
        {
            _service = service;
        }

        [HttpGet("{masinhvien}")]
        public async Task<IEnumerable<DiemSinhVienModel>> GetById(int masinhvien)
        {
            return await _service.GetByIdAsync(masinhvien);
        }

        [HttpGet("malopmonhoc")]
        public async Task<IEnumerable<DiemSinhVienModel>> GetByLopMonHoc(int malopmonhoc)
        {
            return await _service.GetByLopMonHocAsync(malopmonhoc);
        }

        [HttpGet("malopquanli")]
        public async Task<IEnumerable<DiemSinhVienModel>> GetByLopQuanLi(int malopquanli)
        {
            return await _service.GetByLopQuanLiAsync(malopquanli);
        }

        [HttpPut("{masinhvien}")]
        public async Task<IActionResult> UpdateDiemSinhVien(int masinhvien, [FromBody] DiemSinhVienDto diemSinhVien)
        {
            var diem = await _service.UpdateAsync(masinhvien, diemSinhVien);
            return Ok(diem);
        }

        [HttpPut("{malopmonhoc}")]
        public async Task<IActionResult> UpdateDiemSinhVienTheoLopMonHoc(int malopmonhoc, [FromBody] DiemSinhVienDto diemSinhVien)
        {
            var diem = await _service.UpdateTheoLopMonHoc(malopmonhoc, diemSinhVien);
            return Ok(diem);
        }

        [HttpDelete("{masinhvien}")]
        public async Task DeleteDiemSinhVien(int masinhvien, DiemSinhVienDto diemSinhVienDto)
        {
            await _service.RemoveAsync(masinhvien, diemSinhVienDto);
        }

        [HttpDelete("{malopmonhoc}")]
        public async Task DeleteDiemSinhVienTheoLopMonHoc(int malopmonhoc, DiemSinhVienDto diemSinhVienDto)
        {
            await _service.RemoveTheoLopMonHoc(malopmonhoc, diemSinhVienDto);
        }
    }
}