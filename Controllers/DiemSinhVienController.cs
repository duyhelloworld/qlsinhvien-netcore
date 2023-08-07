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
        private readonly AppQLSVContext appContext;
        public DiemSinhVienController(AppQLSVContext appContext)
        {
            this.appContext = appContext;
        }
        [HttpGet("{id}")]
        public ActionResult GetById(int id)
        {
            int mssv = 1;
            var diem = appContext.DiemSinhViens.Find(id);
            if (diem == null)
            {
                return NotFound();
            }
            else
            {
            var query = from diemSv in appContext.DiemSinhViens
                    join lopMh in appContext.LopMonHocs on diemSv.MaLopMonHoc equals lopMh.MaLopMonHoc
                    join mh in appContext.MonHocs on lopMh.MaMonHoc equals mh.MaMonHoc
                    where mssv == id
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
        [HttpPut("{id}")]
        public ActionResult UpdateDiemSinhVien(int id, [FromBody] DiemSinhVien diemSinhVien)
        {
            var diem = appContext.DiemSinhViens.Find(id);
            if (diem == null)
            {
                return NotFound();
            }
            else
            {
                diem.DiemChuyenCan = diemSinhVien.DiemChuyenCan;
                diem.DiemGiuaKi = diemSinhVien.DiemGiuaKi;
                diem.DiemCuoiKi = diemSinhVien.DiemCuoiKi;

                appContext.DiemSinhViens.Update(diem);
                appContext.SaveChanges();
                return Ok(diem);
            }
        }
        [HttpPut("{id}")]
        public ActionResult DeleteDiemSinhVien(int id)
        {
            var diem = appContext.DiemSinhViens.Find(id);
            if (diem == null)
            {
                return NotFound();
            }
            else
            {
                diem.DiemChuyenCan = 0;
                diem.DiemGiuaKi = 0;
                diem.DiemCuoiKi = 0;

                appContext.DiemSinhViens.Update(diem);
                appContext.SaveChanges();
                return Ok(diem);
            }
        }
    }
}