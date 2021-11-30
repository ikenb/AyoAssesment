using AutoMapper;
using ConvertMetricUnits.Core.Helpers;
using ConvertMetricUnits.Core.Repository.Interfaces;
using ConvertMetricUnits.Data.Models.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ConvertMetricUnits.API.Controllers
{
    [ApiController]
    [Route("api/v{version:apiVersion}/Length")]
    [Authorize]
    public class LengthController : ControllerBase
    {
        private readonly ILengthRepository _repository;

        public LengthController(ILengthRepository repository)
        {
            _repository = repository;
        }


        [HttpGet("GetLength")]
        public IActionResult GetLength([FromBody] LengthDto lengthDto)
        {

            if (lengthDto.Amount == 0)
                return NotFound();

            return Ok(_repository.ConvertLength(lengthDto.From, lengthDto.To, lengthDto.Amount));

        }
    }
}