﻿using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Web_CaPhee2_api.DTO;
using Web_CaPhee2_api.Models.Interface;

namespace Web_CaPhee2_api.Models.Services
{
	public class TokenRepository:ITokenRepository
	{
		private readonly IConfiguration _configuration;
		private readonly HttpClient _httpClient;

		public TokenRepository(IConfiguration configuration, IHttpClientFactory httpClientFactory)
		{
			_configuration = configuration;
			_httpClient = httpClientFactory.CreateClient();
		}

		public string CreateJWTToken(IdentityUser user, List<string> roles)
		{
			var claims = new List<Claim>
			{
				new Claim(ClaimTypes.Email, user.Email)
			};
			foreach (var role in roles)
			{
				claims.Add(new Claim(ClaimTypes.Role, role));
			}

			var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
			var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

			var token = new JwtSecurityToken(
				issuer: _configuration["Jwt:Issuer"],
				audience: _configuration["Jwt:Audience"],
				claims: claims,
				expires: DateTime.Now.AddMinutes(15),
				signingCredentials: credentials);

			return new JwtSecurityTokenHandler().WriteToken(token);
		}

		public async Task<string> GetTokenAsync()
		{
			var loginData = new { Email = "user@example.com", Password = "password" };
			var content = new StringContent(JsonConvert.SerializeObject(loginData), Encoding.UTF8, "application/json");

			var response = await _httpClient.PostAsync("https://localhost:7182/api/auth/login", content);

			if (response.IsSuccessStatusCode)
			{
				var responseData = await response.Content.ReadAsStringAsync();
				var tokenResponse = JsonConvert.DeserializeObject<TokenResponse>(responseData);
				return tokenResponse.Token;
			}

			throw new Exception("Failed to retrieve token.");
		}
	}
}
