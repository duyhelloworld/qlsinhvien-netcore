// using Microsoft.AspNetCore.Mvc;
// using qlsinhvien.Context;
// using qlsinhvien.Entities;

// namespace qlsinhvien.Controllers
// {
//     [ApiController]
//     [Route("api/[controller]")]
//     public class LopMonHocController : ControllerBase
//     {
//         private readonly LopMonHocDbContext lopMonHocDbContext;
//         public LopMonHocController(LopMonHocDbContext lopMonHocDbContext)
//         {
//             this.lopMonHocDbContext = lopMonHocDbContext;
//         }

//         // [HttpGet]
//         // public async Task<IActionResult> Get()
//         // {
//         //     lopMonHocDbContext.LopMonHocs.Add(
//         //         new LopMonHoc() {
//         //             MaGiangVien = 1,
//         //             MaMonHoc = 1
//         //         });
//         //     lopMonHocDbContext.SaveChanges();
//         //     return Ok();
//         // }
//     }
// }