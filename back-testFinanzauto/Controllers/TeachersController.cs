using back_testFinanzauto.Models;
using back_testFinanzauto.Services;
using Microsoft.AspNetCore.Mvc;

namespace back_testFinanzauto.Controllers
{
    [ApiController]
    [Route("teacher/[controller]")]
    public class TeachersController : ControllerBase
    {
        private readonly TeachersService _teacherServices;
        private readonly ILogger<TeachersController> _logger;
        public TeachersController(TeachersService teachertService, ILogger<TeachersController> logger)
        {
            _teacherServices = teachertService;
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<TeachersModel> GetAllTeachers()
        {
            try
            {
                return _teacherServices.GetAllTeachers();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al obtener todos los profesores.");
                throw;
            }
        }

        [HttpGet("{id}")]
        public ActionResult<TeachersModel> GetTeachersById(int id)
        {
            try
            {
                var teacher = _teacherServices.GetTeachersById(id);
                if (teacher == null)
                {
                    return NotFound();
                }
                return Ok(teacher);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error al obtener el profesor con ID {id}.");
                throw;
            }
        }

        [HttpPost]
        public ActionResult<TeachersModel> CreatedTeachers(TeachersModel teacher)
        {
            try
            {
                _teacherServices.CreateTeachers(teacher);
                return CreatedAtAction(nameof(GetTeachersById), new { id = teacher.IdTeacher }, teacher);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al crear un nuevo profesor.");
                throw;
            }
        }

        [HttpPut("{id}")]
        public ActionResult<TeachersModel> UpdateTeachers(int id, TeachersModel teachers)
        {
            try
            {
                if (id != teachers.IdTeacher)
                {
                    return BadRequest();
                }
                _teacherServices.UpdateTeachers(teachers);
                return teachers;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error al actualizar el profesor con ID {id}.");
                throw;
            }
        }

        [HttpDelete("{id}")]
        public ActionResult<TeachersModel> DeletedTeachers(int id)
        {
            try
            {
                _teacherServices.DeleteTeachers(id);
                return Ok("El profesor ha sido eliminado");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error al eliminar el profesor con ID {id}.");
                throw;
            }
        }
    }
}
