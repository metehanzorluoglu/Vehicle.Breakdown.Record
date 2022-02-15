using AutoMapper;
using AutoMapper.Internal.Mappers;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleBreakdownRecord.Entity.DTOs;
using VehicleBreakdownRecord.Entity.Entities;
using VehicleBreakdownRecord.Entity.Services;

namespace VehicleBreakdownRecor.Business.Services
{
    public class UserService : IUserService
    {
        private readonly UserManager<UserApp> _userManager;
        private readonly IMapper _mapper;

        public UserService(UserManager<UserApp> userManager, IMapper mapper)
        {
            _userManager = userManager;
            _mapper = mapper;
        }

        public async Task<CustomResultDto<UserAppDto>> CreateUserAsync(CreateUserDto createUserDto)
        {
            var user=new UserApp { Email = createUserDto.Email,UserName=createUserDto.UserName };
            var result= await _userManager.CreateAsync(user,createUserDto.Password);

            if (!result.Succeeded)
            {
                var errors=result.Errors.Select(x=>x.Description).ToList();
                return CustomResultDto<UserAppDto>.Fail(400,errors);
            }

            return CustomResultDto<UserAppDto>.Success(_mapper.Map<UserAppDto>(user), 200);
        }

        public async Task<CustomResultDto<UserAppDto>> GetUserByNameAsync(string userName)
        {
            var user= await _userManager.FindByNameAsync(userName);
            if (user == null)
                return CustomResultDto<UserAppDto>.Fail(404, "User Name is not found!");
            return CustomResultDto<UserAppDto>.Success(_mapper.Map<UserAppDto>(user), 200);

        }
    }
}
