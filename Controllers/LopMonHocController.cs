using Microsoft.AspNetCore.Mvc;
using qlsinhvien.Context;
using qlsinhvien.Dto;
using qlsinhvien.Entities;
using qlsinhvien.Services;

namespace qlsinhvien.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LopMonHocController : ControllerBase
    {
        private readonly ILopMonHocService _service;
        public LopMonHocController(ILopMonHocService service)
        {
            _service = service;
        }
        
        [HttpGet("{maLopMonHoc}")]
        public async Task<LopMonHoc> GetById(int maLopMonHoc)
        {
            return await _service.GetByIdAsync(maLopMonHoc);
        }
        [HttpGet("{magiangvien}")]
        public async Task<IEnumerable<LopMonHoc>> GetByGiangVien(int magiangvien)
        {
            return await _service.GetByGiangVienAsync(magiangvien);
        }
        [HttpGet("tatca")]
        public async Task<IEnumerable<LopMonHoc>> GetAll()
        {
            return await _service.GetAllAsync();
        }
        [HttpPost]
        public async Task<LopMonHoc> AddNew(LopMonHocDto lopMonHocDto)
        {
            return await _service.AddNewAsync(lopMonHocDto);
        }
        [HttpGet("{tenlopmonhoc}")]
        public async Task<IEnumerable<LopMonHoc>> GetByTen(string tenLopMonHoc)
        {
            return await _service.GetByTenAsync(tenLopMonHoc);
        }
        [HttpDelete("{mamonhoc}")]
        public async Task RemoveTheoMonHoc(int maMonHoc)
        {
            await _service.RemoveTheoMonHoc(maMonHoc);
        }
        [HttpDelete("{malopmonhoc}")]
        public async Task Remove(int maLopMonHoc)
        {
            await _service.RemoveAsync(maLopMonHoc);
        }
        [HttpPut]
        public async Task<LopMonHoc> UpdateLopMonHoc(int maLopMonHoc, LopMonHocDto lopMonHocDto)
        {
            return await _service.UpdateAsync(maLopMonHoc, lopMonHocDto);
        }
    }
}