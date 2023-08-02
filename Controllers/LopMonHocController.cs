using Microsoft.AspNetCore.Mvc;
using qlsinhvien.Context;
using qlsinhvien.Entities;

namespace qlsinhvien.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LopMonHocController : ControllerBase
    {
        private readonly AppQLSVContext appContext;
        public LopMonHocController(AppQLSVContext appQLSVContext)
        {
            appContext = appQLSVContext;
        }

        // [HttpGet]
        // public async Task<IActionResult> Get()
        // {
        //     appContext.LopMonHocs.Add(
        //         new LopMonHoc() {
        //             MaGiangVien = 1,
        //             MaMonHoc = 1
        //         });
        //     appContext.SaveChanges();
        //     return Ok();
        // }
    }
}