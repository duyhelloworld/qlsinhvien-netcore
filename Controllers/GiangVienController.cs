using System.Data;
using System.Runtime.Intrinsics.X86;
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
                // .Include(gv => gv.Khoa)
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
        public ActionResult GetByKhoa(string khoa)
        {
            // var kq = from gv in appContext.GiangViens
            //          join k in appContext.Khoas on gv.MaKhoa equals k.MaKhoa
            //          where k.TenKhoa.Contains(khoa)
            //          select new
            //          {
            //              gv.MaGiangVien,
            //              gv.HoTen,
            //              gv.GioiTinh,
            //              gv.Email,
            //              k.TenKhoa
            //          };
            // return kq == null ? NotFound() : Ok(kq);
            return NoContent();
        }
        [HttpGet("lopql={lopql}")]
        public ActionResult GetByLopQuanLi(string lopql)
        {
            // var kq = from gv in appContext.GiangViens
            //          join lql in appContext.LopQuanLis on gv.MaGiangVien equals lql.MaGiangVien
            //          where lql.TenLopQuanLi.Contains(lopql)
            //          select new
            //          {
            //              gv.MaGiangVien,
            //              gv.HoTen,
            //              gv.GioiTinh,
            //              gv.Email,
            //              lql.TenLopQuanLi
            //          };
            // return kq == null ? NotFound() : Ok(kq);
            return NoContent();
        }

        [HttpGet("lopmh={lopmh}")]
        public ActionResult GetByLopMonHoc(string lopmh)
        {
            // var kq = from gv in appContext.GiangViens
            //          join bm in appContext.BoMons on gv.MaBoMon equals bm.MaBoMon
            //          join mh in appContext.MonHocs on bm.MaBoMon equals mh.MaBoMon
            //          join lmh in appContext.LopMonHocs on mh.MaMonHoc equals lmh.MaMonHoc
            //          where lmh.TenLopMonHoc.Contains(lopmh)
            //          select new
            //          {
            //              gv.MaGiangVien,
            //              gv.HoTen,
            //              gv.GioiTinh,
            //              gv.Email,
            //              lmh.TenLopMonHoc
            //          };
            // return kq == null ? NotFound() : Ok(kq);
            return NoContent();
        }
        [HttpPost]
        public ActionResult AddGiangVien([FromBody] GiangVien giangVien)
        {
            // if (giangVien.MaGiangVien != 0 || giangVien.MaKhoa == 0)
            // {
            //     return BadRequest("Chứa tham số không hợp lệ");
            // }
            // try
            // {
            //     var khoa = appContext.Khoas.Find(giangVien.MaKhoa);

            //     if (khoa == null)
            //     {
            //         return NotFound();
            //     }
            //     appContext.GiangViens.Add(giangVien);
            //     appContext.SaveChanges();

            //     return CreatedAtAction(nameof(GetById), new { maGiangVien = giangVien.MaGiangVien }, giangVien);
            // }
            // catch (HttpRequestException)
            // {
            //     return BadRequest();
            // }
            return NoContent();
        }
        
        // [HttpPut("{magiangvien}")]
        // public ActionResult UpdateGiangVien(int magiangvien)
        // {
        //     var gv = appContext.GiangViens.Find(magiangvien);
        //     if(gv == null)
        //     {
        //         return NotFound();
        //     }

        // }
    }
}