using Core.Interfaces;
using Core.Model;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Core.Users.Commands
{
    public class AddUserCommand : IRequest<User>
    {
        public User User { get; }
        public AddUserCommand(User User)
        {
            this.User = User;
        }

        public class AddUserCommandHandler : IRequestHandler<AddUserCommand, User>
        {
            private readonly IUserRepository repo;

            public AddUserCommandHandler(IUserRepository repo)
            {
                this.repo = repo;
            }
            public async Task<User> Handle(AddUserCommand request, CancellationToken cancellationToken)
            {
                var result = await repo.Add(request.User);
                if (result != null) return result;
                throw new ArgumentNullException("Can't add user that is null.");
            }
        }
    }
}
