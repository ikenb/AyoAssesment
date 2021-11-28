using AutoMapper;
using ConvertMetricUnits.Core.Repository.Interfaces;
using ConvertMetricUnits.Data.Models.Dtos;
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
        public TemparatureController (ITemparatureRepository repository)
        {
            _repository = repository;
        }


        [HttpGet("getTemparature")]
        public IActionResult GetTemparature([FromBody] TemparatureDto temparatureDto)
        {
            if (temparatureDto.Amount == 0)
                return NotFound();

            return Ok(_repository.ConvertTemparature(temparatureDto.From, temparatureDto.To, temparatureDto.Amount));
        }
    }
}