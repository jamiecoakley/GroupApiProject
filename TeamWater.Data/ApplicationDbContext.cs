using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TeamWater.Data.Entities;

namespace TeamWater.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<UserEntity> Users { get; set; }

        public DbSet<EpisodeEntity> Episodes { get; set; }

        public DbSet<EpisodeReviewEntity> EpisodeReviews { get; set; }

        public DbSet<ShowReviewEntity> ShowReviews { get; set; }

        public DbSet<StreamingPlatformEntity> StreamingPlatforms { get; set; }

        public DbSet<TvShowEntity> TvShows { get; set; }

        private async Task<UserEntity> GetValidUserAsync(TokenRequest model)
        {
            var userEntity = await _context.Users.FirstOrDefaultAsync(user => user.UserName == model.Username);
            if (userEntity is null)
                return null;
            
            var passwordHasher = new PasswordHasher.VerifyHashedPassword(userEntity, userEntity.Password, model.Password);
            
        }
    }
}