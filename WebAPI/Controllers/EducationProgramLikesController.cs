using Business.Abstracts;
using Business.Dtos.Requests.EducationProgramLikeRequests;
using Business.Rules.ValidationRules.FluentValidation.EducationProgramLikeValidators;
using Core.CrossCuttingConcerns.Caching;
using Core.CrossCuttingConcerns.Logging;
using Core.CrossCuttingConcerns.Logging.SeriLog.Logger;
using Core.CrossCuttingConcerns.Validation;
using Core.DataAccess.Paging;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class EducationProgramLikesController : ControllerBase
{
    IEducationProgramLikeService _educationProgramLikeService;

    public EducationProgramLikesController(IEducationProgramLikeService educationProgramLikeService)
    {
        _educationProgramLikeService = educationProgramLikeService;
    }

    [Logging(typeof(MsSqlLogger))]
    [Logging(typeof(FileLogger))]
    [Cache(60)]
    [HttpGet("GetList")]
    public async Task<IActionResult> GetListAsync([FromQuery] PageRequest pageRequest)
    {
        var result = await _educationProgramLikeService.GetListAsync(pageRequest);
        return Ok(result);
    }


    [Logging(typeof(MsSqlLogger))]
    [Logging(typeof(FileLogger))]
    [Cache]
    [HttpGet("GetById")]
    public async Task<IActionResult> GetByIdAsync(Guid id)
    {
        var result = await _educationProgramLikeService.GetByIdAsync(id);
        return Ok(result);
    }

    [Logging(typeof(MsSqlLogger))]
    [Logging(typeof(FileLogger))]
    [Cache]
    [HttpGet("GetByAccountId")]
    public async Task<IActionResult> GetByAccountIdAsync([FromQuery] Guid accountId)
    {
        var result = await _educationProgramLikeService.GetByAccountIdAsync(accountId);
        return Ok(result);
    }

    [Logging(typeof(MsSqlLogger))]
    [Logging(typeof(FileLogger))]
    [Cache]
    [HttpGet("GetByEducationProgramId")]
    public async Task<IActionResult> GetByEducationProgramIdAsync([FromQuery] Guid educationProgramId)
    {
        var result = await _educationProgramLikeService.GetByEducationProgramIdAsync(educationProgramId);
        return Ok(result);
    }

    [Logging(typeof(MsSqlLogger))]
    [Logging(typeof(FileLogger))]
    [Cache]
    [HttpGet("GetByEducationProgramIdAndAccountId")]
    public async Task<IActionResult> GetByEducationProgramIdAndAccountIdAsync([FromQuery] Guid educationProgramId, Guid accountId)
    {
        var result = await _educationProgramLikeService.GetByEducationProgramIdAndAccountIdAsync(educationProgramId, accountId);
        return Ok(result);
    }

    [Logging(typeof(MsSqlLogger))]
    [Logging(typeof(FileLogger))]
    [CacheRemove("EducationProgramLikes.Get")]
    [CustomValidation(typeof(CreateEducationProgramLikeRequestValidator))]
    [HttpPost]
    public async Task<IActionResult> AddAsync([FromBody] CreateEducationProgramLikeRequest createEducationProgramLikeRequest)
    {
        var result = await _educationProgramLikeService.AddAsync(createEducationProgramLikeRequest);
        return Ok(result);
    }


    [Logging(typeof(MsSqlLogger))]
    [Logging(typeof(FileLogger))]
    [CacheRemove("EducationProgramLikes.Get")]
    [CustomValidation(typeof(UpdateEducationProgramLikeRequestValidator))]
    [HttpPut]
    public async Task<IActionResult> UpdateAsync([FromBody] UpdateEducationProgramLikeRequest updateEducationProgramLikeRequest)
    {
        var result = await _educationProgramLikeService.UpdateAsync(updateEducationProgramLikeRequest);
        return Ok(result);
    }


    [Logging(typeof(MsSqlLogger))]
    [Logging(typeof(FileLogger))]
    [CacheRemove("EducationProgramLikes.Get")]
    [HttpDelete]
    public async Task<IActionResult> DeleteAsync([FromBody] DeleteEducationProgramLikeRequest deleteEducationProgramLikeRequest)
    {
        var result = await _educationProgramLikeService.DeleteAsync(deleteEducationProgramLikeRequest);
        return Ok(result);
    }


    [Logging(typeof(MsSqlLogger))]
    [Logging(typeof(FileLogger))]
    [CacheRemove("EducationProgramLikes.Get")]
    [HttpPost("DeleteByAccountIdAndEducationProgramId")]
    public async Task<IActionResult> DeleteByAccountIdAndEducationProgramIdAsync([FromBody] DeleteEducationProgramLikeRequest deleteEducationProgramLikeRequest)
    {
        var result = await _educationProgramLikeService.DeleteByAccountIdAndEducationProgramIdAsync(deleteEducationProgramLikeRequest);
        return Ok(result);
    }
}
