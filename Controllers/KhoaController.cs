using Microsoft.AspNetCore.Mvc;
using qlsinhvien.Context;

namespace qlsinhvien.Controllers
{
    [ApiController]
    [Route("/[Controller]")]
    public class KhoaController : ControllerBase
    {
        private readonly KhoaDbContext khoaDbContext;
        public KhoaController(KhoaDbContext khoaDbContext)
        {
            this.khoaDbContext = khoaDbContext;
        }
    }
}