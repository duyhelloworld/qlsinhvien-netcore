using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using qlsinhvien.Atributes;
using qlsinhvien.Context;
using qlsinhvien.Dto;
using qlsinhvien.Entities;
using qlsinhvien.Services;

namespace qlsinhvien.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LopQuanLiController : ControllerBase
    {
        private readonly ILopQuanLiService _service;

        public LopQuanLiController(ILopQuanLiService service)
        {
            _service = service;
        }

        [HttpGet("{tatca}")]
        [PhanQuyen(EQuyen.XemTatCa_LopQuanLi)]
        public async Task<IEnumerable<LopQuanLi>> GetAll()
        {
            return await _service.GetAll();
        }

        [HttpGet("tenlop/{tenlop}")]
        [PhanQuyen(EQuyen.XemTheoTen_LopQuanLi)]
        public async Task<IEnumerable<LopQuanLi>> GetByTen(string tenLopQuanLi)
        {
            return await _service.GetByTen(tenLopQuanLi);
        }

        [HttpGet("malop/{malop}")]
        [PhanQuyen(EQuyen.XemTheoMa_LopQuanLi)]
        public async Task<ActionResult<LopQuanLi>> GetById(int malop)
        {
            return await _service.GetById(malop);
        }

        [HttpGet("siso")]
        public async Task<ActionResult<LopQuanLi>> GetWithSiSo()
        {
            return await _service.GetWithSiSo();
        }            
            

        [HttpPost]
        [PhanQuyen(EQuyen.ThemMoi_LopQuanLi)]
        public async Task<ActionResult<LopQuanLi>> AddNew(LopQuanLiDto lopQuanLiDto)
        {
            return await _service.AddNew(lopQuanLiDto);
        }

        [HttpPut]
        [PhanQuyen(EQuyen.SuaThongTinTheoMa_LopQuanLi)]
        public async Task<ActionResult<LopQuanLi>> Update(int maLopQuanLi, LopQuanLiDto lopQuanLiDto)
        {
            return await _service.Update(maLopQuanLi, lopQuanLiDto);
        }

        [HttpDelete("{malop}")]
        [PhanQuyen(EQuyen.Xoa_LopQuanLi)]
        public async Task<ActionResult> Remove(int malop)
        {
            await _service.Remove(malop);
            return Ok();
        }
    }
}
