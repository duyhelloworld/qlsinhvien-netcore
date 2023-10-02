using Microsoft.AspNetCore.Mvc;
using qlsinhvien.Context;

namespace qlsinhvien.Controllers;

[ApiController]
[Route("[controller]")]
public class FacultyController : ControllerBase
{
    private readonly ApplicationContext _context;
    
    public FacultyController(ApplicationContext _context) {
        this._context = _context;
    }
}