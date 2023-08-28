using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using qlsinhvien.Context;
using qlsinhvien.Dto;
using qlsinhvien.Entities;
using qlsinhvien.Services;

namespace qlsinhvien.Controllers
{
    [ApiController]
    [Route("/[controller]")]
    public class MonHocController : ControllerBase
    {
        private readonly IMonHocService _service;
    public MonHocController(IMonHocService service)
    {
        _service = service;
    }

        [HttpGet]
        public async Task<IEnumerable<MonHoc>> GetAll()
        {
            return await _service.GetAll();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var monHoc = await _service.GetById(id);
            if (monHoc == null)
            {
                return NotFound();
            }
            return Ok(monHoc);
        }
        [HttpGet("getname/{name}")]
        public async Task<IActionResult> GetByName([FromQuery] string name)
        {
            var monHoc = await _service.GetByTenMon(name);
            if (monHoc == null)
            {
                return NotFound();
            }
            return Ok(monHoc);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateMonHoc(int id, [FromBody] MonHocDto monHoc)
        {
            var mon = await _service.Update(id, monHoc);
            return Ok(mon);
        }

        [HttpDelete("{id}")]
        public async Task DeleteMonHoc(int id)
        {
            await _service.Remove(id);
        }
    }
}