using Microsoft.AspNetCore.Mvc;
using TrainingApp.BLL.Interfaces;
using TrainingApp.BLL.Services;

namespace TrainingApp.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QualificationController : Controller
    {
        private readonly IQualificationService _qualificationService;

        public QualificationController(IQualificationService qualificationService)
        {
            _qualificationService = qualificationService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var quals = await _qualificationService.GetAllQualifications();
            return Ok(quals);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var qual = await _qualificationService.GetQualifiactionById(id);
            return Ok(qual);
        }
    }
}
