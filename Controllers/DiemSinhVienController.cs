using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using qlsinhvien.Context;
using qlsinhvien.Entities;

namespace qlsinhvien.Controllers
{
    [ApiController]
    [Route("/[controller]")]
    public class DiemSinhVienController : ControllerBase
    {
        private readonly ApplicationContext appContext;
        public DiemSinhVienController(ApplicationContext appContext)
        {
            this.appContext = appContext;
        }
        [HttpGet("{masinhvien}")]
        public ActionResult GetById(int masinhvien)
        {
            var diem = appContext.DiemSinhViens.Find(masinhvien);
            if (diem == null)
            {
                return NotFound();
            }
            else
            {
            var query = from diemSv in appContext.DiemSinhViens
                    join lopMh in appContext.LopMonHocs on diemSv.MaLopMonHoc equals lopMh.MaLopMonHoc
                    join mh in appContext.MonHocs on lopMh.MaMonHoc equals mh.MaMonHoc
                    where masinhvien == diemSv.MaSinhVien
                    orderby mh.MaMonHoc
                    select new
                    {
                        mh.MaMonHoc,
                        mh.TenMonHoc,
                        lopMh.TenLopMonHoc,
                        diemSv.DiemChuyenCan,
                        diemSv.DiemGiuaKi,
                        diemSv.DiemCuoiKi,
                        diemSv.GhiChu
                    };
            return Ok(query);
            }
        }
        [HttpPut("{masinhvien}")]
        public ActionResult UpdateDiemSinhVien(int masinhvien, [FromBody] DiemSinhVien diemSinhVien)
        {
            var diem = appContext.DiemSinhViens.Find(masinhvien);
            if (diem == null)
            {
                return NotFound();
            }
            else
            {
                diem.DiemChuyenCan = diemSinhVien.DiemChuyenCan;
                diem.DiemGiuaKi = diemSinhVien.DiemGiuaKi;
                diem.DiemCuoiKi = diemSinhVien.DiemCuoiKi;

                // appContext.DiemSinhViens.Update(diem);
                appContext.SaveChanges();
                return Ok(diem);
            }
        }
        [HttpPut("{masinhvien}")]
        public ActionResult DeleteDiemSinhVien(int masinhvien)
        {
            var diem = appContext.DiemSinhViens.Find(masinhvien);
            if (diem == null)
            {
                return NotFound();
            }
            else
            {
                diem.DiemChuyenCan = 0;
                diem.DiemGiuaKi = 0;
                diem.DiemCuoiKi = 0;

                // appContext.DiemSinhViens.Update(diem);
                appContext.SaveChanges();
                return Ok(diem);
            }
        }
    }
}