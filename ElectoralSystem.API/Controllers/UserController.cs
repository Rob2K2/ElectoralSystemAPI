using AutoMapper;
using ElectoralSystem.API.Core.DTOs;
using ElectoralSystem.API.Core.Handlers;
using ElectoralSystem.API.Repository.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ElectoralSystem.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        public UserController(
            IMediator mediator,
            IMapper mapper)
        {

            _mediator = mediator;
            _mapper = mapper;
        }
        [HttpPost]
        public async Task<IActionResult> CreateUser(UserDto userDto)
        {
            var user = _mapper.Map<User>(userDto); 
            var middle = new CreateUserMiddleData(user);
            var response = await _mediator.Send(middle);

            return Ok(response);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDto loginDto)
        { 
            var middle = new LoginUserMiddleData(loginDto);
            var response = await _mediator.Send(middle);

            return Ok(response);
        }
    }
}
