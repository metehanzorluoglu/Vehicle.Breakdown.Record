using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleBreakdownRecor.Business.Interfaces;
using VehicleBreakdownRecord.DAL.Interfaces;
using VehicleBreakdownRecord.Entity.Configurations;
using VehicleBreakdownRecord.Entity.DTOs;
using VehicleBreakdownRecord.Entity.Entities;
using VehicleBreakdownRecord.Entity.Interfaces;
using VehicleBreakdownRecord.Entity.Services;
using VehicleBreakdownRecord.Entity.UnitOfWork;

namespace VehicleBreakdownRecor.Business.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly List<Client> _clients;
        private readonly ITokenService _tokenService;
        private readonly UserManager<UserApp> _userManager;
        private readonly IGenericRepository<UserRefreshToken> _userRefreshTokenService;
        private readonly IUnitOfWork _unitOfWork;
        public AuthenticationService(ITokenService tokenService, IOptions<List<Client>> optionsClient, UserManager<UserApp> userManager, IGenericRepository<UserRefreshToken> userRefreshTokenService, IUnitOfWork unitOfWork)
        {
            _tokenService = tokenService;
            _userManager = userManager;
            _clients = optionsClient.Value;
            _userRefreshTokenService = userRefreshTokenService;
            _unitOfWork = unitOfWork;
        }



        public CustomResultDto<ClientTokenDto> CreateTokenByClient(ClientLoginDto clientLoginDto)
        {
            var client = _clients.SingleOrDefault(x => x.Id == clientLoginDto.ClientId && x.Secret == clientLoginDto.ClientSecret);
            if (client == null)
                return CustomResultDto<ClientTokenDto>.Fail(404, "Client Id or Client Secret is wrong!");

            var token = _tokenService.CreateTokenByClient(client);
            return CustomResultDto<ClientTokenDto>.Success(token, 200);
        }

        public async Task<CustomResultDto<TokenDto>> CreateTokenAsync(LoginDto loginDto)
        {
            if(loginDto == null)throw new ArgumentNullException(nameof(loginDto));
            var user= await _userManager.FindByEmailAsync(loginDto.Email);

            if (user == null)
                return CustomResultDto<TokenDto>.Fail(400, "Email or Password is wrong!");
            if(!await _userManager.CheckPasswordAsync(user, loginDto.Password))
                return CustomResultDto<TokenDto>.Fail(400, "Email or Password is wrong!");

            var token= _tokenService.CreateToken(user);

            var userRefreshToken = await _userRefreshTokenService.Where(x => x.UserId == user.Id).SingleOrDefaultAsync();
            if (userRefreshToken == null)
            {
                await _userRefreshTokenService.AddAsync(new UserRefreshToken
                {
                    UserId = user.Id,
                    Code = token.RefreshToken,
                    Expiration = token.RefreshTokenExpiration
                });
            }
            else
            {
                userRefreshToken.Code = token.RefreshToken;
                userRefreshToken.Expiration = token.RefreshTokenExpiration;
            }

            await _unitOfWork.CommitAsync();
            return CustomResultDto<TokenDto>.Success(token, 200);
        }

        public async Task<CustomResultDto<TokenDto>> CreateTokenByRefreshAsync(string refreshToken)
        {
            var existRefreshToken=await _userRefreshTokenService
                .Where(x=>x.Code == refreshToken)
                .SingleOrDefaultAsync();
            if (existRefreshToken == null)
                return CustomResultDto<TokenDto>.Fail(404, "Refresh Token is not found!");
            var user = await _userManager.FindByIdAsync(existRefreshToken.UserId);
            if(user == null)
                return CustomResultDto<TokenDto>.Fail(404, "User Id is not found!");

            var tokenDto= _tokenService.CreateToken(user);

            existRefreshToken.Code = tokenDto.RefreshToken;
            existRefreshToken.Expiration = tokenDto.RefreshTokenExpiration;

            await _unitOfWork.CommitAsync();
            return CustomResultDto<TokenDto>.Success(tokenDto, 200);
        }

        public async Task<CustomResultDto<NoContentDto>> RevokeRefreshTokenAsync(string refreshToken)
        {
            var existRefreshToken = await _userRefreshTokenService
                .Where(x => x.Code == refreshToken)
                .SingleOrDefaultAsync();
            if (existRefreshToken == null)
                return CustomResultDto<NoContentDto>.Fail(404, "Refresh Token is not found!");

            _userRefreshTokenService.Remove(existRefreshToken);

            await _unitOfWork.CommitAsync();
            return CustomResultDto<NoContentDto>.Success(200);
        }
    }
}
