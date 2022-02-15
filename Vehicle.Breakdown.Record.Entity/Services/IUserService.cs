using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using VehicleBreakdownRecord.Entity.DTOs;

namespace VehicleBreakdownRecord.Entity.Services
{
    public interface IUserService
    {
        Task<CustomResultDto<UserAppDto>> CreateUserAsync(CreateUserDto createUserDto);
        Task<CustomResultDto<UserAppDto>> GetUserByNameAsync(string userName);
    }
}
