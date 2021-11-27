using AutoMapper;
using ConvertMetricUnits.Core.Repository.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ConvertMetricUnits.API.Controllers
{
    [ApiController]
    [Route("api/v{version:apiVersion}/Temparture")]
    [Authorize]
    public class TemparatureController : ControllerBase
    {
        private ITemparatureRepository _repository;
        public TemparatureController (ILogger<TemparatureController> logger, ITemparatureRepository repository)
        {
            _repository = repository;
        }


        [HttpGet("{from}/{to}/{amount}", Name = "GetTemparature")]
        public IActionResult GetTemparature(string from, string to, int amount)
        {
            if (amount == 0)
                return NotFound();

            return Ok(_repository.ConvertTemparature(from, to, amount));
        }
    }
}