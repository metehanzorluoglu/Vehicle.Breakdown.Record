using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using VehicleBreakdownRecord.Entity.DTOs;

namespace VehicleBreakdownRecord.Entity.Services
{
    public interface IAuthenticationService
    {
        Task<CustomResultDto<TokenDto>> CreateTokenAsync(LoginDto loginDto);
        Task<CustomResultDto<TokenDto>> CreateTokenByRefreshAsync(string refreshToken);
        Task<CustomResultDto<NoContentDto>> RevokeRefreshTokenAsync(string refreshToken);
        CustomResultDto<ClientTokenDto> CreateTokenByClient(ClientLoginDto clientLoginDto);
    }
}
