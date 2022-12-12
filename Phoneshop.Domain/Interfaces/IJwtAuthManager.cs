using Phoneshop.Shared.Auth;
using System.Security.Claims;

namespace Phoneshop.Domain.Interfaces
{
    public interface IJwtAuthManager
    {
        JwtAuthResult GenerateTokens(string username, Claim[] claims, DateTime now);
    }
}
