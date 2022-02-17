using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using VehicleBreakdownRecord.Entity.DTOs;

namespace VehicleBreakdownRecord.Entity.Services
{
    public interface IGenericService<TEntity, TDto> where TEntity : class where TDto : class
    {
        Task<CustomResultDto<TDto>> GetByIdAsync(int id);
        Task<CustomResultDto<IEnumerable<TDto>>> GetAllAsync();
        Task<CustomResultDto<IEnumerable<TDto>>> Where(Expression<Func<TEntity, bool>> predicate);
        Task<CustomResultDto<TDto>> AddAsync(TDto entity);
        Task<CustomResultDto<NoContentDto>> Remove(int id);
        Task<CustomResultDto<NoContentDto>> Update(int id,TDto entity);

    }
}
