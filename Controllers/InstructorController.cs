using Microsoft.AspNetCore.Mvc;
using qlsinhvien.Context;

namespace qlsinhvien.Controllers;

[ApiController]
[Route("[controller]")]
public class InstructorController : ControllerBase
{
    private readonly ApplicationContext _context;

    public InstructorController(ApplicationContext context)
    {
        _context = context;
    }
}