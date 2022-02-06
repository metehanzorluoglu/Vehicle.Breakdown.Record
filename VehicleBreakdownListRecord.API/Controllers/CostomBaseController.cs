using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VehicleBreakdownRecord.Entity.DTOs;

namespace VehicleBreakdownListRecord.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CostomBaseController : ControllerBase
    {
        [NonAction]
        public IActionResult CreateActionResult<T>(CostomResultDto<T> costomResultDto)
        {
            if (costomResultDto.StatusCode==204)
                return new ObjectResult(null)
                {
                    StatusCode = costomResultDto.StatusCode
                };
            return new ObjectResult(costomResultDto)
            {
                StatusCode = costomResultDto.StatusCode
            };
        }
    }
}
