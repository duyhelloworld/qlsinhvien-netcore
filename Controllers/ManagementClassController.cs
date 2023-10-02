using Microsoft.AspNetCore.Mvc;
using qlsinhvien.Context;

namespace qlsinhvien.Controllers;
[ApiController]
[Route("[controller]")]
public class ManagementClassController : ControllerBase
{
    private readonly ApplicationContext _context;

    public ManagementClassController(ApplicationContext context)
    {
        _context = context;
    }
}