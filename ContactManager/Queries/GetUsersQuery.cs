using ContactManager.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContactManager.Queries
{
    public class GetUsersQuery : IRequest<IEnumerable<User>>
    {
    }
}
