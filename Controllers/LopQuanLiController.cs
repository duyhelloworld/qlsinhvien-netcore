using Microsoft.AspNetCore.Mvc;
using qlsinhvien.Context;

namespace qlsinhvien.Controllers;
[ApiController]
[Route("[controller]")]
public class LopQuanLiController : ControllerBase
{
    private readonly ApplicationContext _context;

    public LopQuanLiController(ApplicationContext context)
    {
        _context = context;
    }
}