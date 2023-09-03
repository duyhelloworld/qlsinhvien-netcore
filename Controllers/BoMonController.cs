using Microsoft.AspNetCore.Mvc;
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

        // [PhanQuyen("xemtatcabomon")]
        // [HttpGet("")]
        public async Task<IEnumerable<BoMon>> GetAll()
        {
            return await _service.GetAllAsync();
        }
    }
}