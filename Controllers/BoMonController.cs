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

        [HttpPut("{mabomon:int:min(1)}")]
        [PhanQuyen(EQuyen.SuaThongTin_BoMon)]
        public async Task<BoMon> Update(int mabomon, [FromBody] BoMonDto boMonDto)
        {
            return await _service.Update(mabomon, boMonDto);
        }

        [HttpDelete("{mabomon:int:min(1)}")]
        [PhanQuyen(EQuyen.Xoa_BoMon)]
        public async Task Delete(int mabomon)
        {
            await _service.Remove(mabomon);
        }
    }
}