using AutoMapper;
using ConvertMetricUnits.Core.Helpers;
using ConvertMetricUnits.Core.Repository.Interfaces;
using ConvertMetricUnits.Data.Models;
using ConvertMetricUnits.Data.Models.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ConvertMetricUnits.API.Controllers
{
    [ApiController]
    [Route("api/v{version:apiVersion}/Users")]
    public class UsersController: ControllerBase
    {
        private readonly IUserRepository _repository;
        private readonly IMapper _mapper;
        public UsersController(IUserRepository repository, IMapper mapper)
        {
            _mapper = mapper;
            _repository = repository;
            
        }

        [AllowAnonymous]
        [HttpPost("authenticate")]
        public IActionResult Authenticate([FromBody] UserDto userDto)
        {
            var user = _repository.Authenticate(userDto.Username, userDto.Password);
            
            if (user == null)
            {
                return BadRequest(new { message = "Username or password is incorrect" });
            }

            //TODO:Log Usage
            return Ok(_mapper.Map<User>(user));
        }

        [AllowAnonymous]
        [HttpPost("register")]
        public IActionResult Register([FromBody] UserDto userDto)
        {
            bool isUniqueUser = _repository.IsUniqueUser(userDto.Username);

            if (!isUniqueUser)
            {
                return BadRequest(new { message = "Username already exists" });
            }
            var user = _repository.Register(userDto.Username, userDto.Password, userDto.Role);

            if (user == null)
            {
                return BadRequest(new { message = "Error while registering" });
            }

            //TODO:Log Usage
            return Ok(_mapper.Map<User>(user));
        }
    }
}
