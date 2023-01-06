using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TeamWater.Data.Entities;
using TeamWater.Models.Token;

namespace TeamWater.Services.Token
{
    public class TokenService : ITokenService
    {
        public async Task<TokenResponse> GetTokenAsync(TokenRequest model)
        {
            var UserEntity = await GetValidUserAsync(model);
            if (userEntity is null)
                return null;

            return GenerateToken(userEntity);
        }

        private async Task<UserEntity> GetValidUserAsync(TokenRequest model) 
        { 
            var userEntity = await GetValidUserAsync(model);
            if (userEntity is null)
                return null;
            
            return GenerateToken(userEntity);
        }

        private TokenResponse GenerateToken(UserEntity entity) { }
    }
}