using System.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using qlsinhvien.Context;
using qlsinhvien.Entities;

namespace qlsinhvien.Controllers
{
    [ApiController]
    [Route("/[controller]")]
    public class GiangVienController : ControllerBase
    {
        private readonly ApplicationContext appContext;
        public GiangVienController(ApplicationContext appContext)
        {
            this.appContext = appContext;
        }

        [HttpGet]
        public ActionResult<ICollection<GiangVien>> GetAll()
        {
            return appContext.GiangViens
                .Include(gv => gv.Khoa)
                .ToList();
        }
        
        [HttpGet("{magiangvien}")]
        public ActionResult GetById(int magiangvien)
        {
            var gv = appContext.GiangViens.Find(magiangvien);
            return gv == null ? NotFound() : Ok(gv);
        }

        [HttpGet("ten={ten}")]
        public ActionResult GetByName(string ten)
        {
            Console.WriteLine(ten);
            var gv = appContext.GiangViens.Where(GiangVien => GiangVien.HoTen.Contains(ten)).ToList();
            return gv.Count == 0 ? NotFound() : Ok(gv);
        }


        [HttpGet("khoa={khoa}")]
        public ActionResult GetByKhoa([FromQuery] string khoa)
        {
            var kq = from gv in appContext.GiangViens
                     join k in appContext.Khoas on gv.MaKhoa equals k.MaKhoa
                     where k.TenKhoa.Contains(khoa)
                     select new
                     {
                         gv.MaGiangVien,
                         gv.HoTen,
                         gv.GioiTinh,
                         gv.Email,
                         k.TenKhoa
                     };
            return kq == null ? NotFound() : Ok(kq);
        }
        [HttpGet("lopql")]
        public ActionResult GetByLopQuanLi([FromQuery] string lop)
        {
            var kq = from gv in appContext.GiangViens
                     join lql in appContext.LopQuanLis on gv.MaGiangVien equals lql.MaGiangVien
                     where lql.TenLopQuanLi.Contains(lop)
                     select new
                     {
                         gv.MaGiangVien,
                         gv.HoTen,
                         gv.GioiTinh,
                         gv.Email,
                         lql.TenLopQuanLi
                     };
            return kq == null ? NotFound() : Ok(kq);
        }
        [HttpGet("lopmh")]
        public ActionResult GetByLopMonHoc(string lop)
        {
            var kq = from gv in appContext.GiangViens
                     join lmh in appContext.LopMonHocs on gv.MaGiangVien equals lmh.MaGiangVien
                     where lmh.TenLopMonHoc.Contains(lop)
                     select new
                     {
                         gv.MaGiangVien,
                         gv.HoTen,
                         gv.GioiTinh,
                         gv.Email,
                         lmh.TenLopMonHoc
                     };
            return kq == null ? NotFound() : Ok(kq);
        }
        // [HttpPost]
        // public ActionResult AddGiangVien([FromBody] GiangVienDto giangVienDto)
        // {
            
        // }
    }
}