using Microsoft.AspNetCore.Mvc;
using TrainingApp.BLL.DTO;
using TrainingApp.BLL.Interfaces;
using TrainingApp.BLL.Services;

namespace TrainingApp.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GetAllController : Controller
    {
        private readonly IGetAllService _getAllService;
        public GetAllController(IGetAllService getAllService)
        {
            _getAllService = getAllService;
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByWorkedHoursDTO(int id)
        {
            var group = await _getAllService.GetAllByWorkedId(id);
            return Ok(group);
        }
    }
}
