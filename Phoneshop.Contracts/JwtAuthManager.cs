using Phoneshop.Domain.Interfaces;
using Phoneshop.Shared.Auth;
using System.Security.Claims;

namespace Phoneshop.Contracts
{
    public class JwtAuthManager : IJwtAuthManager
    {
        public JwtAuthResult GenerateTokens(string username, Claim[] claims, DateTime now)
        {
            throw new NotImplementedException();
        }
    }
}