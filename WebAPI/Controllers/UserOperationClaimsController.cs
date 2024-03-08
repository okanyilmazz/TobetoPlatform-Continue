using Business.Abstracts;
using Core.CrossCuttingConcerns.Caching;
using Core.CrossCuttingConcerns.Logging.SeriLog.Logger;
using Core.CrossCuttingConcerns.Logging;
using Core.DataAccess.Paging;
using Microsoft.AspNetCore.Mvc;
using Business.Dtos.Requests.OperationClaimRequests;
using Business.Rules.ValidationRules.FluentValidation.OperationClaimValidators;
using Business.Rules.ValidationRules.FluentValidation.UserOperationClaimValidators;
using Business.Dtos.Requests.UserOperationClaimRequests;
using Core.CrossCuttingConcerns.Validation;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserOperationClaimsController : ControllerBase
    {

        IUserOperationClaimService _userOperationClaimService;

        public UserOperationClaimsController(IUserOperationClaimService userOperationClaimService)
        {
            _userOperationClaimService = userOperationClaimService;
        }

        [Logging(typeof(MsSqlLogger))]
        [Logging(typeof(FileLogger))]
        [Cache(60)]
        [HttpGet("GetList")]
        public async Task<IActionResult> GetListAsync([FromQuery] PageRequest pageRequest)
        {
            var result = await _userOperationClaimService.GetListAsync(pageRequest);
            return Ok(result);
        }

        [Logging(typeof(MsSqlLogger))]
        [Logging(typeof(FileLogger))]
        [CacheRemove("UserOperationClaims.Get")]
        [CustomValidation(typeof(CreateUserOperationClaimValidator))]
        [HttpPost]
        public async Task<IActionResult> AddAsync([FromBody] CreateUserOperationClaimRequest createUserOperationClaimRequest)
        {
            var result = await _userOperationClaimService.AddAsync(createUserOperationClaimRequest);
            return Ok(result);
        }

        [Logging(typeof(MsSqlLogger))]
        [Logging(typeof(FileLogger))]
        [CacheRemove("UserOperationClaims.Get")]
        [CustomValidation(typeof(UpdateUserOperationClaimValidator))]
        [HttpDelete]
        public async Task<IActionResult> DeleteAsync([FromBody] DeleteUserOperationClaimRequest deleteUserOperationClaimRequest)
        {
            var result = await _userOperationClaimService.DeleteAsync(deleteUserOperationClaimRequest);
            return Ok(result);
        }

        [Logging(typeof(MsSqlLogger))]
        [Logging(typeof(FileLogger))]
        [CacheRemove("UserOperationClaims.Get")]
        [HttpPut]
        public async Task<IActionResult> UpdateAsync([FromBody] UpdateUserOperationClaimRequest updateUserOperationClaimRequest)
        {
            var result = await _userOperationClaimService.UpdateAsync(updateUserOperationClaimRequest);
            return Ok(result);
        }



        [Logging(typeof(MsSqlLogger))]
        [Logging(typeof(FileLogger))]
        [Cache(60)]
        [HttpGet("GetByUserIdAndOperationClaimId")]
        public async Task<IActionResult> GetByUserIdAndOperationClaimId(Guid userId, Guid operationClaimId)
        {
            var result = await _userOperationClaimService.GetByUserIdAndOperationClaimId(userId, operationClaimId);
            return Ok(result);
        }


        [Logging(typeof(MsSqlLogger))]
        [Logging(typeof(FileLogger))]
        [Cache(60)]
        [HttpGet("GetByUserId")]
        public async Task<IActionResult> GetByUserId(Guid userId )
        {
            var result = await _userOperationClaimService.GetByUserId(userId);
            return Ok(result);
        }
        
    }
}
