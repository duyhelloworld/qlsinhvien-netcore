using Microsoft.AspNetCore.Mvc;
using qlsinhvien.Atributes;
using qlsinhvien.Entities;
using qlsinhvien.Services;

namespace qlsinhvien.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BoMonController : ControllerBase
    {
        private readonly IBoMonService _service;
        public BoMonController(IBoMonService service)   
        {
            _service = service;
        }

        [HttpGet]
        [PhanQuyen(EQuyen.XemTatCa_BoMon)]
        public async Task<IEnumerable<BoMon>> GetAll()
        {
            return await _service.GetAllAsync();
        }

        [HttpGet("{mabomon:int:min(1)}")]
        [PhanQuyen(EQuyen.XemTheoMa_BoMon)]
        public async Task<IActionResult> GetById(int mabomon)
        {
            var boMon = await _service.GetTheoMa(mabomon);
            if (boMon == null)
            {
                return NotFound();
            }
            return Ok(boMon);
        }

        [HttpPost]
        [PhanQuyen(EQuyen.ThemMoi_BoMon)]
        public async Task<BoMon> AddNew([FromBody] BoMonDto boMonDto)
        {
            return await _service.Add(boMonDto); 
        }

        [HttpPut("{mabomon:int:min(1)}/ten")]
        [PhanQuyen(EQuyen.SuaTen_BoMon)]
        public async Task<BoMon> UpdateTen(int mabomon, [FromQuery] string TenBoMon)
        {
            return await _service.UpdateTen(mabomon, TenBoMon);
        }
        
        [HttpPut("{mabomon:int:min(1)}/khoa")]
        [PhanQuyen(EQuyen.SuaKhoa_BoMon)]
        public async Task<BoMon> UpdateKhoa(int mabomon, [FromBody] IEnumerable<int> MaKhoas)
        {
            return await _service.UpdateKhoa(mabomon, MaKhoas);
        }

        [HttpPut("{mabomon:int:min(1)}/giangvien")]
        [PhanQuyen(EQuyen.SuaGiangVien_BoMon)]
        public async Task<BoMon> UpdateGiangVien(int mabomon, [FromBody] IEnumerable<int> MaGiangViens)
        {
            return await _service.UpdateGiangVien(mabomon, MaGiangViens);
        }

        [HttpPut("{mabomon:int:min(1)}/monhoc")]
        [PhanQuyen(EQuyen.SuaMonHoc_BoMon)]
        public async Task<BoMon> UpdateMonHoc(int mabomon, [FromBody] IEnumerable<int> MaMonHocs)
        {
            return await _service.UpdateMonHoc(mabomon, MaMonHocs);
        }

        [HttpDelete("{mabomon:int:min(1)}")]
        [PhanQuyen(EQuyen.Xoa_BoMon)]
        public async Task Delete(int mabomon)
        {
            await _service.Remove(mabomon);
        }
    }
}