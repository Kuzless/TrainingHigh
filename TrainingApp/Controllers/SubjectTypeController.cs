using Microsoft.AspNetCore.Mvc;
using TrainingApp.BLL.Interfaces;
using TrainingApp.BLL.Services;

namespace TrainingApp.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubjectTypeController : Controller
    {
        private readonly ISubjectTypeService _subjectTypeService;
        public SubjectTypeController(ISubjectTypeService subjectTypeService)
        {
            _subjectTypeService = subjectTypeService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var types = await _subjectTypeService.GetSubjectTypes();
            return Ok(types);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var type = await _subjectTypeService.GetTypeById(id);
            return Ok(type);
        }
    }
}
