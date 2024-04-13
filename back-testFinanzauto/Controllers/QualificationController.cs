using back_testFinanzauto.Models;
using back_testFinanzauto.Services;
using Microsoft.AspNetCore.Mvc;

namespace back_testFinanzauto.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class QualificationController : ControllerBase
    {
        private readonly QualificationService _qualificationServices;
        private readonly ILogger<QualificationController> _logger;
        public QualificationController(QualificationService qualificationService, ILogger<QualificationController> logger)
        {
            _qualificationServices = qualificationService;
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<QualificationModel> GetAllQualification()
        {
            try
            {
               return _qualificationServices.GetAllQualificationById();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al obtener todas los calificaciones.");
                throw;
            }
        }

        [HttpGet("{id}")]
        public ActionResult<QualificationModel> GetQualificationtById(int id)
        {
            try
            {
                var qualification = _qualificationServices.GetQualificationById(id);
                if (qualification == null)
                {
                    return NotFound();
                }
                return Ok(qualification);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error al obtener la calificación con ID {id}.");
                throw;
            }
        }

        [HttpPost]
        public ActionResult<QualificationModel> CreatedQualification(QualificationModel qualification)
        {
            try
            {
                _qualificationServices.CreateQualification(qualification);
                return CreatedAtAction(nameof(GetQualificationtById), new { id = qualification.IdGrade }, qualification);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al crear la nueva calificacion.");
                throw;
            }
        }

        [HttpPut("{id}")]
        public ActionResult<QualificationModel> UpdateQualification(int id, QualificationModel qualification)
        {
            try
            {
                if (id != qualification.IdGrade)
                {
                    return BadRequest();
                }
                _qualificationServices.UpdateQualification(qualification);
                return qualification;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error al actualizar el estudiante con ID {id}.");
                throw;
            }
        }

        [HttpDelete("{id}")]
        public ActionResult<TeachersModel> DeleteQualification(int id)
        {
            try
            {
                _qualificationServices.DeleteQualification(id);
                return Ok("La calificacion ha sido eliminada");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error al eliminar la calificación con ID {id}.");
                throw;
            }
        }
    }
}
