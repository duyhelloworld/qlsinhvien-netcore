using Microsoft.AspNetCore.Mvc;
using qlsinhvien.Atributes;
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

        [HttpGet]
        [PhanQuyen(EQuyen.XemTatCa_DiemSinhVien)]
        public async Task<IEnumerable<DiemSinhVienDetail>> GetAll()
        {
            return await _service.GetAll();
        }

        [HttpGet("{masinhvien:int:min(1)}")]
        [PhanQuyen(EQuyen.XemTheoMa_DiemSinhVien)]
        public async Task<IEnumerable<DiemSinhVienDetail>> GetById(int masinhvien)
        {
            return await _service.GetById(masinhvien);
        }

        [HttpGet("lopmonhoc/{malopmonhoc:int:min(1)}")]
        [PhanQuyen(EQuyen.XemTheoLopMonHoc_DiemSinhVien)]
        public async Task<IEnumerable<DiemSinhVienDetail>> GetByLopMonHoc(int malopmonhoc)
        {
            return await _service.GetByLopMonHoc(malopmonhoc);
        }

        [HttpGet("lopquanli/{malopquanli:int:min(1)}")]
        [PhanQuyen(EQuyen.XemTheoLopQuanLi_DiemSinhVien)]
        public async Task<IEnumerable<DiemSinhVienDetail>> GetByLopQuanLi(int malopquanli)
        {
            return await _service.GetByLopQuanLi(malopquanli);
        }

        [HttpPost]
        [PhanQuyen(EQuyen.ThemMoi_DiemSinhVien)]
        public async Task<DiemSinhVienDetail> ThemMoi([FromBody] DiemSinhVienDto diemSinhVien)
        {
            return await _service.ThemMoi(diemSinhVien);
        }

        [HttpPut("{masinhvien}")]
        [PhanQuyen(EQuyen.SuaDiemVaGhiChu_DiemSinhVien)]
        public async Task<DiemSinhVienDetail> SuaDiemVaGhiChu(int maSinhVien, [FromBody] DiemSinhVienDto diemSinhVien)
        {
            return await _service.SuaDiemVaGhiChu(maSinhVien, diemSinhVien);
        }

        [HttpDelete("{masinhvien:int:min(1)}/diem/{malopmonhoc:int:min(1)}")]
        public async Task XoaDiemTheoLopMonHoc(int masinhvien, int malopmonhoc)
        {
            // Diem => null
            await _service.XoaTheoLopMonHoc(masinhvien, malopmonhoc);
        }

        [HttpDelete("{masinhvien:int:min(1)}/lopmonhoc/{malopmonhoc:int:min(1)}")]
        public async Task XoaKhoiLopMonHoc(int masinhvien, int malopmonhoc)
        {
            // Xoa 1 dong diem 
            await _service.XoaKhoiLopMonHoc(masinhvien, malopmonhoc);
        }

        [HttpDelete("{masinhvien:int:min(1)}/diem")]
        public async Task XoaSinhVien(int masinhvien)
        {
            await _service.XoaSinhVien(masinhvien);
        }

        [HttpDelete("lopmonhoc/{malopmonhoc}")]
        public async Task XoaLopMonHoc(int maLopMonHoc)
        {
            await _service.XoaLopMonHoc(maLopMonHoc);
        }
    }
}