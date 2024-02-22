using Microsoft.AspNetCore.Mvc;
using TrainingApp.BLL.Interfaces;

namespace TrainingApp.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GroupController : Controller
    {
        private readonly IGroupService _groupService;

        public GroupController(IGroupService groupService)
        {
            _groupService = groupService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var groups = await _groupService.GetAllGroups();
            return Ok(groups);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var group = await _groupService.GetGroupById(id);
            return Ok(group);
        }
    }
}
