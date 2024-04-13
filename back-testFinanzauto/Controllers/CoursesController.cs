using back_testFinanzauto.Models;
using back_testFinanzauto.Services;
using Microsoft.AspNetCore.Mvc;

namespace back_testFinanzauto.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CoursesController : ControllerBase
    {
        private readonly CoursesService _coursesService;
        private readonly ILogger<CoursesController> _logger;
        public CoursesController(CoursesService coursesService, ILogger<CoursesController> logger)
        {
            _coursesService = coursesService;
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<CoursesModel> GetAllCourses()
        {
            try
            {
                var courses = _coursesService.GetAllCoursesById();
                return courses;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al obtener todos los cursos.");
                throw;
            }
        }

        [HttpGet("{id}")]
        public ActionResult<CoursesModel> GetCoursesById(int id)
        {
            try
            {
                var courses = _coursesService.GetCoursesById(id);
                if (courses == null)
                {
                    return NotFound();
                }
                return Ok(courses);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error al obtener el curso con ID {id}.");
                throw;
            }
        }

        [HttpPost]
        public ActionResult<CoursesModel> CreatedStudent(CoursesModel courses)
        {
            try
            {
                _coursesService.CreateCourses(courses);
                return CreatedAtAction(nameof(GetCoursesById), new { id = courses.IdCourse }, courses);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al crear un nuevo curso.");
                throw;
            }
        }

        [HttpPut("{id}")]
        public ActionResult<CoursesModel> UpdateCourses(int id, CoursesModel courses)
        {
            try
            {
                if (id != courses.IdCourse)
                {
                    return BadRequest();
                }
                _coursesService.UpdateCourse(courses);
                return courses;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error al actualizar el curso con ID {id}.");
                throw;
            }
        }

        [HttpDelete("{id}")]
        public ActionResult<CoursesModel> DeletedCourses(int id)
        {
            try
            {
                _coursesService.DeleteCourse(id);
                return Ok("El curso ha sido eliminado");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error al eliminar el curso con ID {id}.");
                throw;
            }
        }
    }
}
