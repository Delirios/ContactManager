using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContactManager.Commands
{
    public class DeleteUserCommand : IRequest
    {
        public int UserId { get; set; }
    }
}
