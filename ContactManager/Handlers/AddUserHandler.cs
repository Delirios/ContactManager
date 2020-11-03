using ContactManager.Commands;
using ContactManager.Repositories;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace ContactManager.Handlers
{
    public class AddUserHandler : IRequestHandler<AddUserCommand>
    {
        private readonly IContactManagerRepository _contactManagerRepository;

        public AddUserHandler(IContactManagerRepository contactManagerRepository)
        {
            _contactManagerRepository = contactManagerRepository;
        }

        public async Task<Unit> Handle(AddUserCommand request, CancellationToken cancellationToken)
        {
            await _contactManagerRepository.AddUser(request.file);
            return Unit.Value;
        }
    }
}
