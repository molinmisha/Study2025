using Microsoft.AspNetCore.Mvc;

namespace Study2025.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TestItemsController : ControllerBase
    {
        private readonly TestRepositoryDapper _repository;

        public TestItemsController(TestRepositoryDapper repository)
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
