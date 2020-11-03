using ContactManager.DbContexts;
using ContactManager.Models;
using ContactManager.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContactManager.Repositories
{
    public class ContactManagerRepository : IContactManagerRepository
    {
        private readonly ContactManagerContext _contactManagerContext;
        private readonly IContactManagerService _contactManagerService;
        public ContactManagerRepository(ContactManagerContext contactManagerContext, IContactManagerService contactManagerService)
        {
            _contactManagerContext = contactManagerContext;
            _contactManagerService = contactManagerService;
        }

        public async Task AddUser(IFormFile file)
        {
            var users = _contactManagerService.ReadCSV(file);
            foreach (var user in users)
            {
                _contactManagerContext.Users.Add(new User
                {
                    Name = user.Name,
                    DateOfBirth = user.DateOfBirth,
                    Married = user.Married,
                    Phone = user.Phone,
                    Salary = user.Salary
                });
            }
            await _contactManagerContext.SaveChangesAsync();
        }

        public async Task DeleteUser(int userId)
        {
            var user = await GetUserById(userId);
            _contactManagerContext.Users.Remove(user);
            await _contactManagerContext.SaveChangesAsync();
        }

        public async Task EditUser(User user)
        {
            _contactManagerContext.Users.Update(user);
            await _contactManagerContext.SaveChangesAsync();

        }

        public async Task<User> GetUserById(int userId)
        {
            return await _contactManagerContext.Users.FirstOrDefaultAsync(u => u.UserId == userId);
        }

        public async Task<IEnumerable<User>> GetUsers()
        {
            return await _contactManagerContext.Users.ToListAsync();
        }
    }
}
