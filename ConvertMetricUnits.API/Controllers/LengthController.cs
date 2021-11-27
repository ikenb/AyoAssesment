using AutoMapper;
using ConvertMetricUnits.Core.Helpers;
using ConvertMetricUnits.Core.Repository.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ConvertMetricUnits.API.Controllers
{
    [ApiController]
    [Route("api/v{version:apiVersion}/Length")]
    //[Authorize]
    public class LengthController : ControllerBase
    {
        private readonly ILengthRepository _repository;

        public LengthController(ILogger<LengthController> logger, ILengthRepository repository)
        {
            _repository = repository;
    }

    
        [HttpGet("{from}/{to}/{amount}", Name = "GetLength")]
        public IActionResult GetLength(string from, string to, int amount)
        {
            LogHelper.LogUsage("Test","test");
            LogHelper.LogErrors(new NullReferenceException());

            if (amount == 0)
                return NotFound();

            return Ok(_repository.ConvertLengthAsync(from, to, amount));
     
        }
    }
}