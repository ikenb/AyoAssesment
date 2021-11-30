using AutoMapper;
using ConvertMetricUnits.Core.Repository.Interfaces;
using ConvertMetricUnits.Data.Models.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ConvertMetricUnits.API.Controllers
{
    [ApiController]
    [Route("api/v{version:apiVersion}/Weight")]
    [Authorize]
    public class WeightController : ControllerBase
    {
        private IWeightRepository _repository;

        public WeightController(IWeightRepository repository)
        {
            _repository = repository;
        }

        [HttpGet("GetWeight")]
        public IActionResult GetWeight([FromBody] WeightDto weightDto)
        {
            if (weightDto.Amount == 0)
                return NotFound();

            return Ok(_repository.ConvertWeight(weightDto.From, weightDto.To, weightDto.Amount));
        }
    }
}