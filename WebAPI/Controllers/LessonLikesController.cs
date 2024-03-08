using Business.Abstracts;
using Business.Dtos.Requests.LessonLikeRequests;
using Business.Rules.ValidationRules.FluentValidation.LessonLikeValidator;
using Core.CrossCuttingConcerns.Caching;
using Core.CrossCuttingConcerns.Logging;
using Core.CrossCuttingConcerns.Logging.SeriLog.Logger;
using Core.CrossCuttingConcerns.Validation;
using Core.DataAccess.Paging;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class LessonLikesController : ControllerBase
{
    ILessonLikeService _lessonLikeService;

    public LessonLikesController(ILessonLikeService lessonLikeService)
    {
        _lessonLikeService = lessonLikeService;
    }

    [Logging(typeof(MsSqlLogger))]
    [Logging(typeof(FileLogger))]
    [Cache(60)]
    [HttpGet("GetList")]
    public async Task<IActionResult> GetListAsync([FromQuery] PageRequest pageRequest)
    {
        var result = await _lessonLikeService.GetListAsync(pageRequest);
        return Ok(result);
    }


    [Logging(typeof(MsSqlLogger))]
    [Logging(typeof(FileLogger))]
    [Cache]
    [HttpGet("GetById")]
    public async Task<IActionResult> GetByIdAsync(Guid id)
    {
        var result = await _lessonLikeService.GetByIdAsync(id);
        return Ok(result);
    }

    [Logging(typeof(MsSqlLogger))]
    [Logging(typeof(FileLogger))]
    [Cache]
    [HttpGet("GetByAccountId")]
    public async Task<IActionResult> GetByAccountIdAsync([FromQuery] Guid accountId)
    {
        var result = await _lessonLikeService.GetByAccountIdAsync(accountId);
        return Ok(result);
    }

    [Logging(typeof(MsSqlLogger))]
    [Logging(typeof(FileLogger))]
    [Cache]
    [HttpGet("GetByLessonId")]
    public async Task<IActionResult> GetByLessonIdAsync([FromQuery] Guid lessonId)
    {
        var result = await _lessonLikeService.GetByLessonIdAsync(lessonId);
        return Ok(result);
    }

    [Logging(typeof(MsSqlLogger))]
    [Logging(typeof(FileLogger))]
    [Cache]
    [HttpGet("GetByLessonIdAndAccountId")]
    public async Task<IActionResult> GetByLessonIdAndAccountIdAsync([FromQuery] Guid lessonId, Guid accountId)
    {
        var result = await _lessonLikeService.GetByLessonIdAndAccountIdAsync(lessonId, accountId);
        return Ok(result);
    }

    [Logging(typeof(MsSqlLogger))]
    [Logging(typeof(FileLogger))]
    [CacheRemove("LessonLikes.Get")]
    [CustomValidation(typeof(CreateLessonLikeRequestValidator))]
    [HttpPost]
    public async Task<IActionResult> AddAsync([FromBody] CreateLessonLikeRequest createLessonLikeRequest)
    {
        var result = await _lessonLikeService.AddAsync(createLessonLikeRequest);
        return Ok(result);
    }


    [Logging(typeof(MsSqlLogger))]
    [Logging(typeof(FileLogger))]
    [CacheRemove("LessonLikes.Get")]
    [CustomValidation(typeof(UpdateLessonLikeRequestValidator))]
    [HttpPut]
    public async Task<IActionResult> UpdateAsync([FromBody] UpdateLessonLikeRequest updateLessonLikeRequest)
    {
        var result = await _lessonLikeService.UpdateAsync(updateLessonLikeRequest);
        return Ok(result);
    }


    [Logging(typeof(MsSqlLogger))]
    [Logging(typeof(FileLogger))]
    [CacheRemove("LessonLikes.Get")]
    [HttpDelete]
    public async Task<IActionResult> DeleteAsync([FromBody] DeleteLessonLikeRequest deleteLessonLikeRequest)
    {
        var result = await _lessonLikeService.DeleteAsync(deleteLessonLikeRequest);
        return Ok(result);
    }

    [Logging(typeof(MsSqlLogger))]
    [Logging(typeof(FileLogger))]
    [CacheRemove("LessonLikes.Get")]
    [HttpPost("DeleteByAccountIdAndLessonId")]
    public async Task<IActionResult> DeleteByAccountIdAndLessonIdAsync([FromBody] DeleteLessonLikeRequest deleteLessonLikeRequest)
        {
        var result = await _lessonLikeService.DeleteByAccountIdAndLessonIdAsync(deleteLessonLikeRequest);
        return Ok(result);
    }
}
