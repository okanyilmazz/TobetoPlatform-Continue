using Business.Abstracts;
using Core.CrossCuttingConcerns.Caching;
using Core.CrossCuttingConcerns.Logging.SeriLog.Logger;
using Core.CrossCuttingConcerns.Logging;
using Microsoft.AspNetCore.Mvc;
using Business.Dtos.Requests.LanguageRequests;
using Core.DataAccess.Paging;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class LanguagesController : ControllerBase
{
    ILanguageService _languageService;

    public LanguagesController(ILanguageService languageService)
    {
        _languageService = languageService;
    }

    [Logging(typeof(MsSqlLogger))]
    [Logging(typeof(FileLogger))]
    [Cache(60)]
    [HttpGet("GetList")]
    public async Task<IActionResult> GetListAsync([FromQuery] PageRequest pageRequest)
    {
        var result = await _languageService.GetListAsync(pageRequest);
        return Ok(result);
    }


    [Logging(typeof(MsSqlLogger))]
    [Logging(typeof(FileLogger))]
    [Cache]
    [HttpGet("GetById")]
    public async Task<IActionResult> GetByIdAsync(Guid id)
    {
        var result = await _languageService.GetByIdAsync(id);
        return Ok(result);
    }


    [Logging(typeof(MsSqlLogger))]
    [Logging(typeof(FileLogger))]
    [Cache]
    [HttpGet("GetByAccountId")]
    public async Task<IActionResult> GetByAccountIdAsync(Guid id)
    {
        var result = await _languageService.GetByAccountIdAsync(id);
        return Ok(result);
    }


    [Logging(typeof(MsSqlLogger))]
    [Logging(typeof(FileLogger))]
    [CacheRemove("Languages.Get")]
    [HttpPost]
    public async Task<IActionResult> AddAsync([FromBody] CreateLanguageRequest createLanguageRequest)
    {
        var result = await _languageService.AddAsync(createLanguageRequest);
        return Ok(result);
    }


    [Logging(typeof(MsSqlLogger))]
    [Logging(typeof(FileLogger))]
    [CacheRemove("Languages.Get")]
    [HttpPut]
    public async Task<IActionResult> UpdateAsync([FromBody] UpdateLanguageRequest updateLanguageRequest)
    {
        var result = await _languageService.UpdateAsync(updateLanguageRequest);
        return Ok(result);
    }


    [Logging(typeof(MsSqlLogger))]
    [Logging(typeof(FileLogger))]
    [CacheRemove("Languages.Get")]
    [HttpDelete]
    public async Task<IActionResult> DeleteAsync([FromBody] DeleteLanguageRequest deleteLanguageRequest)
    {
        var result = await _languageService.DeleteAsync(deleteLanguageRequest);
        return Ok(result);
    }
}
