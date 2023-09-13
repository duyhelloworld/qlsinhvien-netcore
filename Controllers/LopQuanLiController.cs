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

        [HttpGet("tatca")]
        [PhanQuyen(EQuyen.XemTatCa_LopQuanLi)]
        public async Task<IEnumerable<LopQuanLi>> GetAll() 
        {
            return await _service.GetAll();
        }

        [HttpGet("tenlopquanli")]
        public async Task<IEnumerable<LopQuanLi>> GetByName(string tenLopQuanLi)
        {
            return await _service.GetByTen(tenLopQuanLi);
        }

        [HttpGet("{malopquanli}")]
        public async Task<LopQuanLi> GetById(int maLopQuanLi)
        {
            return await _service.GetById(maLopQuanLi);
        }

        [HttpGet("siso")]
        public async Task<LopQuanLi> GetAllWithSiSo()
        {
            return await _service.GetWithSiSo();
        }

        [HttpPost]
        public async Task<LopQuanLi> AddLopQL(LopQuanLiDto lopQuanLiDto)
        {
            return await _service.AddNew(lopQuanLiDto);
        }

        [HttpPut]
        public async Task<LopQuanLi> UpdateLopQL(int maLopQuanLi, LopQuanLiDto lopQuanLiDto) 
        {
            return await _service.Update(maLopQuanLi, lopQuanLiDto);   
        }

        [HttpDelete("{malopquanli}")]
        public async Task RemoveLopQL(int maLopQuanLi) 
        {
            await _service.Remove(maLopQuanLi);
        }

        [HttpDelete]
        public async Task<LopQuanLi> RemoveLopQLByRange(ICollection<int> maLopQuanLis)
        {
            return await _service.RemoveRange(maLopQuanLis);
        }
    }
}
