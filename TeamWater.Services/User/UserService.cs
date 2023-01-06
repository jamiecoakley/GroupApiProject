using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TeamWater.Data.Entities;
using TeamWater.Models.User;
using TeamWater.Data;

namespace TeamWater.Services.User
{
    private readonly ApplicationDbContext _context;
    public UserService(ApplicationDbContext context) 
    {
        _context = context;
    }


    public class UserService : IUserService
    {
        public async Task<bool> RegisterUserAsync(UserRegister model)
        {
            var entity = new UserEntity
            {
                Email = model.Email,
                UserName = model.Username,
                Password = model.Password,
                DateCreated = DateTime.Now
            };

            _context.Users.Add(entity);
            var numberOfChanges = await _context.SaveChangesAsync();

            return numberOfChanges == 1;
        }
    }
}