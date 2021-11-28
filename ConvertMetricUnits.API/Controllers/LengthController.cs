using AutoMapper;
using ConvertMetricUnits.Core.Helpers;
using ConvertMetricUnits.Core.Repository.Interfaces;
using ConvertMetricUnits.Data.Models.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ConvertMetricUnits.API.Controllers
{
    [ApiController]
    [Route("api/v{version:apiVersion}/length")]
    //[Authorize]
    public class LengthController : ControllerBase
    {
        private readonly ILengthRepository _repository;

        public LengthController(ILogger<LengthController> logger, ILengthRepository repository)
        {
            _repository = repository;
    }


        [HttpGet("getlength")]
        public IActionResult GetLength([FromBody] LengthDto lengthDto)
        {
            LogHelper.LogUsage("Test","test");
            LogHelper.LogErrors(new NullReferenceException());

            if (lengthDto.Amount == 0)
                return NotFound();

            return Ok(_repository.ConvertLengthAsync(lengthDto.From, lengthDto.To, lengthDto.Amount));
     
        }
    }
}