using Core.Interfaces;
using Core.Model;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Core.Users.Queries
{
    public class GetUsersByFingerprintQuery : IRequest<User>
    {
        public string Fingerprint { get; }
        public GetUsersByFingerprintQuery(string fingerprint)
        {
            Fingerprint = fingerprint;
        }
        public class GetUsersByIdQueryHandler : IRequestHandler<GetUsersByFingerprintQuery, User>
        {
            private readonly IUserRepository repo;

            public GetUsersByIdQueryHandler(IUserRepository repo)
            {
                this.repo = repo;
            }

            public async Task<User> Handle(GetUsersByFingerprintQuery request, CancellationToken cancellationToken)
            {
                var User = await repo.Get(request.Fingerprint);
                if (User == null) throw new KeyNotFoundException("User was not found.");
                return User;
            }
        }
    }
}
