using System.Data;
using System.Runtime.Intrinsics.X86;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using qlsinhvien.Context;
using qlsinhvien.Dto;
using qlsinhvien.Entities;
namespace qlsinhvien.Controllers;

[ApiController]
[Route("/[controller]")]
public class GiangVienController : ControllerBase
{
    private readonly ApplicationContext giangVienDbContext;
    public GiangVienController(ApplicationContext giangVienDbContext)
    {
        this.giangVienDbContext = giangVienDbContext;
    }

    [HttpGet]
    public ActionResult<ICollection<GiangVien>> GetAll()
    {
        return giangVienDbContext.GiangViens.ToList();
    }

    [HttpGet("{magiangvien}")]
    public ActionResult GetById(int magiangvien)
    {
        var gv = giangVienDbContext.GiangViens.Find(magiangvien);
        return gv == null ? NotFound() : Ok(gv);
    }

    [HttpGet("hoten/{hoten}")]
    public ActionResult GetByName(string hoTen)
    {
        var gv = giangVienDbContext.GiangViens
            .Where(GiangVien => GiangVien.HoTen.Contains(hoTen))
            .OrderBy(g => g.MaGiangVien)
            .ToList();
        return gv.Count == 0 ? NotFound() : Ok(gv);
    }

    [HttpGet("bomon/{maBoMon}")]
    public ActionResult GetByBoMon(int maBoMon)
    {
        var boMon = giangVienDbContext.BoMons.Find(maBoMon);
        if (boMon == null)
        {
            return NotFound($"Bộ môn mã số {maBoMon} không tồn tại");
        }
        giangVienDbContext.BoMons.Entry(boMon).Collection(bm => bm.GiangViens).Load();
        var giangViens = boMon.GiangViens;
        if (giangViens == null || giangViens.Count == 0)
        {
            return NotFound();
        }
        var ketQua = from gv in giangViens
                     select new
                     {
                         gv.MaGiangVien,
                         gv.HoTen,
                         gv.Email,
                         gv.SoDienThoai,
                         BoMon = new
                         {
                             gv.BoMon.MaBoMon,
                             gv.BoMon.TenBoMon
                         }
                     };
        return Ok(ketQua);
    }

    [HttpGet("lopquanli/{maLopQuanLi}")]
    public ActionResult GetByLopQuanLi(int maLopQuanLi)
    {
        var kq = from gv in giangVienDbContext.GiangViens
                 join lql in giangVienDbContext.LopQuanLis on gv.MaGiangVien equals lql.GiangVien.MaGiangVien
                 where lql.MaLopQuanLi == maLopQuanLi
                 select new
                 {
                     gv.MaGiangVien,
                     gv.HoTen,
                     gv.GioiTinh,
                     gv.Email,
                     lql.TenLopQuanLi
                 };
        return kq == null ? NotFound() : Ok(kq);
        // return NoContent();
    }

    [HttpGet("lopmh/{lopmh}")]
    public ActionResult GetByLopMonHoc(string lopmh)
    {
        var kq = from gv in giangVienDbContext.GiangViens
                 join lmh in giangVienDbContext.LopMonHocs on gv.MaGiangVien equals lmh.GiangVien.MaGiangVien
                 where lmh.TenLopMonHoc.Contains(lopmh)
                 select new
                 {
                     gv.MaGiangVien,
                     gv.HoTen,
                     gv.GioiTinh,
                     gv.Email,
                     lmh.TenLopMonHoc
                 };
        return kq == null ? NotFound() : Ok(kq);
        // return NoContent();
    }

    [HttpPost]
    public ActionResult AddGiangVien([FromBody] GiangVienDto giangVienDto)
    {
        if (giangVienDto.MaGiangVien != 0 || giangVienDto.MaBoMon == 0)
        {
            return BadRequest("Chứa tham số không hợp lệ");
        }
        int maBoMon = giangVienDto.MaBoMon;
        var maLopQuanLi = giangVienDto.MaLopQuanLi;
        var boMon = giangVienDbContext.BoMons.Find(maBoMon);
        if (boMon == null)
        {
            return NotFound($"Không tồn tại bộ môn có mã {maBoMon}!");
        }
        // Check tên, tuổi bla bla
        var giangVien = new GiangVien()
        {
            MaGiangVien = 0,
            HoTen = giangVienDto.HoTen,
            GioiTinh = giangVienDto.GioiTinh,
            NgaySinh = giangVienDto.NgaySinh,
            QueQuan = giangVienDto.QueQuan,
            DiaChiThuongTru = giangVienDto.DiaChiThuongTru,
            SoDienThoai = giangVienDto.SoDienThoai,
            Email = giangVienDto.Email,
            BoMon = boMon
        };
        // Thêm lớp quản lí (lớp quản lí của 1 giảng viên có thể null)
        // Nếu gán lớp ql đã có sẵn cho giảng viên mới thì giảng viên mới sẽ tiếp quản lớp đó thay người cũ
        var lopQuanLi = giangVienDbContext.LopQuanLis.Find(maLopQuanLi);
        giangVien.LopQuanLi = lopQuanLi;
        // Thêm các lớp môn học
        var maLopMonHocs = giangVienDto.MaLopMonHocs;
        if (maLopMonHocs != null && maLopMonHocs.Count() != 0)
        {
            var lopMonHocs = giangVienDbContext.LopMonHocs
                .Where(lmh => maLopMonHocs.Contains(lmh.MaLopMonHoc))
                .ToList();
            if (lopMonHocs.Count() != 0)
            {
                giangVien.LopMonHocs = lopMonHocs;
            }
        }
        try
        {
            giangVienDbContext.GiangViens.Add(giangVien);
            giangVienDbContext.SaveChanges();
        }
        catch (DbUpdateException ex)
        {
            if (ex.InnerException.Message.Contains("email"))
            {
                return BadRequest($"Email {giangVienDto.Email} đã được sử dụng");
            }
            else if (ex.InnerException.Message.Contains("SoDienThoai"))
            {
                return BadRequest($"Số điện thoại {giangVienDto.SoDienThoai} đã được sử dụng");
            }
            throw;
        }

        return CreatedAtAction(nameof(GetById),
            new
            {
                giangVien.MaGiangVien,
                giangVien.HoTen,
                giangVien.Email,
                giangVien.BoMon.TenBoMon,
                TenLopQuanLi = giangVien.LopQuanLi == null ? null : giangVien.LopQuanLi.TenLopQuanLi
            });
    }

