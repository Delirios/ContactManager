using ContactManager.Models;
using ContactManager.Queries;
using ContactManager.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ContactManager.Handlers
{
    public class GetUserByIdHandler : IRequestHandler<GetUserByIdQuery, User>
    {
        private readonly IContactManagerRepository _contactManagerRepository;
        public GetUserByIdHandler(IContactManagerRepository contactManagerRepository)
        {
            _contactManagerRepository = contactManagerRepository;
        }

        public async Task<User> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            return await _contactManagerRepository.GetUserById(request.UserId);
        }
    }
}
