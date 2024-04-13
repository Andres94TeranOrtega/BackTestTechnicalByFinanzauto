using back_testFinanzauto.Models;
using back_testFinanzauto.Services;
using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;

namespace back_testFinanzauto.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StudentController : ControllerBase
    {
        private readonly StudentService _studenServices;
        private readonly ILogger<StudentController> _logger;
        public StudentController(StudentService studentService, ILogger<StudentController> logger) 
        {
            _studenServices = studentService;
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<StudentsModel> GetAllStudent()
        {
            try
            {
                var students = _studenServices.GetAllStudentById();
                return students;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al obtener todos los estudiantes.");
                throw;
            }
        }

        [HttpGet("{id}")]
        public ActionResult<StudentsModel> GetStudentById(int id)
        {
            try
            {
                var student = _studenServices.GetStudentById(id);
                if (student == null)
                {
                    return NotFound();
                }
                return Ok(student);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error al obtener el estudiante con ID {id}.");
                throw;
            }
        }

        [HttpPost]
        public ActionResult<StudentsModel> CreatedStudent(StudentsModel student)
        {
            try
            {
                _studenServices.CreateStudent(student);
                return CreatedAtAction(nameof(GetStudentById), new { id = student.IdStudent }, student);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al crear un nuevo estudiante.");
                throw;
            }
        }

        [HttpPut("{id}")]
        public IActionResult UpdateStudent(int id, StudentsModel student)
        {
            try
            {
                if (id != student.IdStudent)
                {
                    return BadRequest();
                }
                _studenServices.UpdateStudent(student);
                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error al actualizar el estudiante con ID {id}.");
                throw;
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeletedStudent(int id)
        {
            try
            {
                _studenServices.DeleteStudent(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error al eliminar el estudiante con ID {id}.");
                throw;
            }
        }
    }
}
