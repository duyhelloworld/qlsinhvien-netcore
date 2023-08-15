using Microsoft.AspNetCore.Mvc;
using qlsinhvien.Context;
using qlsinhvien.Entities;

namespace qlsinhvien.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class KhoaController : ControllerBase
    {
        private readonly ApplicationContext applicationContext;
        public KhoaController(ApplicationContext applicationContext) {
            this.applicationContext = applicationContext;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Khoa>> GetAll() {
            return applicationContext.Khoas.ToList();
        }

        [HttpGet("{makhoa:int}")]
        public ActionResult<Khoa> GetById(int makhoa)
        {
            var ketQua = applicationContext.Khoas.Find(makhoa);
            return ketQua == null ? NotFound() : Ok(ketQua);
        }

        [HttpGet("/")]
        public ActionResult<IEnumerable<Khoa>> GetByName([FromQuery] string tenkhoa)
        {
            var ketQua = applicationContext.Khoas
                        .Where(k => k.TenKhoa.Contains(tenkhoa))
                        .OrderBy(k => k.MaKhoa);
            return ketQua == null ? NotFound() : Ok(ketQua);
        }

        [HttpPost]
        public ActionResult AddKhoa([FromBody] Khoa khoa)
        {
            
            return NoContent();
        }
    }
}