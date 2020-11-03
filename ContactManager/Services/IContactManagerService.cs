using ContactManager.ViewModels;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContactManager.Services
{
    public interface IContactManagerService
    {
        IEnumerable<UserViewModel> ReadCSV(IFormFile file);
    }
}
