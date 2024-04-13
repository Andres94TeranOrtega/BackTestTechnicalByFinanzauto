using back_testFinanzauto.Contexts;
using back_testFinanzauto.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace back_testFinanzauto.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly ILogger<WeatherForecastController> _logger;
        private readonly Context _context;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, Context context)
        {
            _logger = logger;
            _context = context;

        }

        //[HttpGet(Name = "GetAllStudent")]
        //public IEnumerable<Students> Get()
        //{
        //    var students =  _context.Students.ToList();
        //    return students;
        //}

        //[HttpGet("GetStudent/{id}")]
        //public ActionResult<Students> Get(int id)
        //{
        //    var teacher = _context.GetTeacherById(id);
        //    if (teacher == null)
        //    {
        //        return NotFound();
        //    }
        //    return Ok(teacher);
        //}
    }
}
