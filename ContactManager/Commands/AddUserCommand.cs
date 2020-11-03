using ContactManager.ViewModels;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContactManager.Commands
{
    public class AddUserCommand : IRequest
    {
        public IFormFile file { get; set; }
    }
}
