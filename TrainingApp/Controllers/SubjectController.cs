using Microsoft.AspNetCore.Mvc;
using TrainingApp.BLL.Interfaces;

namespace TrainingApp.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubjectController : Controller
    {
        private readonly ISubjectService _subjectService;
        public SubjectController(ISubjectService subjectService)
        {
            _subjectService = subjectService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var x = await _subjectService.GetAllTariffs();
            return Ok(x);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var x = await _subjectService.GetTariffById(id);
            return Ok(x);
        }
        [HttpGet("byname/{name}")]
        public async Task<IActionResult> GetByName(string name)
        {
            var x = await _subjectService.GetAllTariffsByName(name);
            return Ok(x);
        }
        [HttpPost("{name}/{type}/{price}")]
        public IActionResult Post(string name, string type, float price)
        {
            _subjectService.AddTariff(name, type, price);
            return Ok();
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _subjectService.DeleteTariff(id);
            return Ok();
        }
    }
}
