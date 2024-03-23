using Business.Abstracts;
using Core.CrossCuttingConcerns.Caching;
using Core.CrossCuttingConcerns.Logging.SeriLog.Logger;
using Core.CrossCuttingConcerns.Logging;
using Microsoft.AspNetCore.Mvc;
using Business.Dtos.Requests.HomeworkRequests;
using Core.DataAccess.Paging;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class HomeworksController : ControllerBase
{
    IHomeworkService _homeworkService;

    public HomeworksController(IHomeworkService homeworkService)
    {
        _homeworkService = homeworkService;
    }

    [Logging(typeof(MsSqlLogger))]
    [Logging(typeof(FileLogger))]
    [Cache(60)]
    [HttpGet("GetList")]
    public async Task<IActionResult> GetListAsync([FromQuery] PageRequest pageRequest)
    {
        var result = await _homeworkService.GetListAsync(pageRequest);
        return Ok(result);
    }


    [Logging(typeof(MsSqlLogger))]
    [Logging(typeof(FileLogger))]
    [Cache]
    [HttpGet("GetByAccountId")]
    public async Task<IActionResult> GetByAccountId(Guid id)
    {
        var result = await _homeworkService.GetByAccountIdAsync(id);
        return Ok(result);
    }


    [Logging(typeof(MsSqlLogger))]
    [Logging(typeof(FileLogger))]
    [Cache]
    [HttpGet("GetByLessonId")]
    public async Task<IActionResult> GetByLessonIdAsync(Guid lessonId)
    {
        var result = await _homeworkService.GetByLessonIdAsync(lessonId);
        return Ok(result);
    }


    [Logging(typeof(MsSqlLogger))]
    [Logging(typeof(FileLogger))]
    [Cache]
    [HttpGet("GetById")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var result = await _homeworkService.GetByIdAsync(id);
        return Ok(result);
    }


    [Logging(typeof(MsSqlLogger))]
    [Logging(typeof(FileLogger))]
    [CacheRemove("Homeworks.Get")]
    [HttpPost]
    public async Task<IActionResult> AddAsync([FromBody] CreateHomeworkRequest createHomeworkRequest)
    {
        var result = await _homeworkService.AddAsync(createHomeworkRequest);
        return Ok(result);
    }


    [Logging(typeof(MsSqlLogger))]
    [Logging(typeof(FileLogger))]
    [CacheRemove("Homeworks.Get")]
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync([FromRoute] Guid id)
    {
        var result = await _homeworkService.DeleteAsync(id);
        return Ok(result);
    }

    [Logging(typeof(MsSqlLogger))]
    [Logging(typeof(FileLogger))]
    [CacheRemove("Homeworks.Get")]
    [HttpPut]
    public async Task<IActionResult> UpdateAsync([FromBody] UpdateHomeworkRequest updateHomeworkRequest)
    {
        var result = await _homeworkService.UpdateAsync(updateHomeworkRequest);
        return Ok(result);
    }
}

