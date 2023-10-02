using Microsoft.AspNetCore.Mvc;
using qlsinhvien.Context;

namespace qlsinhvien.Controllers;

[ApiController]
[Route("[controller]")]
public class CourseClassController : ControllerBase
{
    private readonly ApplicationContext _context;
    
    public CourseClassController(ApplicationContext context)
    {
        _context = context;
    }
}