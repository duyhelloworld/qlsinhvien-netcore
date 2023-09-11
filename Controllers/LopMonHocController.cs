using Microsoft.AspNetCore.Mvc;
using qlsinhvien.Context;
using qlsinhvien.Dto;
using qlsinhvien.Entities;

namespace qlsinhvien.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LopMonHocController : ControllerBase
    {
        private readonly ApplicationContext appContext;
        public LopMonHocController(ApplicationContext appContext)
        {
            this.appContext = appContext;
        }
        
        [HttpGet("{maLopMonHoc}")]
        public ActionResult GetById(int maLopMonHoc)
        {
            var lmh = appContext.LopMonHocs.Find(maLopMonHoc);
            return lmh == null ? NotFound() : Ok(lmh);
        }
        [HttpGet("idGiangVien={magiangvien}")]
        public ActionResult GetByGiangVien(int magiangvien)
        {
            var lmh = appContext.LopMonHocs.Where(lmh => lmh.GiangVien.MaGiangVien == magiangvien).ToList();
            return lmh == null ? NotFound() : Ok(lmh);
        }
        // [HttpPut("{malopmonhoc}")]
        // public ActionResult UpdateLopMonHoc(int malopmonhoc)
        // {
        //     var lmh = appContext.LopMonHocs.Find(malopmonhoc);
        //     if (lmh == null)
        //     {
        //         return NotFound();
        //     }
        //     else 
        //     {
        //         lmh.TenLopMonHoc = LopMonHocDto.;
        //     }
        // }
    }
}