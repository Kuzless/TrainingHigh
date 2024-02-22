using Microsoft.AspNetCore.Mvc;
using Training__DAL_.Models;
using TrainingApp.BLL.DTO;
using TrainingApp.BLL.Interfaces;
using TrainingApp.BLL.Services;

namespace TrainingApp.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : Controller
    {
        private readonly IStudentService _studentService;

        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }
        [HttpGet("group/{groupid}")]
        public async Task<IActionResult> GetByGroupId(int groupid) 
        {
            var x = await _studentService.GetStudentsByGroupId(groupid);
            return Ok(x);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var x = await _studentService.GetStudentById(id);
            return Ok(x);
        }
        [HttpPost]
        public IActionResult Post([FromBody] StudentDTO student)
        {
            _studentService.AddStudent(student);
            return Ok(new {});
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _studentService.DeleteStudent(id);
            return Ok();
        }
        [HttpPut]
        public IActionResult Put([FromBody] StudentDTO student)
        {
            _studentService.UpdateStudent(student);
            return Ok();
        }
    }
}
