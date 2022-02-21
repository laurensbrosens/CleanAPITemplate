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
    public class DeleteUserCommand : IRequest<bool>
    {
        public int Id { get; set; }
        public DeleteUserCommand(int id)
        {
            Id = id;
        }
        public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand, bool>
        {
            private readonly IUserRepository repo;
            public DeleteUserCommandHandler(IUserRepository repo)
            {
                this.repo = repo;
            }
            public async Task<bool> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
            {
                var removeSucceeded = await repo.Delete(request.Id);
                if (removeSucceeded) return true; // found and deleted
                throw new KeyNotFoundException("Id player to delete doesn't exist."); // not found
            }
        }
    }
}
