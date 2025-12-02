using ElectoralSystem.API.Core.DTOs;
using ElectoralSystem.API.Repository.Entities;
using MediatR;

namespace ElectoralSystem.API.Core.Handlers
{
    public class CreateUserMiddleData : IRequest<User>
    {
        public User User { get; set; }
        public CreateUserMiddleData(User user)
        {
            User = user;
        }
    }
}
