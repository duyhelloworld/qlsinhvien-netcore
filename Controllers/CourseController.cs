using Microsoft.AspNetCore.Mvc;
using qlsinhvien.Context;

namespace qlsinhvien.Controllers;

[ApiController]
[Route("/[controller]")]
public class CourseController : ControllerBase
{
    private readonly ApplicationContext _context;

    public CourseController(ApplicationContext context)
    {
        _context = context;
    }   
}