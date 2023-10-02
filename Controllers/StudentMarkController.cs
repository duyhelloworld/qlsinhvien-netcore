using Microsoft.AspNetCore.Mvc;
using qlsinhvien.Context;

namespace qlsinhvien.Controllers;

[ApiController]
[Route("[controller]")]
public class StudentMarkController : ControllerBase
{
    private readonly ApplicationContext _context;

    public StudentMarkController(ApplicationContext context)
    {
        _context = context;
    }
}