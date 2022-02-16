using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using VehicleBreakdownRecord.Entity.DTOs;
using VehicleBreakdownRecord.Entity.Services;

namespace VehicleBreakdownListRecord.API.Controllers
{
    
    public class AuthController : CustomBaseController
    {
        private readonly IAuthenticationService _authenticationService;

        public AuthController(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> CreateToken(LoginDto loginDto) 
        {
            var result= await _authenticationService.CreateTokenAsync(loginDto);
            return CreateActionResult(result);
        }

        [HttpPost]
        [Route("[action]")]
        public IActionResult CreateTokenByClient(ClientLoginDto clientLoginDto)
        {
            var result= _authenticationService.CreateTokenByClient(clientLoginDto);
            return CreateActionResult(result);
        }
        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> RevokeRefreshToken(RefreshTokenDto refreshTokenDto)
        {
            var result =await _authenticationService.RevokeRefreshTokenAsync(refreshTokenDto.Token);
            return CreateActionResult(result);
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> CreateTokenByRefreshToken(RefreshTokenDto refreshTokenDto)
        {
            var result = await _authenticationService.CreateTokenByRefreshAsync(refreshTokenDto.Token);
            return CreateActionResult(result);
        }
    }
}
