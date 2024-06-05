﻿using Web_CaPhe.DTO;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Data;

namespace PetShopsMVC.Controllers
{
    public class AccountController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IConfiguration _configuration;
        private readonly ILogger<AccountController> _logger;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public AccountController(IHttpClientFactory httpClientFactory, IConfiguration configuration, ILogger<AccountController> logger, IHttpContextAccessor httpContextAccessor)
        {
            _httpClientFactory = httpClientFactory;
            _configuration = configuration;
            _logger = logger;
            _httpContextAccessor = httpContextAccessor;
        }

        private HttpClient CreateHttpClient()
        {
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_configuration["ApiBaseUrl"]);
            var token = _httpContextAccessor.HttpContext.Session.GetString("JWToken");
            if (!string.IsNullOrEmpty(token))
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            }
            return client;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterRequestDTO registerRequestDTO)
        {
            var client = CreateHttpClient();
            var response = await client.PostAsJsonAsync("Account/Register", registerRequestDTO);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Login");
            }
            ModelState.AddModelError(string.Empty, "Registration failed");
            return View(registerRequestDTO);
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginRequestDTO loginRequestDTO)
        {
            CreateHttpClient();
            var client = _httpClientFactory.CreateClient();
            _logger.LogInformation("Gửi yêu cầu đăng nhập đến {url}", client.BaseAddress + "Account/Login");
            client.BaseAddress = new Uri(_configuration["ApiBaseUrl"]);
            var response = await client.PostAsJsonAsync("Account/Login", loginRequestDTO);
            if (response.IsSuccessStatusCode)
            {
                var loginResponse = await response.Content.ReadFromJsonAsync<LoginResponseDTO>();
                HttpContext.Session.SetString("JWToken", loginResponse.JwtToken);

                var handler = new JwtSecurityTokenHandler();
                var token = handler.ReadJwtToken(loginResponse.JwtToken);
                var username = token.Claims.FirstOrDefault(claim => claim.Type == ClaimTypes.Email)?.Value;
                var roles = token.Claims.Where(claim => claim.Type == ClaimTypes.Role).Select(claim => claim.Value).ToList();

                if (!string.IsNullOrEmpty(username))
                {
                    HttpContext.Session.SetString("Username", username);
                }
                if (roles.Contains("Admin"))
                {
                    return RedirectToAction("Index", "Admin");
                }
                return RedirectToAction("Index", "Product");

            }
            _logger.LogError("Đăng nhập thất bại với mã trạng thái {statusCode}", response.StatusCode);
            ModelState.AddModelError(string.Empty, "Login failed");
            return View(loginRequestDTO);
        }

        [HttpGet]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Product");
        }
    }
}
