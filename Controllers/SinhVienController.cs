using Microsoft.AspNetCore.Mvc;
using qlsinhvien.Context;
using qlsinhvien.Dto;
using qlsinhvien.Entities;
using qlsinhvien.Mapper;

namespace qlsinhvien.Controllers
{
    [ApiController]
    [Route("/[controller]")]
    public class SinhVienController : ControllerBase
    {
        private readonly ApplicationContext sinhVienDbContext;
        private readonly HttpClient httpClient;

        public SinhVienController(ApplicationContext sinhVienDbContext, IHttpClientFactory httpClientFactory) {
            this.sinhVienDbContext = sinhVienDbContext;
            httpClient = httpClientFactory.CreateClient();
            httpClient.BaseAddress = new Uri("http://localhost:5277");
        }

//         [HttpGet]
//         public ActionResult<IEnumerable<SinhVienDto>> GetAll(){
//             var sinhVienDtos =  from sinhVien in sinhVienDbContext.SinhViens.ToList()
//                     select SinhVienMapper.ToDto(sinhVien);
//             return Ok(sinhVienDtos);
//         }

        [HttpGet("{id}")]
        public ActionResult<SinhVienDto> GetById(int id)
        {
            var sinhVien = sinhVienDbContext.SinhViens.Find(id);
            return sinhVien == null ? NotFound() : Ok(SinhVienMapper.ToDto(sinhVien));
        }

//         [HttpGet("search")]
//         public ActionResult<IEnumerable<SinhVienDto>> GetByName([FromQuery] string hoTen)
//         {
//             var ketQua = from sinhVien in sinhVienDbContext.SinhViens
//                             where sinhVien.HoTen.Contains(hoTen)
//                             select SinhVienMapper.ToDto(sinhVien);
//             return ketQua == null ? NotFound() : Ok(ketQua);
//         }

//         [HttpGet("search")]
//         public ActionResult<IEnumerable<SinhVien>> GetByEmail([FromQuery] string email)
//         {
//             var ketQua = from sinhVien in sinhVienDbContext.SinhViens
//                           where sinhVien.Email.StartsWith(email)
//                           select SinhVienMapper.ToDto(sinhVien);
//             return ketQua == null ? NotFound() : Ok(ketQua);
//         }

//         [HttpGet("search")]
//         public ActionResult<IEnumerable<SinhVienDto>> GetByNumberPhone([FromQuery] string email)
//         {
//             var ketQua = from sinhVien in sinhVienDbContext.SinhViens
//                           where sinhVien.Email.StartsWith(email)
//                           select SinhVienMapper.ToDto(sinhVien);
//             return ketQua == null ? NotFound() : Ok(ketQua);
//         }

        [HttpPost]
        public ActionResult AddSinhVien([FromBody] SinhVienDto sinhVienDto)
        {
            var sinhVien = SinhVienMapper.ToEntity(sinhVienDto);
            if (sinhVien.MaSinhVien != 0 
                    || sinhVien.MaLopQuanLi == 0)
                return BadRequest("Chứa tham số không hợp lệ");
            
            var responseJson = httpClient
                .GetAsync(new Uri(httpClient.BaseAddress, $"lopquanli/{sinhVien.MaLopQuanLi}")).Result;
            try
            {
                responseJson.EnsureSuccessStatusCode();
                var LopQuanLi = responseJson.Content.ReadFromJsonAsync<LopQuanLi>().Result;
                if (LopQuanLi == null)
                {
                    return BadRequest("Giá trị mã lớp quản lí không hợp lệ");
                }

                sinhVienDbContext.SinhViens.Add(sinhVien);
                sinhVienDbContext.SaveChanges();
                return Created(nameof(GetById), new {
                    maSoSinhVien = sinhVien.MaSinhVien,
                    hoTen = sinhVien.HoTen,
                    maLopQuanLi = sinhVien.MaLopQuanLi,
                    tenLopQuanLi = LopQuanLi.TenLopQuanLi,
                    giaoVienChuNhiem = LopQuanLi.GiangVien?.HoTen,
                    khoa = LopQuanLi.Khoa
                });
            }
            catch (HttpRequestException)
            {
                return BadRequest();
            }
        }

//         [HttpPut("{maSinhVien}")]
//         public ActionResult<SinhVienDto> UpdateSinhVien(int maSinhVien,  [FromBody] SinhVien sinhVien)
//         {
//             if (maSinhVien != sinhVien.MaSinhVien)
//             {
//                 return BadRequest("Tham số không hợp lệ");
//             }
//             var inDb = sinhVienDbContext.SinhViens.Find(maSinhVien);
//             if (inDb == null)
//             {
//                 return NotFound("Không tồn tại sinh viên mã số " + maSinhVien);
//             }
//             try
//             {
//                 sinhVienDbContext.Entry(inDb).State = EntityState.Detached;
//                 sinhVienDbContext.Entry(sinhVien).State = EntityState.Modified;
//                 sinhVienDbContext.SaveChanges();
//             }
//             catch (DbUpdateException)
//             {
//                 return BadRequest("Vi phạm nguyên tắc tham số. Chi tiết tại blabla.com"); 
//             }
//             catch (DBConcurrencyException) {
//                 return BadRequest("Vui lòng chậm lại");
//             }
//             return SinhVienMapper.ToDto(sinhVien);
//         }

//         [HttpDelete("{maSinhVien}")]
//         public ActionResult RemoveSinhVien(int maSinhVien, [FromQuery] bool confirm)
//         {
//             var inDb = sinhVienDbContext.SinhViens.Find(maSinhVien);
//             if (inDb == null)
//             {
//                 return NotFound("Không tồn tại sinh viên mã số " + maSinhVien);
//             }
//             throw new NotImplementedException("Chưa cài đặt được");
//             // sinhVienDbContext.SinhViens.Remove(inDb);
//             // sinhVienDbContext.SaveChanges();
//             // // Thay đổi cả số sinh viên trong lớp quản lí mà sinh viên bị xoá thuộc về
//             // return NoContent();
//         }

    }
}