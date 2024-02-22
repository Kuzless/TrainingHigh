using Microsoft.AspNetCore.Mvc;
using TrainingApp.BLL.DTO;
using TrainingApp.BLL.Interfaces;
using TrainingApp.BLL.Services;

namespace TrainingApp.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeacherController : Controller
    {
        private readonly ITeacherService _teacherService;

        public TeacherController(ITeacherService teacherService)
        {
            _teacherService = teacherService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var x = await _teacherService.GetAllTeachers();
            return Ok(x);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var x = await _teacherService.GetTeacherById(id);
            return Ok(x);
        }
        [HttpPost]
        public IActionResult Post([FromBody] TeacherInfoDTO teacher)
        {
            _teacherService.AddTeacher(teacher);
            return Ok();
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _teacherService.DeleteTeacher(id);
            return Ok();
        }
        [HttpPut]
        public IActionResult Put([FromBody] TeacherInfoDTO teacher)
        {
            _teacherService.UpdateTeacher(teacher);
            return Ok();
        }
    }
}
