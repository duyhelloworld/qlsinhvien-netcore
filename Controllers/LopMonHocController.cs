using Microsoft.AspNetCore.Mvc;
using qlsinhvien.Context;
using qlsinhvien.Entities;

namespace qlsinhvien.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LopMonHocController : ControllerBase
    {
        private readonly ApplicationContext lopMonHocDbContext;
        public LopMonHocController(ApplicationContext lopMonHocDbContext)
        {
            this.lopMonHocDbContext = lopMonHocDbContext;
        }
    }
}