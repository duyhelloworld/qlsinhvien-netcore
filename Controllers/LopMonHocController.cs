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
        public async Task<LopMonHoc> GetById(int id)
        {
            return await _service.GetByIdAsync(id);
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
<<<<<<< HEAD

        [HttpPost]
        [PhanQuyen(EQuyen.ThemMoi_LopMonHoc)]
=======
        [HttpGet("tatca")]
        public async Task<IEnumerable<LopMonHoc>> GetAll()
        {
            return await _service.GetAllAsync();
        }
        [HttpPost]
>>>>>>> 926b5447f3c6e1901a023702cdfde1476c6f24f8
        public async Task<LopMonHoc> AddNew(LopMonHocDto lopMonHocDto)
        {
            return await _service.AddNewAsync(lopMonHocDto);
        }
<<<<<<< HEAD

        [HttpPut]
        [PhanQuyen(EQuyen.SuaThongTin_LopMonHoc)]
        public async Task<LopMonHoc> Update(int maLopMonHoc, LopMonHocDto lopMonHocDto)
        {
            return await _service.UpdateAsync(maLopMonHoc, lopMonHocDto);
        }
        [HttpDelete]
        [PhanQuyen(EQuyen.XoaTheoMa_LopMonHoc)]
=======
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
>>>>>>> 926b5447f3c6e1901a023702cdfde1476c6f24f8
        public async Task Remove(int maLopMonHoc)
        {
            await _service.RemoveAsync(maLopMonHoc);
        }
<<<<<<< HEAD
        [HttpDelete("monhoc={maMonHoc}")]
        [PhanQuyen(EQuyen.XoaTheoMonHoc_LopMonHoc)]
        public async Task RemoveTheoMonHoc(int maMonHoc)
        {
            await _service.RemoveTheoMonHoc(maMonHoc);
=======
        [HttpPut]
        public async Task<LopMonHoc> UpdateLopMonHoc(int maLopMonHoc, LopMonHocDto lopMonHocDto)
        {
            return await _service.UpdateAsync(maLopMonHoc, lopMonHocDto);
>>>>>>> 926b5447f3c6e1901a023702cdfde1476c6f24f8
        }
    }
}