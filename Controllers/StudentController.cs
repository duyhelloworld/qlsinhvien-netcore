using Microsoft.AspNetCore.Mvc;
using qlsinhvien.Context;

namespace qlsinhvien.Controllers;

[ApiController]
[Route("[controller]")]
public class StudentController : ControllerBase
{
    private readonly ApplicationContext _context;

    public StudentController(ApplicationContext context) {
        _context = context;
    }
}