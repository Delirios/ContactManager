using ContactManager.Commands;
using ContactManager.Models;
using ContactManager.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ContactManager.Handlers
{
    public class EditUserHandler : IRequestHandler<EditUserCommand>
    {
        private readonly IContactManagerRepository _contactManagerRepository;
        public EditUserHandler(IContactManagerRepository contactManagerRepository)
        {
            _contactManagerRepository = contactManagerRepository;
        }
        public async Task<Unit> Handle(EditUserCommand request, CancellationToken cancellationToken)
        {
            await _contactManagerRepository.EditUser(new User
            {
                UserId = request.UserId,
                Name = request.Name,
                DateOfBirth = request.DateOfBirth,
                Married = request.Married,
                Phone = request.Phone,
                Salary = request.Salary
            });
            return Unit.Value;
        }
    }
}
