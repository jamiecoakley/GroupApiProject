using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TeamWater.Data;
using TeamWater.Data.Entities;
using TeamWater.Models.User;

namespace TeamWater.Services.User
{
    public class UserService : IUserService
    {
        private readonly ApplicationDbContext _context;
        public UserService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> RegisterUserAsync(UserRegister model)
        {
            if (await GetUserByEmailAsync(model.Email) != null || await GetUserByUserNameAsync(model.UserName) != null)
                return false;

            var entity = new UserEntity
            {
                Name = model.Name,
                Email = model.Email,
                UserName = model.UserName,
                Password = model.Password
            };

            _context.Users.Add(entity);
            var numbeOfChanges = await _context.SaveChangesAsync();

            return numbeOfChanges == 1;
        }
        
        private async Task<UserEntity>GetUserByEmailAsync(string email)
        {
            return await _context.Users.FirstOrDefaultAsync(user => user.Email.ToLower() == email.ToLower());
        }

        private async Task<UserEntity> GetUserByUserNameAsync(string userName)
        {
            return await _context.Users.FirstOrDefaultAsync(user => user.UserName.ToLower() == userName.ToLower());
        }

    }
}