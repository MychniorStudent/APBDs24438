using RevenueRecognitionSystem.Domain.DTOs;
using RevenueRecognitionSystem.Domain.Enums;
using RevenueRecognitionSystem.Domain.Models.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevenueRecognitionSystem.Domain.Interfaces.Services
{
    public interface IUserService
    {
        void RegisterUser(RevenueRecognitionSystem.Domain.Models.User.RegisterRequest registerRequest, UserRoles role);
        JWTResponse LoginUser(RevenueRecognitionSystem.Domain.Models.User.LoginRequest loginRequest);
        public JWTResponse Refresh(RefreshTokenRequest refreshTokenRequest);
        //public JWTResponse AddClient(RefreshTokenRequest refreshTokenRequest);
    }
}
