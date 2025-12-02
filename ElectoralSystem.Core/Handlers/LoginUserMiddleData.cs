using ElectoralSystem.API.Core.DTOs;
using MediatR;

namespace ElectoralSystem.API.Core.Handlers
{
    public class LoginUserMiddleData : IRequest<string>
    {
        public LoginDto LoginDto { get; set; }
        public LoginUserMiddleData(LoginDto loginDto)
        {
            LoginDto = loginDto;
        }
    }
}
