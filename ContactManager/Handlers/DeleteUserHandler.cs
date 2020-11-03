using ContactManager.Commands;
using ContactManager.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ContactManager.Handlers
{
    public class DeleteUserHandler : IRequestHandler<DeleteUserCommand>
    {
        private readonly IContactManagerRepository _contactManagerRepository;
        public DeleteUserHandler(IContactManagerRepository contactManagerRepository)
        {
            _contactManagerRepository = contactManagerRepository;
        }

        public async Task<Unit> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            await _contactManagerRepository.DeleteUser(request.UserId);
            return Unit.Value;
        }
    }
}
