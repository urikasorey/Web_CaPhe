using Microsoft.AspNetCore.Identity;

namespace Web_CaPhee2_api.Models.Interface
{
	public interface ITokenRepository
	{
		string CreateJWTToken(IdentityUser user, List<string> roles);
		Task<string> GetTokenAsync();
	}
}
