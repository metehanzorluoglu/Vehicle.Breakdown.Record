using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using VehicleBreakdownRecord.Entity.DTOs;
using VehicleBreakdownRecord.Entity.Interfaces;
using VehicleBreakdownRecord.Entity.Services;
using VehicleBreakdownRecord.Entity.UnitOfWork;

namespace VehicleBreakdownRecor.Business.Services
{
    public class GenericService<TEntity, TDto> : IGenericService<TEntity, TDto> where TEntity : class where TDto : class
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IGenericRepository<TEntity> _genericRepository;
        private readonly IMapper _mapper;
        public GenericService(IGenericRepository<TEntity> genericRepository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _genericRepository = genericRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<CustomResultDto<TDto>> AddAsync(TDto entity)
        {
            var newEntity=_mapper.Map<TEntity>(entity);
            await _genericRepository.AddAsync(newEntity);
            await _unitOfWork.CommitAsync();
            var newDto=_mapper.Map<TDto>(newEntity);
            return CustomResultDto<TDto>.Success(newDto, 200);
        }

        public async Task<CustomResultDto<IEnumerable<TDto>>> GetAllAsync()
        {
            var entity=_mapper.Map<List<TDto>>(await _genericRepository.GetAllAsync());
            return CustomResultDto<IEnumerable<TDto>>.Success(entity, 200);
        }

        public async Task<CustomResultDto<TDto>> GetByIdAsync(int id)
        {
            var entity= await _genericRepository.GetByIdAsync(id);
            if (entity == null)
                return CustomResultDto<TDto>.Fail(404, "Id is not found!");
            return CustomResultDto<TDto>.Success(_mapper.Map<TDto>(entity),200);
        }

        public async Task<CustomResultDto<NoContentDto>> Remove(int id)
        {
            var isExistEntity = await _genericRepository.GetByIdAsync(id);
            if (isExistEntity == null)
                return CustomResultDto<NoContentDto>.Fail(404, "Id is not found!");
            _genericRepository.Remove(isExistEntity);
            await _unitOfWork.CommitAsync();
            return CustomResultDto<NoContentDto>.Success(204);
        }

        public async Task<CustomResultDto<NoContentDto>> Update(int id,TDto entity)
        {
            var isExistEntity = await _genericRepository.GetByIdAsync(id);
            if (isExistEntity == null)
                return CustomResultDto<NoContentDto>.Fail(404, "Id is not found!");
            var updateEntity= _mapper.Map<TEntity>(entity);
            _genericRepository.Update(updateEntity);
            await _unitOfWork.CommitAsync();
            return CustomResultDto<NoContentDto>.Success(204);
        }

        public async Task<CustomResultDto<IEnumerable<TDto>>> Where(Expression<Func<TEntity, bool>> predicate)
        {
            var list=_genericRepository.Where(predicate);
            return CustomResultDto<IEnumerable<TDto>>.Success(_mapper.Map<IEnumerable<TDto>>(await list.ToListAsync()),200);
        }
    }
}
