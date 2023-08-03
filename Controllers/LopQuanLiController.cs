using Microsoft.AspNetCore.Mvc;
using qlsinhvien.Context;
using qlsinhvien.Entities;

namespace qlsinhvien.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LopQuanLiController
    {
        private readonly AppQLSVContext appContext;

        public LopQuanLiController(AppQLSVContext appContext)
        {
            this.appContext = appContext;
        }

        [HttpGet]
        public ActionResult<IEnumerable<LopQuanLi>> GetAllLopQuanLi()
        {
            return appContext.LopQuanLis.ToList();
        }        
    }
}