    [HttpPut("{magiangvien}")]
    public ActionResult UpdateThongTinGiangVien(int magiangvien, [FromBody] GiangVienDto giangVienDto)
    {
        var boMon = giangVienDbContext.BoMons.Find(giangVienDto.MaBoMon);
        if (boMon == null)
        {
            return NotFound($"Không tồn tại bộ môn có mã {giangVienDto.MaBoMon}!");
        }
        var gv = giangVienDbContext.GiangViens.Find(magiangvien);
        if (gv == null)
        {
            return NotFound();
        }
        giangVienDto.MaGiangVien = magiangvien;
        gv.HoTen = giangVienDto.HoTen;
        gv.GioiTinh = giangVienDto.GioiTinh;
        gv.NgaySinh = giangVienDto.NgaySinh;
        gv.QueQuan = giangVienDto.QueQuan;
        gv.DiaChiThuongTru = giangVienDto.DiaChiThuongTru;
        gv.SoDienThoai = giangVienDto.SoDienThoai;
        gv.Email = giangVienDto.Email;
        gv.BoMon = boMon;
        // Ko cập nhật lớp quản lí / lớp môn học vì có hàm riêng để làm chuyện ấy
        giangVienDbContext.SaveChanges();
        return Ok(new
        {
            gv.MaGiangVien,
            gv.HoTen,
            gv.Email,
            gv.BoMon.TenBoMon
        });
    }

    [HttpPut("lopquanli/{magiangvien}")]
    public ActionResult UpdateLopQuanLi_GiangVien(int magiangvien, [FromBody] int maLopQuanLi)
    {
        if (maLopQuanLi == 0)
        {
            return BadRequest();
        }
        var giangVien = giangVienDbContext.GiangViens.Find(magiangvien);
        if (giangVien == null)
        {
            return NotFound();
        }
        var lopQuanLi = giangVienDbContext.LopQuanLis.Find(maLopQuanLi);
        if (lopQuanLi == null)
        {
            return BadRequest($"Không tồn tại lớp quản lí có mã {maLopQuanLi}");
        }
        giangVien.LopQuanLi = lopQuanLi;
        giangVienDbContext.SaveChanges();
        return Ok(giangVien);
    }

    [HttpPut("lopmonhoc/{magiangvien}")]
    public ActionResult UpdateLopMonHocs_GiangVien(int magiangvien, [FromBody] ICollection<int> maLopMonHocs)
    {
        if (maLopMonHocs.Count == 0)
        {
            return BadRequest();
        }
        var giangVien = giangVienDbContext.GiangViens.Find(magiangvien);
        if (giangVien == null)
        {
            return NotFound($"Không tồn tại giảng viên mã số {magiangvien}");
        }
        var lopMonHocs = giangVienDbContext.LopMonHocs
                .Where(lmh => maLopMonHocs.Contains(lmh.MaLopMonHoc))
                .ToList();
        if (lopMonHocs.Count() == 0)
        {
            return NotFound("Không tồn tại các lớp môn học này.");
        }
        giangVien.LopMonHocs = lopMonHocs;
        giangVienDbContext.SaveChanges();
        return Ok(giangVien);
    }

    [HttpDelete("{magiangvien}")]
    public ActionResult DeleteGiangVien(int magiangvien)
    {
        var gv = giangVienDbContext.GiangViens.Find(magiangvien);

        if (gv == null)
        {
            return NotFound();
        }

        // Tìm các lớp quản lí liên quan và đặt mã giảng viên thành null
        var lqlList = giangVienDbContext.LopQuanLis.Where(lql => lql.GiangVien.MaGiangVien == magiangvien);
        foreach (var lql in lqlList)
        {
            lql.GiangVien = null;
        }

        // Tìm các lớp môn học liên quan và đặt mã giảng viên thành null
        var lmhList = giangVienDbContext.LopMonHocs.Where(lmh => lmh.GiangVien.MaGiangVien == magiangvien);
        foreach (var lmh in lmhList)
        {
            lmh.GiangVien = null;
        }

        giangVienDbContext.SaveChanges();

        return Ok(gv);
    }

}