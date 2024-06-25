using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using RevenueRecognitionSystem.Domain.DTOs;
using RevenueRecognitionSystem.Domain.Enums;
using RevenueRecognitionSystem.Domain.Helpers;
using RevenueRecognitionSystem.Domain.Interfaces.Repositories;
using RevenueRecognitionSystem.Domain.Interfaces.Services;
using RevenueRecognitionSystem.Domain.Models.Client;
using RevenueRecognitionSystem.Domain.Models.SoftwareLicense;
using RevenueRecognitionSystem.Domain.Models.User;
using RevenueRecognitionSystem.Infrastructure;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace RevenueRecognitionSystem.Application.Implementations
{
    public class UserService : IUserService
    {
        private readonly IConfiguration _configuration;
        private readonly ReveuneDbContext _context;
        private readonly IIndividualClientRepository _individualClientRepository;
        private readonly IUnitOfWork _uof;
        public UserService(ReveuneDbContext context, IConfiguration configuration, IIndividualClientRepository individualClientRepo, IUnitOfWork uof)
        {
            _context = context;
            _configuration = configuration;
            _individualClientRepository = individualClientRepo;
            _uof = uof;

        }
        public JWTResponse LoginUser(RevenueRecognitionSystem.Domain.Models.User.LoginRequest loginRequest)
        {
            AppUser user = _context.Users.Where(u => u.Login == loginRequest.Login).FirstOrDefault();

            string passwordHashFromDb = user.Password;
            string curHashedPassword = SecurityHelpers.GetHashedPasswordWithSalt(loginRequest.Password, user.Salt);

            if (passwordHashFromDb != curHashedPassword)
            {
                return null;
            }

            string heh = user.Role.ToString();

            Claim[] userclaim = new[]
            {
            new Claim(ClaimTypes.Name, "szef"),
            new Claim(ClaimTypes.Role, user.Role.ToString()),

        };

            SymmetricSecurityKey key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["SecretKey"]));

            SigningCredentials creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            JwtSecurityToken token = new JwtSecurityToken(
                issuer: "https://localhost:7041",
                audience: "https://localhost:7041",
                claims: userclaim,
                expires: DateTime.Now.AddMinutes(10),
                signingCredentials: creds
            );

            user.RefreshToken = SecurityHelpers.GenerateRefreshToken();
            user.RefreshTokenExp = DateTime.Now.AddDays(1);
            _context.SaveChanges();

            return new JWTResponse
            {
                accessToken = new JwtSecurityTokenHandler().WriteToken(token),
                refreshToken = user.RefreshToken
            };
        }

        public void RegisterUser(RevenueRecognitionSystem.Domain.Models.User.RegisterRequest registerRequest, UserRoles role)
        {
            var hashedPasswordAndSalt = SecurityHelpers.GetHashedPasswordAndSalt(registerRequest.Password);

            var user = new AppUser()
            {
                Email = registerRequest.Email,
                Login = registerRequest.Login,
                Password = hashedPasswordAndSalt.Item1,
                Salt = hashedPasswordAndSalt.Item2,
                RefreshToken = SecurityHelpers.GenerateRefreshToken(),
                RefreshTokenExp = DateTime.Now.AddDays(1),
                Role = role
            };

            _context.Users.Add(user);
            _context.SaveChanges();

        }
        public JWTResponse Refresh(RefreshTokenRequest refreshTokenRequest) 
        { 
            throw new NotImplementedException();
        }
    }
}
