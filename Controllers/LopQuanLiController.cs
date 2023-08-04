// using Microsoft.AspNetCore.Mvc;
// using qlsinhvien.Context;
// using qlsinhvien.Entities;

// namespace qlsinhvien.Controllers
// {
//     [ApiController]
//     [Route("[controller]")]
//     public class LopQuanLiController
//     {
//         private readonly LopQuanLiDbContext lopQuanLiDbContext;

//         public LopQuanLiController(LopQuanLiDbContext lopQuanLiDbContext)
//         {
//             this.lopQuanLiDbContext = lopQuanLiDbContext;
//         }

//         [HttpGet]
//         public ActionResult<IEnumerable<LopQuanLi>> GetAllLopQuanLi()
//         {
//             return lopQuanLiDbContext.LopQuanLis.ToList();
//         }        
//     }
// }