using Microsoft.AspNetCore.Mvc;
using qlsinhvien.Atributes;
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
        
        [HttpGet("{tatca}")]
        [PhanQuyen(EQuyen.XemTatCa_LopMonHoc)]
        public async Task<IEnumerable<LopMonHoc>> GetAll()
        {
            return await _service.GetAllAsync();
        }

        [HttpGet("id={id}")]
        [PhanQuyen(EQuyen.XemTheoMa_LopMonHoc)]
        public async Task<IActionResult> GetById(int id)
        {
            var ketQua = await _service.GetByIdAsync(id);
            return ketQua == null ? NotFound() : Ok(ketQua);
        }

        [HttpGet("tenlopmonhoc={tenlopmonhoc}")]
        [PhanQuyen(EQuyen.XemTheoTen_LopMonHoc)]
        public async Task<IEnumerable<LopMonHoc>> GetByTen(string tenlopmonhoc)
        {
            return await _service.GetByTenAsync(tenlopmonhoc);
        }

        [HttpGet("siso")]
        public async Task<IEnumerable<LopMonHoc>> GetWithSiSo()
        {
            return await _service.GetWithSiSoAsync();
        }
        
        [HttpGet("magiangvien={magiangvien}")]
        [PhanQuyen(EQuyen.XemTheoGiangVien_LopMonHoc)]
        public async Task<IEnumerable<LopMonHoc>> GetByGiangVien(int magiangvien)
        {
            return await _service.GetByGiangVienAsync(magiangvien);
        }

        [HttpPost]
        [PhanQuyen(EQuyen.ThemMoi_LopMonHoc)]
        public async Task<LopMonHoc> AddNew(LopMonHocDto lopMonHocDto)
        {
            return await _service.AddNewAsync(lopMonHocDto);
        }

        [HttpPut]
        [PhanQuyen(EQuyen.SuaThongTin_LopMonHoc)]
        public async Task<LopMonHoc> Update(int maLopMonHoc, LopMonHocDto lopMonHocDto)
        {
            return await _service.UpdateAsync(maLopMonHoc, lopMonHocDto);
        }
        [HttpDelete]
        [PhanQuyen(EQuyen.XoaTheoMa_LopMonHoc)]
        public async Task Remove(int maLopMonHoc)
        {
            await _service.RemoveAsync(maLopMonHoc);
        }
        [HttpDelete("monhoc={maMonHoc}")]
        [PhanQuyen(EQuyen.XoaTheoMonHoc_LopMonHoc)]
        public async Task RemoveTheoMonHoc(int maMonHoc)
        {
            await _service.RemoveTheoMonHoc(maMonHoc);
        }
    }
}