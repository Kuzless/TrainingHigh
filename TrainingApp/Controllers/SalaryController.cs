using Microsoft.AspNetCore.Mvc;
using TrainingApp.BLL.DTO;
using TrainingApp.BLL.Interfaces;

namespace TrainingApp.Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SalaryController : Controller
    {
        private readonly ISalaryService _salaryService;

        public SalaryController(ISalaryService salaryService)
        {
            _salaryService = salaryService;
        }
        [HttpGet("{teacherid}")]
        public async Task<IActionResult> GetByTeacherId(int teacherid) 
        {
            var x = await _salaryService.GetSalaryByTeacherId(teacherid);
            return Ok(x);
        }
        [HttpPost]
        public IActionResult Post([FromBody] SalaryDTO salary)
        {
            _salaryService.AddSalary(salary);
            return Ok();
        }
        [HttpDelete]
        public IActionResult Delete([FromBody] SalaryDTO salary)
        {
            _salaryService.DeleteSalary(salary);
            return Ok();
        }
    }
}
