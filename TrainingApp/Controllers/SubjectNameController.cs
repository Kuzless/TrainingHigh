using Microsoft.AspNetCore.Mvc;
using TrainingApp.BLL.Interfaces;
using TrainingApp.BLL.Services;

namespace TrainingApp.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubjectNameController : Controller
    {
        private readonly ISubjectNameService _subjectNameService;
        public SubjectNameController(ISubjectNameService subjectNameService)
        {
            _subjectNameService = subjectNameService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var names = await _subjectNameService.GetSubjectNames();
            return Ok(names);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var name = await _subjectNameService.GetNameById(id);
            return Ok(name);
        }
    }
}
