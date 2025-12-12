using ElectoralSystem.API.Core.Services;
using ElectoralSystem.API.Repository.Interfaces;
using MediatR;
using System.Security.Authentication;

namespace ElectoralSystem.API.Core.Handlers
{
    public class LoginUserMiddleDataHandler : IRequestHandler<LoginUserMiddleData, string>
    {
        private readonly IUserRepository _userRepository;
        private readonly JwtService _jwtService;

        public LoginUserMiddleDataHandler(IUserRepository userRepository, JwtService jwtService)
        {
            _jwtService = jwtService;
            _userRepository = userRepository;
        }
        public async Task<string> Handle(LoginUserMiddleData request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetByLoginAsync(request.LoginDto.Login);

            if (user is null || !BCrypt.Net.BCrypt.Verify(request.LoginDto.Password, user.PasswordHash))
            {
                throw new InvalidCredentialException();
            }

            return _jwtService.GenerateToken(user.Login, user.Id);
        }
    }
}
