using Core.Interfaces;
using Core.Model;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Core.Users.Commands
{
    public class UpdateUserCommand : IRequest<User>
    {
        public User User { get; set; }

        public UpdateUserCommand(User User)
        {
            this.User = User;
        }

        public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, User>
        {
            private readonly IUserRepository repo;

            public UpdateUserCommandHandler(IUserRepository repo)
            {
                this.repo = repo;
            }
            public async Task<User> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
            {
                return await repo.Update(request.User);
            }
        }
    }
}
