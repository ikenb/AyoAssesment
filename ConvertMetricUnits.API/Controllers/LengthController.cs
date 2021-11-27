using ConvertMetricUnits.Core.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ConvertMetricUnits.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LengthController : ControllerBase
    {
        private ILengthRepository _repository;

        private readonly ILogger<LengthController> _logger;

        public LengthController(ILogger<LengthController> logger, ILengthRepository repository)
        {
            _logger = logger;
            _repository = repository;
    }

    
        [HttpGet("{from}/{to}/{amount}", Name = "GetLength")]
        public IActionResult GetLength(string from, string to, int amount)
        {
            if (amount == 0)
                return NotFound();

            var test = _repository.ConvertLengthAsync(from, to, amount);

            return Ok(test);
        }
    }
}