using Microsoft.AspNetCore.Mvc;
using TrainingApp.BLL.DTO;
using TrainingApp.BLL.Interfaces;

namespace TrainingApp.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkedHoursController : Controller
    {
        private readonly IWorkedHoursService _workedHoursService;

        public WorkedHoursController(IWorkedHoursService workedHoursService)
        {
            _workedHoursService = workedHoursService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var x = await _workedHoursService.GetAllWorkedHours();
            return Ok(x);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var x = await _workedHoursService.GetWorkedHoursById(id);
            return Ok(x);
        }
        [HttpPost]
        public IActionResult Post([FromBody] WorkedHoursDTO workedHoursDTO)
        {
            _workedHoursService.AddWorkedHours(workedHoursDTO);
            return Ok();
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _workedHoursService.DeleteWorkedHours(id);
            return Ok();
        }
        [HttpPut]
        public IActionResult Put([FromBody] WorkedHoursDTO workedHoursDTO)
        {
            _workedHoursService.UpdateWorkedHours(workedHoursDTO);
            return Ok();
        }
    }
}
