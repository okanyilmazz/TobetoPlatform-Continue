using Business.Abstracts;
using Core.CrossCuttingConcerns.Caching;
using Core.CrossCuttingConcerns.Logging.SeriLog.Logger;
using Core.CrossCuttingConcerns.Logging;
using Microsoft.AspNetCore.Mvc;
using Business.Dtos.Requests.LanguageLevelRequests;
using Core.DataAccess.Paging;

namespace WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class LanguageLevelsController : ControllerBase
{
    ILanguageLevelService _languageLevelService;

    public LanguageLevelsController(ILanguageLevelService languageLevelService)
    {
        _languageLevelService = languageLevelService;
    }

    [Logging(typeof(MsSqlLogger))]
    [Logging(typeof(FileLogger))]
    [Cache(60)]
    [HttpGet("GetList")]
    public async Task<IActionResult> GetListAsync([FromQuery] PageRequest pageRequest)
    {
        var result = await _languageLevelService.GetListAsync(pageRequest);
        return Ok(result);
    }


    [Logging(typeof(MsSqlLogger))]
    [Logging(typeof(FileLogger))]
    [Cache]
    [HttpGet("GetById")]
    public async Task<IActionResult> GetByIdAsync(Guid id)
    {
        var result = await _languageLevelService.GetByIdAsync(id);
        return Ok(result);
    }


    [Logging(typeof(MsSqlLogger))]
    [Logging(typeof(FileLogger))]
    [CacheRemove("LanguageLevels.Get")]
    [HttpPost("Add")]
    public async Task<IActionResult> AddAsync([FromBody] CreateLanguageLevelRequest createLanguageLevelRequest)
    {
        var result = await _languageLevelService.AddAsync(createLanguageLevelRequest);
        return Ok(result);
    }


    [Logging(typeof(MsSqlLogger))]
    [Logging(typeof(FileLogger))]
    [CacheRemove("LanguageLevels.Get")]
    [HttpPost("Update")]
    public async Task<IActionResult> UpdateAsync([FromBody] UpdateLanguageLevelRequest updateProjectRequest)
    {
        var result = await _languageLevelService.UpdateAsync(updateProjectRequest);
        return Ok(result);
    }


    [Logging(typeof(MsSqlLogger))]
    [Logging(typeof(FileLogger))]
    [CacheRemove("LanguageLevels.Get")]
    [HttpPost("Delete")]
    public async Task<IActionResult> DeleteAsync([FromBody] DeleteLanguageLevelRequest deleteProjectRequest)
    {
        var result = await _languageLevelService.DeleteAsync(deleteProjectRequest);
        return Ok(result);
    }
}