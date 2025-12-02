using ElectoralSystem.API.Repository.Entities;
using ElectoralSystem.API.Repository.Interfaces;
using MediatR;

namespace ElectoralSystem.API.Core.Handlers
{
    public class CreateUserMiddleDataHandler : IRequestHandler<CreateUserMiddleData, User>
    {
        private readonly IUserRepository _repository;
        public CreateUserMiddleDataHandler(IUserRepository repository)
        {
            _repository = repository;
        }
        public async Task<User> Handle(CreateUserMiddleData request, CancellationToken cancellationToken)
        {
            request.User.PasswordHash = BCrypt.Net.BCrypt.HashPassword(request.User.PasswordHash);

            return await _repository.CreateAsync(request.User);
        }
    }
}
