using Business.Abstracts;
using Business.Dtos.Requests.OperationClaimRequests;
using Business.Rules.ValidationRules.FluentValidation.OperationClaimValidators;
using Core.CrossCuttingConcerns.Caching;
using Core.CrossCuttingConcerns.Logging.SeriLog.Logger;
using Core.CrossCuttingConcerns.Logging;
using Core.CrossCuttingConcerns.Logging.SeriLog.Logger;
using Core.CrossCuttingConcerns.Validation;
using Core.DataAccess.Paging;
using DataAccess.Abstracts;
using Microsoft.AspNetCore.Mvc;
using Business.Dtos.Requests.OccupationClassSurveyRequests;
using Business.Rules.ValidationRules.FluentValidation.OccupationClassSurveyValidators;
using Core.CrossCuttingConcerns.Validation;
using Business.Dtos.Requests.OperationClaimRequests;
using Business.Rules.ValidationRules.FluentValidation.OperationClaimValidators;
using Microsoft.AspNetCore.Authorization;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OperationClaimsController : ControllerBase
    {
        IOperationClaimService _operationClaimService;

        public OperationClaimsController(IOperationClaimService operationClaimService)
        {
            _operationClaimService = operationClaimService;
        }

        [Logging(typeof(MsSqlLogger))]
        [Logging(typeof(FileLogger))]
        [Cache(60)]
        [HttpGet("GetList")]
        public async Task<IActionResult> GetListAsync([FromQuery] PageRequest pageRequest)
        {
            var result = await _operationClaimService.GetListAsync(pageRequest);
            return Ok(result);
        }

        [Logging(typeof(MsSqlLogger))]
        [Logging(typeof(FileLogger))]
        [CacheRemove("OperationClaims.Get")]
        [CustomValidation(typeof(CreateOperationClaimValidator))]
        [HttpPost("Add")]
        public async Task<IActionResult> AddAsync([FromBody] CreateOperationClaimRequest createOperationClaimRequest)
        {
            var result = await _operationClaimService.AddAsync(createOperationClaimRequest);
            return Ok(result);
        }

        [Logging(typeof(MsSqlLogger))]
        [Logging(typeof(FileLogger))]
    [Cache(60)]
    [HttpGet("GetByUserId")]
    public async Task<IActionResult> GetByUserIdAsync(Guid userId)
    {
        var result = await _operationClaimService.GetByUserIdAsync(userId);
        return Ok(result);
    }

    [Logging(typeof(MsSqlLogger))]
    [Logging(typeof(FileLogger))]
        [CacheRemove("OperationClaims.Get")]
        [HttpPost("Delete")]
        public async Task<IActionResult> DeleteAsync([FromBody] DeleteOperationClaimRequest deleteOperationClaimRequest)
        {
            var result = await _operationClaimService.DeleteAsync(deleteOperationClaimRequest);
            return Ok(result);
        }

        [Logging(typeof(MsSqlLogger))]
        [Logging(typeof(FileLogger))]
        [CacheRemove("OperationClaims.Get")]
        [CustomValidation(typeof(UpdateOperationClaimValidator))]
        [HttpPost("Update")]
        public async Task<IActionResult> UpdateAsync([FromBody] UpdateOperationClaimRequest updateOperationClaimRequest)
        {
            var result = await _operationClaimService.UpdateAsync(updateOperationClaimRequest);
            return Ok(result);
        }

    }
}
