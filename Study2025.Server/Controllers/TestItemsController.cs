using Microsoft.AspNetCore.Mvc;

namespace Study2025.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TestItemsController : ControllerBase
    {
        private readonly TestRepository _repository;

        public TestItemsController(TestRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var items = await _repository.GetAllItems();
            return Ok(items);
        }

 
    }
}
